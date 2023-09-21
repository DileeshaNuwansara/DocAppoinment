using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RAD_Project
{
    class DatabaseConnection
    {
        private static DatabaseConnection instance;
        private readonly string connectionString;
        private SqlConnection connection;

        private DatabaseConnection()
        {

            connectionString = @"Data Source=DileeshaNew;Initial Catalog=HospitalBooking;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public static DatabaseConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseConnection();
                }
                return instance;
            }
        }

        public SqlConnection GetConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        public void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }

        }
    }
}