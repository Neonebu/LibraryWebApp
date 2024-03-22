using System.Net.Mail;

namespace LibraryWebApp.Models
{
    public class MailModel
    {
        public static string? userEmail { get; set; }
        public required string From {get;set;}
        public required string To { get;set;}
        public required string Subject { get;set;}
        public required string Body { get;set;}
        public static string getUserEmail(User user)
        {
            return "oguzcansirolu1@gmail.com";
        }
        public static bool sendEmail(User user)
        {
            bool send = false;
            MailMessage mail = new MailMessage();
            userEmail = getUserEmail(user);
            mail.To.Add(userEmail);
            mail.From = new MailAddress("oguzcan34@zohomail.com");
            mail.Subject = "Activation";
            mail.Body = "Activation";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.zoho.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("oguzcan34@zohomail.com", "3istanbul");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
                send = true;
            }
            catch (SmtpFailedRecipientException ex)
            {
                send = false;
            }
            return send;
        }
    }
}
