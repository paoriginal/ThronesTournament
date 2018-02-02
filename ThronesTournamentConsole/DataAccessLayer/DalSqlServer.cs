using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    class DalSqlServer : iDal
    {
        string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\auchedotal\\Downloads\\ThronesTournamentConsole\\ThronesTournament.mdf;Integrated Security=True;Connect Timeout=30";

        List<string> iDal.ExecSelectRequest(string request)
        {
            List<string> results = new List<string>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    string row = "";

                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        Object attr = null;

                        attr = sqlDataReader[sqlDataReader.GetName(i)];
                        row += string.Format("{0},", attr==null ? "" : attr.ToString());
                    }
                    results.Add(row);
                }
                sqlConnection.Close();
            }

            return results;
        }

        void iDal.ExecRequest(string request)
        {
            List<string> results = new List<string>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                sqlConnection.Close();
            }
        }
    }
}
