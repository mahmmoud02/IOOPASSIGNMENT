using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace final_project_2._0
{
    public partial class ManagerMainDashboard : Form
    {
        SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;");
        SqlCommand cmd;

        public ManagerMainDashboard()
        {
            InitializeComponent();

            loaddate2();


            PopulateEmployeeNamesComboBox();
            textBox2.Text = Session.Username;
            textBox7.Text = Session.Username;
            button10();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //panel2.Visible = true;
            panel3.Visible = false;
            panel6.Visible = false;
        }

        private void Btnassigntasks_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            //panel2.Visible = false;
            panel6.Visible = false;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.ReadOnly = true;


        }
        private void loaddate2()
        {

            DataTable dataTable = new DataTable();
            string sqlQuery = "SELECT * FROM orderrequestss WHERE status = 'new'";

            using (SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }

            dataGridView2.DataSource = dataTable;

        }
        private void loaddate4()
        {

            DataTable dataTable = new DataTable();
            string sqlQuery = "SELECT * FROM orderrequestss WHERE status IN ('assigned', 'on progress', 'completed')";


            using (SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }

            dataGridView2.DataSource = dataTable;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateEmployeeNamesComboBox();
        }
        private void PopulateEmployeeNamesComboBox()
        {
            string sqlQuery = "SELECT username FROM AllUserss WHERE role = 'Worker'";
            using (SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader["username"].ToString();
                        comboBox1.Items.Add(name);
                    }
                    reader.Close();
                }
            }
        }

        private void Btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Open database connection
                con.Open();

                // Create SQL command to search for the user
                string sqlQuery = "SELECT * FROM AllUserss WHERE  username= @username";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    // Add parameter for username
                    cmd.Parameters.AddWithValue("@username", textBox2.Text);

                    // Execute SQL command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Check if any rows were returned
                    if (reader.Read())
                    {
                        // User found, populate TextBoxes with user information

                        textBox5.Text = reader["fullname"].ToString();
                        textBox6.Text = reader["phonenumber"].ToString();
                        textBox4.Text = reader["username"].ToString();
                        textBox3.Text = reader["password"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("User not found. Please register.");
                        // Optionally, clear TextBoxes or perform any other actions if the user is not found
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the database connection is always closed
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void BTNUPDATEFORM_Click(object sender, EventArgs e)
        {
            try
            {
                int phoneNumber = Convert.ToInt32(textBox6.Text);
                int password = Convert.ToInt32(textBox3.Text);
                // Open database connection
                con.Open();

                // Create SQL command with parameters for update
                string sqlQuery = "UPDATE AllUserss SET fullname = @fullname, phonenumber = @phonenumber, username = @newusername, password = @password WHERE username = @oldusername";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    // Add parameter values

                    cmd.Parameters.AddWithValue("@oldusername", textBox2.Text);
                    cmd.Parameters.AddWithValue("@fullname", textBox5.Text);
                    cmd.Parameters.AddWithValue("@phonenumber", textBox6.Text);
                    cmd.Parameters.AddWithValue("@newusername", textBox4.Text);
                    cmd.Parameters.AddWithValue("@password", textBox3.Text);



                    // Execute SQL command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User updated successfully");
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox4.Clear();
                        textBox3.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Not updated check again");
                    }


                }
                con.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the database connection is always closed
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            //  panel2.Visible = false;
            panel3.Visible = false;
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            // loaddate2();
            // loaddata3();

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*

            // Retrieve values from text boxes
            string fullname = textBox8.Text;
            string phonenumber = textBox11.Text;
            string username = textBox9.Text;
            string password = textBox10.Text;
            string oldUsername = textBox7.Text;

            // Check if all fields are filled
            if (string.IsNullOrWhiteSpace(fullname) ||
                string.IsNullOrWhiteSpace(phonenumber) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(oldUsername))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                int phoneNumber = Convert.ToInt32(phonenumber);
                int passwordInt = Convert.ToInt32(password);

                // Open database connection
                using (SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;"))
                {
                    con.Open();

                    // Update SQL database where username matches oldUsername
                    string updateUserInfoQuery = "UPDATE AllUserss SET fullname = @fullname, phonenumber = @phonenumber, username = @username, password = @password, role = @role WHERE username = @oldUsername";
                    using (SqlCommand cmd = new SqlCommand(updateUserInfoQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@fullname", fullname);
                        cmd.Parameters.AddWithValue("@phonenumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", passwordInt);
                        cmd.Parameters.AddWithValue("@role", "Manager");
                        cmd.Parameters.AddWithValue("@oldUsername", oldUsername);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User updated successfully");
                            textBox7.Text = textBox9.Text;


                        }
                        else
                        {
                            MessageBox.Show("No user updated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            */
            string connectionString = "Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;";
            UserUpdate updater = new UserUpdate(connectionString);

            // Get values from UI controls
            string fullName = textBox8.Text;
            string phoneNumber = textBox11.Text;
            string userName = textBox9.Text;
            string password = textBox10.Text;
            string role = "Manager";
            string existingUsername = textBox7.Text;

            // Call the UpdateUser method
            updater.UpdateUser(fullName, phoneNumber, userName, password, role, existingUsername);

            textBox7.Text = textBox9.Text;

        }


        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 a = new Form1();
            a.Show();
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void UpdateCustomerName(string oldCustomerName, string newCustomerName)
        {
            string connectionString = ("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;");

            // Step 1: Update customername in allUserss table
            string updateQuery = "UPDATE allUserss SET username = @NewCustomerName WHERE username = @OldCustomerName";



            if (string.IsNullOrWhiteSpace(newCustomerName) || string.IsNullOrWhiteSpace(oldCustomerName))
            {
                MessageBox.Show("Please fill in all the required fields.");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NewCustomerName", newCustomerName);
                        command.Parameters.AddWithValue("@OldCustomerName", oldCustomerName);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            // Step 2: Verify the update in allUserss table
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Name updated successfully.");
                                //Session.Username = newCustomerName;


                                // Step 3: No need to check customername in orderrequestss table
                                // The foreign key constraint with CASCADE UPDATE should handle it automatically
                            }
                            else
                            {
                                // MessageBox.Show("Customer name update failed. No rows affected.");
                            }
                            textBox7.Text = textBox9.Text;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating customer name: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            dataGridView2.Update();
        }
        /*
        private void loaddata3()
        {
            DataTable dataTable = new DataTable();
            string sqlQuery = "SELECT * FROM orderrequestss ";

            using (SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }

            dataGridView2.DataSource = dataTable;
            // dataGridView2.Refresh();
        }
        */
        private void allrequest_Click(object sender, EventArgs e)
        {
            loaddate4();
        }

        private void newrequees_Click(object sender, EventArgs e)
        {
            loaddate2();
        }
        private void button10()
        {
            try
            {
                // Open database connection
                con.Open();

                // Create SQL command to search for the user
                string sqlQuery = "SELECT * FROM AllUserss WHERE  username= @usernamee";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    // Add parameter for username
                    cmd.Parameters.AddWithValue("@usernamee", textBox7.Text);

                    // Execute SQL command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Check if any rows were returned
                    if (reader.Read())
                    {
                        // User found, populate TextBoxes with user information

                        textBox8.Text = reader["fullname"].ToString();
                        textBox11.Text = reader["phonenumber"].ToString();
                        textBox9.Text = reader["username"].ToString();
                        textBox10.Text = reader["password"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("User not found. Please register.");
                        // Optionally, clear TextBoxes or perform any other actions if the user is not found
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the database connection is always closed
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void btnassign_Click(object sender, EventArgs e)

        {
            string orderId = textBox1.Text;

            // Get the assigned name from the ComboBox

            string assignedName = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(assignedName))
            {
                MessageBox.Show("Please select an item from the ComboBox.");
                return;
            }
            string connectionString = "Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True";
            string checkStatusQuery = "SELECT COUNT(*) FROM orderrequestss WHERE orderid = @OrderId AND status = 'new'";
            string updateQuery = "UPDATE orderrequestss SET assigned = @AssignedName, status = @status WHERE orderid = @OrderId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the status is new
                using (SqlCommand checkCommand = new SqlCommand(checkStatusQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@OrderId", orderId);
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count <= 0)
                    {
                        MessageBox.Show("Status is not new. Cannot assign.");
                        return;
                    }
                }

                // If status is new, update the status to assigned
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@AssignedName", assignedName);
                    updateCommand.Parameters.AddWithValue("@OrderId", orderId);
                    updateCommand.Parameters.AddWithValue("@status", "assigned");

                    try
                    {
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Updated successfully.");
                            // Refresh the DataGridView by reloading the data
                            loaddate2(); // Assuming this method loads data into dataGridView3
                                         // loaddata3(); // Assuming this method loads data into dataGridView2
                        }
                        else
                        {
                            MessageBox.Show("Wrong order ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating database: " + ex.Message);
                    }
                }

            }


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.ReadOnly = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;";
            UserUpdate updater = new UserUpdate(connectionString);

            // Get values from UI controls
            string fullName = textBox8.Text;
            string phoneNumber = textBox11.Text;
            string userName = textBox9.Text;
            string password = textBox10.Text;
            string role = "Manager";
            string existingUsername = textBox7.Text;

            // Call the UpdateUser method
            updater.UpdateUser(fullName, phoneNumber, userName, password, role, existingUsername);

            textBox7.Text = textBox9.Text;
        }
    }
}


