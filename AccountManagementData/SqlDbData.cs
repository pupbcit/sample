using AccountManagementModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementData
{
    public class SqlDbData
    {

        static string connectionString
        = "Data Source =INDALEEN\\SQLEXPRESS; Initial Catalog = AccountManagement; Integrated Security = True;";

        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        public static void Connect()
        {
            sqlConnection.Open();
        }

        public static List<User> GetUsers()
        {
            string selectStatement = "SELECT username, password FROM users";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();

                User readUser = new User();
                readUser.username = username;
                readUser.password = password;

                users.Add(readUser);
            }

            sqlConnection.Close();

            return users;
        }

        public static int AddUser(string username, string password)
        {
            int success;

            string insertStatement = "INSERT INTO users VALUES (@username, @password)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@password", password);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public static void UpdateUser(string username, string password)
        {
            string updateStatement = $"UPDATE users SET password = @Password WHERE username = @username";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@Password", password);
            updateCommand.Parameters.AddWithValue("@username", username);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public static void DeleteUser(string username)
        {
            string deleteStatement = $"DELETE FROM users WHERE username = @username";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@username", username);

            deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
