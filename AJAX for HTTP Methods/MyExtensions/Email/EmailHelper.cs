using System.Net.Mail;

namespace AAJAX_for_HTTP_Methods.MyExtensions.Email
{
    public class EmailHelper
    {
        public async Task<bool> SendEmail(string email, string message)
        {



            #region Mail Ayarlari

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("cinaliveli5@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Body = message;
            mailMessage.Subject = "IoT Automations Mail onaylama";
            mailMessage.IsBodyHtml = true;


            #endregion

            #region SMTP Ayarlari
            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Credentials = new System.Net.NetworkCredential("cinaliveli5@gmail.com", "cvsdhgjolvhnfnbq");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;


            #endregion

            try
            {
                smtpClient.Send(mailMessage);

                return true;


            }
            catch (Exception ex)
            {

                return false;
            }




            return true;
        }
    }
}
