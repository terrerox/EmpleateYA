using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace server.Models
{
    public class MailRequest
    {
        public MailRequest(string toEmail, string subject, string body)
        {
            this.ToEmail = toEmail;
            this.Subject = subject;
            this.Body = body;

        }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }

    }
}