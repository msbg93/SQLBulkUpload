using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DOWUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string queryCRM = "SELECT Phone_fax,email1 FROM vtiger_users";
                string queryDWH = "select * from [Crm_Dao]";

                DataTable dtCRM = mySQLDatabase.GetTable(queryCRM);
                DataTable dtDWH = Database.GetTable(queryDWH);
                if (dtDWH.Rows.Count > 0)
                {
                    string queryDeleteDWH = "truncate table [Crm_Dao]";
                    Database.ExecuteQuery(queryDeleteDWH);
                }              

                using (SqlBulkCopy BulkCopy = new SqlBulkCopy(Connection.GetConnection()))
                {                    
                    BulkCopy.ColumnMappings.Add("Phone_fax", "Dao");
                    BulkCopy.ColumnMappings.Add("email1", "Email");
                    BulkCopy.DestinationTableName = "dbo.[Crm_Dao]";
                    BulkCopy.WriteToServer(dtCRM);
                }

                mySQLConnection.GetConnection().Close();
                mySQLConnection.GetConnection().Dispose();
                Connection.GetConnection().Close();
                Connection.GetConnection().Dispose();

                Console.WriteLine("Data transfer from CRM to DWH completed");
                Console.ReadLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }       
    }
}
