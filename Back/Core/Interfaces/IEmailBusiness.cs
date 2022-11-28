using CohorteApi.Core.Models.Email;

namespace CohorteApi.Core.Interfaces
{
    public interface IEmailBusiness
    {
        Task SendEmailAsync(Message emailModel);
        Task SendWelcomeEmailAsync(string name, string email);
   
        Task SendNewsLetterAsync(int id, List<String> emails);
        Task SendRecoverPasswordEmailAsync(string email);


    }
}
