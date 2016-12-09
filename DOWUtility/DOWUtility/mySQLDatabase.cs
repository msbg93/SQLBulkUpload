using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DOWUtility
{
    class mySQLDatabase
    {
        public static DataTable GetTable(string query)
        {
            //string dbcon = ConfigurationManager.ConnectionStrings["Sebis"].ConnectionString;
            //SqlConnection con = new SqlConnection(dbcon);
            try
            {
                DataTable dt = new DataTable();

                //con.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(query, mySQLConnection.GetConnection());
                adapter.Fill(dt);
                // con.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ExecuteQuery(string query)
        {
            //string dbcon = ConfigurationManager.ConnectionStrings["Sebis"].ConnectionString;
            //SqlConnection con = new SqlConnection(dbcon);
            //con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, mySQLConnection.GetConnection());
                cmd.CommandTimeout = 50000000;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }


        }
    }

    
}
