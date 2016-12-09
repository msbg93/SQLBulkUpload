using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Data;

namespace DOWUtility
{
    class mySQLConnection
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["CRMMYSQL"].ConnectionString;        
        //private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
        public mySQLConnection()
        {
            // TODO: Add constructor logic here
        }

        public static MySqlConnection GetConnection()
        {            
            string dbcon = connectionString;
            try
            {
                MySqlConnection con = new MySqlConnection(dbcon);
                con.Close();
                con.Open();
                return con;

            }
            catch (Exception)
            {
                throw;
            }
        }


   /*     public static DataTable GetDataTable(string sql, MySqlParameter[] parameters)
        {
            try
            {
                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = connectionString;

                    using (DbCommand command = factory.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = sql;

                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                if (parameter != null)
                                    command.Parameters.Add(parameter);
                            }
                        }
                        using (DbDataAdapter adapter = factory.CreateDataAdapter())
                        {
                            adapter.SelectCommand = command;

                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            return dt;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }*/
    }
}
