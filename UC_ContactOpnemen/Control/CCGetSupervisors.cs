using ContactOpnemen.BU;
using System.Data;

namespace UC_ContactOpnemen.CC
{
    public class CCGetSupervisors
    {
        public DataTable ReturnSupervisors()
        {
            AspNetUsers user = new AspNetUsers();
            return user.GetSupervisors();
        }
    }
}