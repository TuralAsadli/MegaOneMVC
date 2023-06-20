using System.Net.Mail;
using System.Net;

namespace MegaOneMvc.Utilites.Email
{
    public class EmailManager
    {
        IConfiguration _configuration;
        private readonly string?  _sender;
        private readonly string? _password;
        private readonly string? _port;
        private readonly string? _server;     

        public EmailManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _sender = _configuration.GetSection("EmailSettings")["SenderEmail"];
            _password = _configuration.GetSection("EmailSettings")["SenderPassword"];
            _port = _configuration.GetSection("EmailSettings")["SmtpPort"];
            _server = _configuration.GetSection("EmailSettings")["SmtpServer"];
        }

        public void SendEmail(string repient, string Username, DateTime date, string hour)
        {
            // Create a new MailMessage object
            MailMessage mail = new MailMessage(_sender, repient);

            // Set the subject and body of the email
            mail.Subject = "Hello from MegaOne";
            mail.Body = $"Hi {Username}! You booked a table for {hour} hours on {date.ToString("dd.MM.yyyy")}";

            // Create a new SmtpClient and specify the SMTP server (Gmail's SMTP server)
            SmtpClient smtpClient = new SmtpClient(_server, int.Parse(_port));

            // Set the SMTP client credentials (sender's email address and app password)
            smtpClient.Credentials = new NetworkCredential(_sender, _password);

            // Enable SSL encryption
            smtpClient.EnableSsl = true;
            // Create a new MailMessage object


            try
            {
                // Send the email
                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
