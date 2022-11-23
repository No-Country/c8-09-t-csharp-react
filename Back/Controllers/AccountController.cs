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

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IConfiguration _configuration;
    private readonly DbContextOptions<ApplicationDbContext> options;

    public AuthenticateController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, DbContextOptions<ApplicationDbContext> options)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        _configuration = configuration;
        this.options = options;
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
            return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });

        //var emailExists = await userManager.FindByEmailAsync(model.Email);
        //if (emailExists != null)
        //    return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Email is already associated with an account!" });

        IdentityUser user = new IdentityUser()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = $"User creation failed! Please check user details and try again. {String.Join(" | ",result.Errors.Select( x => x.Description))}" });

        var resultRoleAssign = await userManager.AddToRoleAsync(user, UserRoles.User);
        var roleMessage = "";
        if (resultRoleAssign.Succeeded) roleMessage = " as User Role";

        return Ok(new { Status = "Success", Message = $"User created{roleMessage} successfully!" });
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

        var currentRoles =await  userManager.GetRolesAsync(userExists);
        var removeResult =await userManager.RemoveFromRolesAsync(userExists, currentRoles);
        if (!removeResult.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Role assignation  failed! Please report this error." });
        
        var resultRoleAssign = await userManager.AddToRoleAsync(userExists, model.Role);
        if (!resultRoleAssign.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Role assignation  failed! Please report this error." });

        return Ok(new { Status = "Success", Message = $"User is now in role {model.Role}!" });

    }

    [Obsolete("")]
    [HttpPost]
    [Route("CreateRolesAdminUser")]
    public async Task<IActionResult> AddRole()
    {
        //var user = await userManager.FindByNameAsync(name);
        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        if (!await roleManager.RoleExistsAsync(UserRoles.User))
            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        //if (await roleManager.RoleExistsAsync(UserRoles.Admin))
        //{
        //    await userManager.AddToRoleAsync(user, UserRoles.Admin);
        //}
        return Ok(new { Status = "Success", Message = "User and Admin roles created successfully!" });
    }
    [HttpGet]
    [Route("Users")]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(userManager.Users.ToList());
    }


    private void ResetUsers()
    {
        ApplicationDbContext ctx = new ApplicationDbContext(options);
        ctx.UserRoles.RemoveRange(ctx.UserRoles);
        ctx.Users.RemoveRange(ctx.Users);
        ctx.SaveChanges();
        userManager.Users.ToList().ForEach(x => userManager.DeleteAsync(x));
    }
}


