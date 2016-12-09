﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Common;
/// <summary>
/// Summary description for Connection
/// </summary>
public class Connection
{
    private static readonly string connectionString = ConfigurationManager.ConnectionStrings["T24DWH"].ConnectionString;
    private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
	public Connection()
	{
        // TODO: Add constructor logic here
	}

    public static SqlConnection GetConnection()
    {

        string dbcon = ConfigurationManager.ConnectionStrings["T24DWH"].ConnectionString;
        try
            {
                
                     SqlConnection con = new SqlConnection(dbcon);
                    con.Close();
                    con.Open();
                    return con;
               
            }
        catch (Exception)
        {
             throw;
        }
    }

       
    public static DataTable GetDataTable(string sql, SqlParameter[] parameters)
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
        }

}
