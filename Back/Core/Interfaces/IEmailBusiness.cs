using CohorteApi.Core.Models.Email;
using CohorteApi.Models;

namespace CohorteApi.Core.Interfaces
{
    public interface IEmailBusiness
    {
        Task SendEmailAsync(Message emailModel);
        Task SendWelcomeEmailAsync(string name, string email);
   
        Task SendNewsLetterAsync(int id, List<String> emails);
        Task SendRecoverPasswordEmailAsync(string email,string userName, string link,string? title= "Recover your password");

        Task SendNewsletterOptInEmail(string email);
        Task SendSaleConfirmationEmail(Sale sale);

        Task SendPaymentConfirmationEmail(Sale sale);
        Task SendCancelOrderConfirmationEmail(Sale sale);

    }
}
