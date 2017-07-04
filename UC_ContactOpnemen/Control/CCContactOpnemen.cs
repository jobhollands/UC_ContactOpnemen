using ContactOpnemen.BU;

namespace UC_ContactOpnemen.CC
{
    public class CCContactOpnemen
    {
        /// <summary>
        /// This method passes data to save and send the mail
        /// This method returns a boolean if mail has been saved and send correctly or not
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SaveMail(string name, string email, string subject, string message, string userId)
        {
            Contact contact = new Contact();

            if (contact.saveMail(name, email, subject, message, userId))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method returns the user's emailadress
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string GetEmailAdress(string userID)
        {
            return new IdentityExtensions().GetEmailAdress(userID); 

        }
    }
}