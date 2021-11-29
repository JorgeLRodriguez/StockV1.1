using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Services.DAL.Repositories.Tools
{
    internal static class SqlHelper
    {
        readonly static string conString;
        static SqlHelper()
        {
            conString = ConfigurationManager.ConnectionStrings["cnnSec"].ConnectionString;
        }
        public static Int32 ExecuteNonQuery(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new(conString))
            {
                using (SqlCommand cmd = new(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static SqlDataReader ExecuteReader(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(conString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
        }
    }
}