using System.Threading.Tasks;

namespace RentACar.BLL.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
