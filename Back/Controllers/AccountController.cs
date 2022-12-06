using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using CohorteApi.Models.Identity;
using CohorteApi.Core.Models.Auth;
using CohorteApi.Data;
using Microsoft.EntityFrameworkCore;
using CohorteApi.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using CohorteApi.Models;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly UserManager<AppUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IConfiguration _configuration;
    private readonly DbContextOptions<ApplicationDbContext> options;
    private readonly IEmailBusiness emailBusiness;

    public AuthenticateController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, DbContextOptions<ApplicationDbContext> options, IEmailBusiness email)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        _configuration = configuration;
        this.options = options;
        this.emailBusiness = email;
    }

    [HttpGet]
    [Route("Users")]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(userManager.Users.ToList());
    }
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            authClaims.Add(new Claim(ClaimTypes.Name, user.UserName));
            authClaims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                claims: authClaims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return Ok(new LoginResult
            {
                Successful = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo,
                Error = ""
            });
        }
        return BadRequest(new LoginResult { Successful = false, Error = "Username or password are invalid.", Expiration = DateTime.Now.AddMinutes(-4), Token = null });
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {

        var userExists = await userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return StatusCode(StatusCodes.Status400BadRequest, new { Status = "Error", Message = "User already exists!" });

        var emailExists = await userManager.FindByEmailAsync(model.Email);
        if (emailExists != null)
            return StatusCode(StatusCodes.Status400BadRequest, new { Status = "Error", Message = "Email is already associated with an account!" });

        AppUser user = new AppUser()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = $"User creation failed! Please check user details and try again. {String.Join(" | ", result.Errors.Select(x => x.Description))}" });

        Task welcomeTask = emailBusiness.SendWelcomeEmailAsync(model.Username, model.Email);

        var resultRoleAssign = await userManager.AddToRoleAsync(user, UserRoles.User);
        var roleMessage = "";

        //TODO not awaiting can lead mail not get delivered
        //  await welcomeTask.WaitAsync(TimeSpan.FromSeconds(2));

        if (resultRoleAssign.Succeeded) roleMessage = " as User Role";
        return Ok(new { Status = "Success", Message = $"User created{roleMessage} successfully!" });
    }

    [HttpPost("ForgotPassword")]
    public async Task<IActionResult> ForgotPassword([EmailAddress][Required] string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
            //return Ok(); //dont let know user if email exists
            return BadRequest();

        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        try
        {
            var link = @$"https://tiketfan.vercel.app/resetpassword?t={token}&email={user.Email}";
            await emailBusiness.SendRecoverPasswordEmailAsync(user.Email, user.UserName, link);
            //TODO remove this only for debug
            var model = new { Token = token, Email = user.Email };
            return Ok(model);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
    {
        //if all ok
        var user = await userManager.FindByEmailAsync(model.Email);
        var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
        if (result.Succeeded)
        {
            return Ok();
        }
        else
        {
            return BadRequest(String.Join(" | ", result.Errors));
        }
    }


    /// <summary>
    /// Add a role to a user
    /// </summary>
    /// <param name="role">can be admin or user</param>
    /// <param name="idUser">the user email </param>
    /// <returns></returns>
    [HttpPost]
    [Route("SetRole")]
    public async Task<IActionResult> SetRoleToUser(AddRoleToUserModel model)
    {
        var userExists = await userManager.FindByEmailAsync(model.UserEmail);
        if (userExists == null)
            return StatusCode(StatusCodes.Status400BadRequest, new { Status = "Error", Message = "User doesn´t exists!" });

        //if (!await roleManager.RoleExistsAsync(model.Role))
        //    return StatusCode(StatusCodes.Status400BadRequest, new { Status = "Error", Message = "Role doesn´t exists, a valid role must be provided" });

        var currentRoles = await userManager.GetRolesAsync(userExists);
        var removeResult = await userManager.RemoveFromRolesAsync(userExists, currentRoles);
        if (!removeResult.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Role assignation  failed! Please report this error." });

        var resultRoleAssign = await userManager.AddToRoleAsync(userExists, model.Role);
        if (!resultRoleAssign.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Role assignation  failed! Please report this error." });

        return Ok(new { Status = "Success", Message = $"User is now in role {model.Role}!" });

    }

    [HttpGet]
    [Route("tests/deleteallusers")]
    public void ResetUsers()
    {
        ApplicationDbContext ctx = new ApplicationDbContext(options);
        ctx.UserRoles.RemoveRange(ctx.UserRoles);
        ctx.Users.RemoveRange(ctx.Users);
        ctx.SaveChanges();
        userManager.Users.ToList().ForEach(x => userManager.DeleteAsync(x));
    }

    public class ResetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Token { get; set; }

    }
}


