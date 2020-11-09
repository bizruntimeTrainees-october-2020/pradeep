using System;
using System.Data.SqlClient;

namespace adoconnect
{
    class Program
    {
        public static void Main(string[] args)
        {
            new Program().Connecting();
            Console.ReadLine();
        }
        public void Connecting()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection(@"data source=DESKTOP-FM1871P\MSSQLSERVER01; database=adodat; integrated security=true");

                Console.WriteLine("Connection Established Successfully");
                SqlCommand cm = new SqlCommand("select * from vidyalaya", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["name"] + " " + sdr["email"]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            finally
            {   // Closing the connection  
                con.Close();
            }
        
        }
    }
}
