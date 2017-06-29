using System.Data;
using System.Data.SqlClient;

namespace ContactOpnemen.BU
{
    public partial class AspNetUsers
    {
        private static DataTable dt;
        public DataTable GetSupervisors()
        {
            string connString = @"Data Source=casus.database.windows.net;Initial Catalog=DB_ContactOpnemen;Integrated Security=False;User ID=casusB2D3;Password=Qwerty1$;MultipleActiveResultSets=True;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;Application Name=EntityFramework;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string query = "select username Gebruikersnaam, phonenumber Telefoonnummer from aspnetusers users join aspnetuserroles userrole on users.id = userrole.userid where userrole.roleid = 5";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            dt = new DataTable();

            da.Fill(dt);

            conn.Close();

            da.Dispose();

            return dt;
        }
    }
}
