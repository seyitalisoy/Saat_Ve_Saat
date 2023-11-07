namespace Web.Services
{
    public interface IEmailService
    {
        Task SendResetPasswordEmail(string email,string toEmail);
    }
}
