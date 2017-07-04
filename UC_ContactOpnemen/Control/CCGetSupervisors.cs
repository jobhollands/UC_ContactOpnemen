using ContactOpnemen.BU;
using System.Data;

namespace UC_ContactOpnemen.CC
{
    public class CCGetSupervisors
    {
        /// <summary>
        /// This method returns the supervisors in a datatable
        /// </summary>
        /// <returns></returns>
        public DataTable ReturnSupervisors()
        {
            AspNetUsers user = new AspNetUsers();
            return user.GetSupervisors();
        }
    }
}