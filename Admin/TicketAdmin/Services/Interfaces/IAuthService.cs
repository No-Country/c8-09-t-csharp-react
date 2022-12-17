using TicketFanAdmin.Models.Identity;

namespace TicketFanAdmin.Services.Interfaces
{
    internal interface IAuthService
    {
        Task CheckForExpiry();
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}