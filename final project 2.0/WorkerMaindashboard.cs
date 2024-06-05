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
    public partial class WorkerMaindashboard : Form
    {
        SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;");
        SqlCommand cmd;

        public WorkerMaindashboard()
        {
            InitializeComponent();
            
            //label18.Text = Session.Username;
            textBox7.Text = Session.Username;
            button11();
            loaddate3();
        }
        private void Btnupdate_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel3.Visible = false;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                // Get the order ID from the clicked row
                object orderId = dataGridView2.Rows[e.RowIndex].Cells["orderid"].Value;

                // Update the TextBox with the order ID
                if (orderId != null)
                {
                    textBox1.Text = orderId.ToString();
                }
            }
           loaddate3();

        }
       

        private void btnassign_Click(object sender, EventArgs e)
        {
            /*
            try
            {

                con.Open();
                SqlCommand command = new SqlCommand("UPDATE orderrequestss SET status=@status WHERE orderid = @OrderId", con);

                command.Parameters.AddWithValue("@OrderId", textBox1.Text);
                command.Parameters.AddWithValue("@status", comboBox1.Text);
                command.ExecuteNonQuery();

                MessageBox.Show(" Task Status successfully ");
                loaddate3();





            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();

            }
            
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE orderrequestss SET status=@status WHERE orderid = @OrderId", con);

                command.Parameters.AddWithValue("@OrderId", textBox1.Text);
                command.Parameters.AddWithValue("@status", comboBox1.Text);
                command.ExecuteNonQuery();

                MessageBox.Show("Task Status updated successfully");
                loaddate3();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            */
            string connectionString = "Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;"; 
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("UPDATE orderrequestss SET status=@status WHERE orderid = @OrderId", con);
                    command.Parameters.AddWithValue("@OrderId", textBox1.Text);
                    command.Parameters.AddWithValue("@status", comboBox1.Text);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Task Status updated successfully");
                    loaddate3();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                //loaddate3();
            }


        }

        private void WorkerMaindashboard_Load(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel3.Visible = false;
        }

        private void Btncheck_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                // Open database connection
                con.Open();

                // Create SQL command to search for the user
                string sqlQuery = "SELECT * FROM AllUserss WHERE  username= @username";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    // Add parameter for username
                    cmd.Parameters.AddWithValue("@username", textBox7.Text);

                    // Execute SQL command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Check if any rows were returned
                    if (reader.Read())
                    {
                        // User found, populate TextBoxes with user information

                        // textBox7.Text = reader["fullname"].ToString();
                        textBox8.Text = reader["fullname"].ToString();
                        textBox11.Text = reader["phonenumber"].ToString();
                        textBox9.Text = reader["username"].ToString();
                        textBox10.Text = reader["password"].ToString();


                    }
                    else
                    {
                        MessageBox.Show("User not found. Please ask admin to register .");
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
            */
            


        }
        private void button11()
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
            loaddate3();
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
                        cmd.Parameters.AddWithValue("@role", "Worker");
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
            string role = "Worker";
            string existingUsername = textBox7.Text;

            // Call the UpdateUser method
            updater.UpdateUser(fullName, phoneNumber, userName, password, role, existingUsername);

            //string connectionString1= "your_connection_string_here";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open(); // Open the connection before executing the command

                string sqlQuery = "UPDATE orderrequestss SET assigned = @assigned WHERE assigned = @existingUsernamee";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.AddWithValue("@assigned", textBox9.Text);
                    cmd.Parameters.AddWithValue("@existingUsernamee", textBox7.Text); // Set existingUsername to the username you want to update



                    loaddate3();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // MessageBox.Show("User updated successfully");
                       string  updatedname = textBox9.Text;
                        
                    }
                    else
                    {
                        MessageBox.Show("No user found with the specified username");
                    }
                }

                con.Close(); // Close the connection after executing the command
            }

            textBox7.Text = textBox9.Text;
            loaddate3();



        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.Show();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
            dataGridView2.ReadOnly = true;
            loaddate3();



        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //loaddate3();
        }
        private void loaddate3()
        {
            try
            {
                string username = Session.Username;
                username = textBox7.Text;
                // Open database connection
                con.Open();
                // Create SQL command to search for the user
                string sqlQuery = "SELECT * FROM orderrequestss WHERE assigned = @assigned AND status IN ('assigned', 'on progress')";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    // Add parameter for username
                    cmd.Parameters.AddWithValue("@assigned", username);

                    // Execute SQL command and load data into a DataTable
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Clear any existing data in the DataTable
                            DataTable dataTable = (DataTable)dataGridView2.DataSource;
                            if (dataTable != null)
                            {
                                dataTable.Clear();
                            }
                            else
                            {
                                dataTable = new DataTable();
                            }
                           

                            // Load data into the DataTable
                            dataTable.Load(reader);
                            //Session.Username =textBox7.Text;
                            // Bind the DataTable to the DataGridView
                            dataGridView2.DataSource = dataTable;
                            // Optionally, populate TextBox with the first row's orderid value
                            if (dataTable.Rows.Count > 0)
                                textBox1.Text = dataTable.Rows[0]["orderid"].ToString();


                        }
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.ReadOnly = true;
        }
    }

}
    

   

