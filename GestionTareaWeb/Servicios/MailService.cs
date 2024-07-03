using System.Net.Mail;
using System.Net;

namespace GestionTareaWeb.Servicios
{
    public class MailService
    {
        private SmtpClient mailClient = new SmtpClient
        {
            Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["CorreoEnvios"], System.Configuration.ConfigurationManager.AppSettings["PasswordCorreo"]),
            EnableSsl = true,
            Host = System.Configuration.ConfigurationManager.AppSettings["SmtpServer"],
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpPort"])
        };

        public async Task<MailingRepositoryResponse> SendEmailAsync(MailMessage emailMessage)
        {
            emailMessage.Sender = new MailAddress("rcadena@apptelink.com", "Apptelink Mail Service");
            try
            {
                await mailClient.SendMailAsync(emailMessage);
                return new MailingRepositoryResponse { Succesful = true, Message = "Correo enviado correctamente" };
            }
            catch (Exception e)
            {
                return new MailingRepositoryResponse { Succesful = false, Message = e.Message };
            }
        }
        public class MailingRepositoryResponse
        {
            public bool Succesful { get; set; }
            public string Message { get; set; }
        }
    }
}
