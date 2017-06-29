using System.Linq;

namespace ContactOpnemen.BU
{
    public class IdentityExtensions
    {
        public string GetEmailAdress(string userID)
        {
            using (DB_ContactOpnemen context = new DB_ContactOpnemen())
            {
                var user = context.AspNetUsers.FirstOrDefault(u => u.Id == userID);

                return user.Email;
            }
        }
    }
}