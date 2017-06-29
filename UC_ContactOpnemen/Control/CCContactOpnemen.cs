using ContactOpnemen.BU;

namespace UC_ContactOpnemen.CC
{
    public class CCContactOpnemen
    {
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
    }
}