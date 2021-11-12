using System.Threading.Tasks;
using server.Models;

namespace server.Services.MailService
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}