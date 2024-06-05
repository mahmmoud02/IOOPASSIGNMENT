using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project_2._0
{
    public class UserManager
    {
        private string connectionString = "Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;";

        public string GetUserRole(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT role FROM AllUserss WHERE username = @Username AND password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                string role = command.ExecuteScalar()?.ToString();

                return role;
            }
        }

    }
}
