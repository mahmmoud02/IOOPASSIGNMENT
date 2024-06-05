using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project_2._0
{
    public class UserUpdate
    {
        private string connectionString;

        public UserUpdate(string connectionStrings)
        {
            connectionString = connectionStrings;
        }

        public void UpdateUser(string fullName, string phoneNumber, string userName, string password, string role, string existingUsername)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Check if all fields are filled
                    if (string.IsNullOrWhiteSpace(fullName) ||
                        string.IsNullOrWhiteSpace(phoneNumber) ||
                        string.IsNullOrWhiteSpace(userName) ||
                        string.IsNullOrWhiteSpace(password) ||
                        string.IsNullOrWhiteSpace(role) )
                       // string.IsNullOrWhiteSpace(existingUsername))
                    {
                        MessageBox.Show("Please fill in all fields.");
                        return;
                    }
                    else
                    {

                    }

                    // Convert phoneNumber and password to appropriate types
                    int phoneNumberInt = Convert.ToInt32(phoneNumber);
                    int passwordInt = Convert.ToInt32(password);

                    string sqlQuery = "UPDATE AllUserss SET fullname = @fullname, phonenumber = @phonenumber, username = @username, password = @password, role = @role WHERE username = @existingUsername";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@fullname", fullName);
                        cmd.Parameters.AddWithValue("@phonenumber", phoneNumberInt);
                        cmd.Parameters.AddWithValue("@username", userName);
                        cmd.Parameters.AddWithValue("@password", passwordInt);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@existingUsername", existingUsername);

                        if (existingUsername != "Admin1")
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User Updated Successfully","Success!");
                            }
                            else
                            {
                                MessageBox.Show("No User Found with The Specified Username","Error!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot update Admin1","Error!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
