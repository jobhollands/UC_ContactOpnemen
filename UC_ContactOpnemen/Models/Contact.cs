using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace ContactOpnemen.BU
{
    public partial class Contact
    {
        private string _contactEmailadress = "zuydergotherapie@gmail.com";

        public bool saveMail(string name, string email, string subject, string message, string userId)
        {
            try
            {
                using (DB_ContactOpnemen context = new DB_ContactOpnemen())
                {
                    Contact contact = new Contact();
                    contact.AspNetUsersId = userId;
                    contact.Name = name;
                    contact.Email = email;
                    contact.Subject = subject;
                    contact.Message = message;

                    context.ContactSet.Add(contact);
                    context.SaveChanges();
                }

                // mail versturen
                // zuydergotherapie is het VAN emailadres
                sendMail(_contactEmailadress, email, name, subject, message);

                if (name != "Anoniem")
                {
                    // bevestigingsmail naar de verzender sturen
                    sendMail(email, email, name, subject, message);
                }

                return true;
            }

            catch
            {
                return false;
            }
        }

        public void sendMail(string toEmailadress, string fromEmailadress, string name, string subject, string message)
        {
            using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["SMTPuser"], toEmailadress))
            {
                if (toEmailadress == _contactEmailadress)
                {
                    //onderwerp van de mail
                    mm.Subject = subject;
                    //bericht van de mail
                    mm.Body = "Naam: " + name + "\n" +
                        "E-mailadres: " + fromEmailadress + "\n" + "\n" +
                        message;
                }

                else
                {
                    mm.Subject = "No-reply Zuyd Ergotherapie";
                    //bericht van de mail
                    mm.Body = "Uw zojuist verzonden bericht." + "\n" + "\n" + message;
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"]); ;
                NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["SMTPuser"], ConfigurationManager.AppSettings["SMTPpassword"]);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); ;
                smtp.Send(mm);
            }
        }
    }
}