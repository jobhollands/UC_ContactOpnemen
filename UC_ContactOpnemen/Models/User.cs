﻿using System.Data;
using System.Data.SqlClient;

namespace ContactOpnemen.BU
{
    public partial class AspNetUsers
    {
        private static DataTable dt;

        /// <summary>
        /// This method returns all supervisors with their Username and accountrole name
        /// In the future this method will be updated; than it needs to return the first name, last name and phonenumber of all supervisors
        /// </summary>
        /// <returns></returns>
        public DataTable GetSupervisors()
        {
            string connString = @"Data Source=casus.database.windows.net;Initial Catalog=DB_ContactOpnemen;Integrated Security=False;User ID=casusB2D3;Password=Qwerty1$;MultipleActiveResultSets=True;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;Application Name=EntityFramework;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string query = "select username Gebruikersnaam, phonenumber Telefoonnummer from aspnetusers users join aspnetuserroles userrole on users.id = userrole.userid where userrole.roleid = 5";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            dt = new DataTable();

            try
            {
                conn.Open();

                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable


                da.Fill(dt);

                conn.Close();

                da.Dispose();

                return dt;
            }
            catch
            {
                return dt;
            }
        }
    }
}
