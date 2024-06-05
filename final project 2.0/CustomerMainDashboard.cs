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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace final_project_2._0
{
    public partial class CustomerMainDashboard : Form

    {
        SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;");
        SqlCommand cmd;
        private PrintingService pr = new PrintingService();

        public CustomerMainDashboard()
        {
            InitializeComponent();
            richTextBox1.Visible = false;
            LoadData();
            txtcustomername.Text = Session.Username;
            textBox1.Text = Session.Username;

            txtcustomername.ReadOnly = true;
            textBox1.Text = Session.Username;
            panel2.Visible = true;
            panel5.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel1.Visible = true;
            textBox6.Text = Session.Username;
            //label18.Text = Session.Username;

            button2();
            search2();





        }
        private void LoadData()
        {
            // Create a new SqlConnection object and use it in a using statement
            using (SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM services", con);

                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    dataGridView2.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.ReadOnly = true;
            LoadData();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                txtserviceid.Text = row.Cells["serviceid"].Value.ToString();
                txtservicetype.Text = row.Cells["ServiceType"].Value.ToString();
                txtsize.Text = row.Cells["size"].Value.ToString();
                txtfees.Text = row.Cells["fees_per_unit"].Value.ToString();
                txtdiscount.Text = row.Cells["Discount_as_percent"].Value.ToString();

                // Make text boxes uneditable
                txtserviceid.ReadOnly = true;
                txtservicetype.ReadOnly = true;
                txtsize.ReadOnly = true;
                txtfees.ReadOnly = true;
                txtdiscount.ReadOnly = true;
            }
        }

        private void btncalculate_Click(object sender, EventArgs e)
        {
            string serviceType = txtservicetype.Text;
            int pages;
            if (int.TryParse(Txtpages.Text, out int pageCount))
                pages = pageCount;
            else
            {
                MessageBox.Show("Invalid page count. Please enter a valid number.");
                return;
            }

            string size = txtsize.Text;
            double feesPerUnit = double.Parse(txtfees.Text);
            int discount;
            if (int.TryParse(txtdiscount.Text, out int discountValue))
                discount = discountValue;
            else
                discount = 0;
            bool isUrgent = checkBox1.Checked;

            PrintingService printingService = new PrintingService
            {
                ServiceType = serviceType,
                size = size,
                FeesPerUnit = feesPerUnit,
                DiscountPercentage = discount,
                IsUrgent = isUrgent,
                Pages = pages
            };

            double totalPrice = printingService.CalculateTotalPrice();
            Txttotal.Text = totalPrice.ToString();

        }

        private void Btntrackorder_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel3.Visible = true;
            panel2.Visible = false;
            panel4.Visible = true;
            panel1.Visible = true;

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btnsearch_Click(object sender, EventArgs e)
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
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);

                    // Execute SQL command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Check if any rows were returned
                    if (reader.Read())
                    {
                        // User found, populate TextBoxes with user information

                        textBox5.Text = reader["fullname"].ToString();
                        textBox2.Text = reader["phonenumber"].ToString();
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
            */
        }

        private void BTNUPDATEFORM_Click(object sender, EventArgs e)
        {
            /*
            // Retrieve values from text boxes
            string fullname = textBox5.Text;
            string phonenumber = textBox2.Text;
            string username = textBox4.Text;
            string password = textBox3.Text;
            string oldUsername = textBox1.Text;

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
                        cmd.Parameters.AddWithValue("@role", "Customer");
                        cmd.Parameters.AddWithValue("@oldUsername", oldUsername);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User updated successfully");
                            textBox1.Text = textBox4.Text;
                            txtcustomername.Text = textBox4.Text;
                            textBox6.Text = textBox4.Text;
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
            string fullName = textBox5.Text;
            string phoneNumber = textBox2.Text;
            string userName = textBox4.Text;
            string password = textBox3.Text;
            string role = "Customer";
            string existingUsername = textBox1.Text;

            // Call the UpdateUser method
            updater.UpdateUser(fullName, phoneNumber, userName, password, role, existingUsername);
            textBox1.Text = textBox4.Text;
            txtcustomername.Text = textBox4.Text;
            textBox6.Text = textBox4.Text;



            search2();


        }

        private void Btnrequest_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel5.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel1.Visible = true;
        }

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel5.Visible = true;
            panel3.Visible = false;
            panel4.Visible = true;
            panel1.Visible = true;
        }

        private void btnssearch_Click(object sender, EventArgs e)
        {
            /*
            using (SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;"))
            {
                con.Open();

                string sqlQuery = "SELECT * FROM orderrequestss WHERE customername = @username";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        MessageBox.Show("User not found.");
                    }
                }
            }
            */
        }


        private void Btnsubmit_Click(object sender, EventArgs e)
        {
            /*
                        string customername = txtcustomername.Text; ;
                        DateTime requesteddate = dateTimePicker1.Value;
                        int serviceid = Convert.ToInt32(txtserviceid.Text);
                        string servicetype = txtservicetype.Text;
                        //  int pages = Convert.ToInt32(Txtpages.Text);
                        int pages;
                        if (!int.TryParse(Txtpages.Text, out pages))
                        {
                            MessageBox.Show("Please enter a valid integer value for pages.");
                            return;
                        }
                        string size = txtsize.Text;
                        decimal fees_per_unit = Convert.ToDecimal(txtfees.Text);
                        int discount = 0;
                        if (!string.IsNullOrWhiteSpace(txtdiscount.Text))
                        {
                            // If txtdiscount.Text is not empty, attempt to convert it to a double
                            pages = Convert.ToInt32(txtdiscount.Text);
                        }
                        bool urgent = checkBox1.Checked;
                        decimal total = Convert.ToDecimal(Txttotal.Text);
            */
            // Retrieve and validate customer name
            string customername = txtcustomername.Text;

            // Retrieve requested date
            DateTime requesteddate = dateTimePicker1.Value;

            // Retrieve and validate service ID
            int serviceid;
            if (!int.TryParse(txtserviceid.Text, out serviceid))
            {
                MessageBox.Show("Please enter a valid integer value for Service ID.");
                return;
            }

            // Retrieve service type
            string servicetype = txtservicetype.Text;

            // Validate pages
            int pages;
            if (!int.TryParse(Txtpages.Text, out pages))
            {
                MessageBox.Show("Please enter a valid integer value for pages.");
                return;
            }

            // Retrieve size
            string size = txtsize.Text;

            // Validate fees per unit
            decimal fees_per_unit;
            if (!decimal.TryParse(txtfees.Text, out fees_per_unit))
            {
                MessageBox.Show("Please enter a valid decimal value for fees per unit.");
                return;
            }

            // Initialize discount
            int discount = 0;

            // Validate and convert discount if provided
            if (!string.IsNullOrWhiteSpace(txtdiscount.Text))
            {
                if (!int.TryParse(txtdiscount.Text, out discount))
                {
                    MessageBox.Show("Please enter a valid integer value for discount.");
                    return;
                }
            }

            // Check if the service is marked as urgent
            bool urgent = checkBox1.Checked;

            // Validate and convert total
            decimal total;
            if (!decimal.TryParse(Txttotal.Text, out total))
            {
                MessageBox.Show("Please calculate the total first.");
                return;
            }


            InsertData(customername, requesteddate, serviceid, servicetype, pages, size, fees_per_unit, discount, urgent, total);
        }
        private void InsertData(String customername, DateTime requesteddate, int serviceid, string servicetype, int pages, string size, decimal fees_per_unit, int discount, bool urgent, decimal total)
        {
            string query = "INSERT INTO orderrequestss (customername, orderdate, serviceid,servicetype, pages, size, fees, discount, urgent, total,status,assigned) " +
                           "VALUES (@username, @orderdate, @serviceid, @servicetype, @pages, @size, @fees, @discount, @urgent, @total,@status,@assigned)";

            using (SqlConnection connection = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;"))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", customername);
                command.Parameters.AddWithValue("@orderdate", requesteddate);
                command.Parameters.AddWithValue("@serviceid", serviceid);


                command.Parameters.AddWithValue("@servicetype", servicetype);
                command.Parameters.AddWithValue("@pages", pages);
                command.Parameters.AddWithValue("@size", size);
                command.Parameters.AddWithValue("@fees", fees_per_unit);
                command.Parameters.AddWithValue("@discount", discount);
                command.Parameters.AddWithValue("@urgent", urgent);
                command.Parameters.AddWithValue("@total", total);
                command.Parameters.AddWithValue("@status", "new ");
                command.Parameters.AddWithValue("@assigned", DBNull.Value);



                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show($"Order Placed Successfully");
                    search2();
                    // txtcustomername.Clear();
                    dateTimePicker1.Text = "";
                    txtserviceid.Clear();
                    txtservicetype.Clear();
                    Txtpages.Clear();
                    txtsize.Clear();
                    txtfees.Clear();
                    txtdiscount.Clear();
                    Txttotal.Clear();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void txtserviceid_TextChanged(object sender, EventArgs e)
        {
            txtserviceid.ReadOnly = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = true;
            search2();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        private void txtcustomername_TextChanged(object sender, EventArgs e)
        {
            txtcustomername.ReadOnly = true;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 ab = new Form1();
            ab.ShowDialog();

        }

        private void label18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WELCOME BACK " + Session.Username);
        }








        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // txtcustomername.Text = textBox4.Text;
          //  richTextBox1.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // textBox6.Text= textBox4.Text;
        }

        private void Txttotal_TextChanged(object sender, EventArgs e)
        {
            Txttotal.ReadOnly = true;
        }

        private void txtfees_TextChanged(object sender, EventArgs e)
        {
            txtfees.ReadOnly = true;
        }

        private void txtsize_TextChanged(object sender, EventArgs e)
        {
            txtsize.ReadOnly = true;
        }

        private void txtservicetype_TextChanged(object sender, EventArgs e)
        {
            txtservicetype.ReadOnly = true;
        }

        private void Txtpages_TextChanged(object sender, EventArgs e)
        {

        }

        private void receipt_Click(object sender, EventArgs e)
        {

            richTextBox1.Visible = true; // Ensure RichTextBox is visible

            richTextBox1.Text = "***********************Receipt**********\n";
            richTextBox1.Text += "Customer Name: " + txtcustomername.Text + "\n";
            richTextBox1.Text += "Service Type: " + txtservicetype.Text + "\n";
            richTextBox1.Text += "Pages: " + Txtpages.Text + "\n";
            richTextBox1.Text += "Size: " + txtsize.Text + "\n";
            richTextBox1.Text += "Fees: " + txtfees.Text + "\n";

            richTextBox1.Text += "Discount: " + txtdiscount.Text + "\n";
            richTextBox1.Text += "Total: " + Txttotal.Text + "\n";
            richTextBox1.Text += "***************************************";


        }
        private void search2()
        {

            using (SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;"))
            {
                con.Open();

                string sqlQuery = "SELECT * FROM orderrequestss WHERE customername = @username";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        // MessageBox.Show("User not found.");
                    }
                }
            }

        }
        private void button2()
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
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);

                    // Execute SQL command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Check if any rows were returned
                    if (reader.Read())
                    {
                        // User found, populate TextBoxes with user information

                        textBox5.Text = reader["fullname"].ToString();
                        textBox2.Text = reader["phonenumber"].ToString();
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

        private void CustomerMainDashboard_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.ReadOnly = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
          // richTextBox1.Show();
            richTextBox1.Text = "***********************Receipt****************\n";
            richTextBox1.Text += "Customer Name: " + txtcustomername.Text + "\n";
            richTextBox1.Text += "Service Type: " + txtservicetype.Text + "\n";
            richTextBox1.Text += "Pages: " + Txtpages.Text + "\n";
            richTextBox1.Text += "Size: " + txtsize.Text + "\n";
            richTextBox1.Text += "Fees(RM): " + txtfees.Text + "\n";


            richTextBox1.Text += "Discount: " + txtdiscount.Text + "\n";
            richTextBox1.Text += "Total: " + Txttotal.Text + "\n";
            richTextBox1.Text += "***********************************************";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            dateTimePicker1.Text = "";
            txtserviceid.Clear();
            txtservicetype.Clear();
            Txtpages.Clear();
            txtsize.Clear();
            txtfees.Clear();
            txtdiscount.Clear();
            Txttotal.Clear();
        }
    }
}

