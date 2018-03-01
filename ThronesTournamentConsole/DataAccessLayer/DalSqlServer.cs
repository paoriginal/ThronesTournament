using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{

    //remettre sans les publics
    class DalSqlServer : iDal
    {
        private static DalSqlServer INSTANCE = null;
        private string _connectionString;

        private DalSqlServer() { _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\ThronesTournament\\ThronesTournament\\ThronesTournament\\ThronesTournamentConsole\\ThronesTournament.mdf;Integrated Security=True;Connect Timeout=30"; }

        //string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Aubin\\Documents\\ISIMA\\ZZ2\\SERVICES_WEB\\ThronesTournament\\ThronesTournamentConsole\\ThronesTournament.mdf;Integrated Security=True;Connect Timeout=30";

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
        public static DalSqlServer getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new DalSqlServer();

            return INSTANCE;
        }
    }
}
