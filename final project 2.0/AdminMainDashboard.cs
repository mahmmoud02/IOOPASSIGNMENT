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

namespace final_project_2._0
{
    public partial class AdminMainDashboard : Form
    {
        SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;");
        SqlCommand cmd;

        SqlDataAdapter adpt;
        DataTable dt;
        // DataAccess dataAccess = new DataAccess();




        public AdminMainDashboard()
        {



            InitializeComponent();
            loadnames();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void AdminMainDashboard_Load(object sender, EventArgs e)
        {
            //label6.Text = ("WELCOME BACK " + Session.Username);
            panel4.Visible = true;
            panel1.Visible = false;

           




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
                    cmd.Parameters.AddWithValue("@username", comboBox2.Text);

                    // Execute SQL command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Check if any rows were returned
                    if (reader.Read())
                    {
                        // User found, populate TextBoxes with user information

                        Txtfullname.Text = reader["fullname"].ToString();
                        Txtfullname.Text = reader["fullname"].ToString();
                        textBox2.Text = reader["phonenumber"].ToString();
                        Txtusername.Text = reader["username"].ToString();
                        Txtpassword.Text = reader["password"].ToString();
                        Txtcombobox.Text = reader["role"].ToString();
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

        private void Btnregister_Click(object sender, EventArgs e)
        {
            
            try
            {
                // Check if all fields are filled
                if (string.IsNullOrWhiteSpace(Txtfullname.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(Txtusername.Text) ||
                    string.IsNullOrWhiteSpace(Txtpassword.Text) ||
                    string.IsNullOrWhiteSpace(Txtcombobox.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Convert phone number and password to integers
                int phoneNumber = Convert.ToInt32(textBox2.Text);
                int password = Convert.ToInt32(Txtpassword.Text);

                // Open database connection
                con.Open();

                // Create SQL command with parameters
                string sqlQuery = "INSERT INTO AllUserss (fullname, phonenumber, username, password, role) VALUES (@fullname, @phonenumber, @username, @password, @role)";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    // Add parameter values
                    cmd.Parameters.AddWithValue("@fullname", Txtfullname.Text);
                    cmd.Parameters.AddWithValue("@phonenumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@username", Txtusername.Text);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", Txtcombobox.Text);

                    // Execute SQL command
                    cmd.ExecuteNonQuery();
                }

                // Close database connection
                con.Close();

                // Display success message
                MessageBox.Show("User saved successfully");
                Txtfullname.Clear();
                textBox2.Clear();
                Txtusername.Clear();
                Txtpassword.Clear();
                Txtcombobox.Text = "";
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
            /*
            try
            {
                // Check if all fields are filled
                if (string.IsNullOrWhiteSpace(Txtfullname.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(Txtusername.Text) ||
                    string.IsNullOrWhiteSpace(Txtpassword.Text) ||
                    string.IsNullOrWhiteSpace(Txtcombobox.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                int phoneNumber = Convert.ToInt32(textBox2.Text);
                int password = Convert.ToInt32(Txtpassword.Text);

                // Open database connection
                con.Open();

                string sqlQuery = "UPDATE AllUserss SET fullname = @fullname, phonenumber = @phonenumber, username = @username, password = @password, role = @role WHERE username = @username1";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username1", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@fullname", Txtfullname.Text);
                    cmd.Parameters.AddWithValue("@phonenumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@username", Txtusername.Text);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", Txtcombobox.Text);

                    if (cmd.Parameters["@username"].Value.ToString() != "Admin1")
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {

                            MessageBox.Show("User updated successfully");
                            Txtfullname.Clear();
                            textBox2.Clear();
                            Txtusername.Clear();
                            Txtpassword.Clear();
                            Txtcombobox.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("No user found with the specified ID");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot update the Admin1");
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            */
            string connectionString = "Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;";
            UserUpdate updater = new UserUpdate (connectionString);

            // Get values from UI controls
            string fullName = Txtfullname.Text;
            string phoneNumber = textBox2.Text;
            string userName = Txtusername.Text;
            string password = Txtpassword.Text;
            string role = Txtcombobox.Text;
            string existingUsername = comboBox2.Text;

            // Call the UpdateUser method
            updater.UpdateUser(fullName, phoneNumber, userName, password, role, existingUsername);
            comboBox2.Text = " ";
            Txtfullname.Clear();
            textBox2.Clear();
            Txtusername.Clear();
            Txtpassword.Clear();
            Txtcombobox.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboBox2.Text = " ";
            Txtfullname.Clear();
            textBox2.Clear();
            Txtusername.Clear();
            Txtpassword.Clear();
            Txtcombobox.Text = "";
        }

        private void Btnregisterusers_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = false;
            
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btnyearlyreport_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel4.Visible = false;
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type = comboBox1.Text;
            switch (type)
            {

                case "Customer Report":
                  
                    int selectedMonth = dateTimePicker4.Value.Month;

                    // SQL query to fetch the data
                    string query = @"
            SELECT 
                customername AS CustomerName,
                COUNT(*) AS TotalRequests,
                SUM(total) AS TotalPaid
            FROM 
                orderrequestss
            WHERE 
                DATEPART(month, orderdate) = @SelectedMonth
            GROUP BY 
                customername;";

                    // Execute the query and bind the results to the DataGridView
                    using (SqlConnection conn = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;"))
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@SelectedMonth", selectedMonth);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();

                        try
                        {
                            conn.Open();
                            adapter.Fill(dataTable);
                            dataGridView4.DataSource = dataTable;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("An error occurred while fetching data: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }


                      




                    }



                    break;
                case "Yearly Report":
                   
                    
                    int selectedYear = dateTimePicker4.Value.Year;

                    // SQL query to retrieve total sold for each month of the selected year
                    string query1 = @"
        WITH Months AS (
            SELECT 1 AS MonthNumber
            UNION SELECT 2
            UNION SELECT 3
            UNION SELECT 4
            UNION SELECT 5
            UNION SELECT 6
            UNION SELECT 7
            UNION SELECT 8
            UNION SELECT 9
            UNION SELECT 10
            UNION SELECT 11
            UNION SELECT 12
        )
        SELECT 
            m.MonthNumber AS Month,
            COALESCE(SUM(o.total), 0) AS TotalSold
        FROM 
            Months m
        LEFT JOIN 
            orderrequestss o ON MONTH(o.orderdate) = m.MonthNumber AND YEAR(o.orderdate) = @SelectedYear
        GROUP BY 
            m.MonthNumber
        ORDER BY 
            m.MonthNumber;";

                    // Execute the query and populate the DataGridView
                    using (SqlConnection conn = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;"))
                    {
                        SqlCommand cmd = new SqlCommand(query1, conn);
                        cmd.Parameters.AddWithValue("@SelectedYear", selectedYear);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();

                        try
                        {
                            conn.Open();
                            adapter.Fill(dataTable);
                            dataGridView4.DataSource = dataTable;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("An error occurred while fetching data: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }



                    
                    break;
                case "Service Report":
                    
            int selectedMonth1= dateTimePicker4.Value.Month;

            // SQL query to fetch the data
            string query4 = @"
            SELECT 
               servicetype AS ServiceType,
    COUNT(*) AS TotalRequests,
    SUM(total) AS TotalIncome
            FROM 
                orderrequestss
            WHERE 
                DATEPART(month, orderdate) = @SelectedMonth
            GROUP BY 
                ServiceType;";

            // Execute the query and bind the results to the DataGridView
            using (SqlConnection conn = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;"))
            {
                SqlCommand cmd = new SqlCommand(query4, conn);
                cmd.Parameters.AddWithValue("@SelectedMonth", selectedMonth1);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dataTable);
                    dataGridView4.DataSource = dataTable;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred while fetching data: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
                    


                    
                    break;
                default:
                    MessageBox.Show(" enter valid report type");
                    break;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

            
            private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)//yearly report
        {
          
        }


        private void txtJanuaryTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//
        {
          
        }

        public (int totalRequests, decimal totalPaid) GetServiceData(int month, int year, string serviceType)
        {
            int totalRequests = 0;
            decimal totalPaid = 0;
            string connString = "Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                string sql = @"
                    SELECT 
                        COUNT(*) AS TotalRequests, 
                        SUM(total) AS TotalPaid 
                    FROM 
                        orderrequestss 
                    WHERE 
                        MONTH(orderdate) = @Month 
                        AND YEAR(orderdate) = @Year
                        AND ServiceType = @ServiceType";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);
                command.Parameters.AddWithValue("@ServiceType", serviceType);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    totalRequests = reader.GetInt32(0);
                    totalPaid = reader.GetDecimal(1);
                }
            }

            return (totalRequests, totalPaid);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.Show();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnusersearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadnames();
        }
        private void loadnames()
        {
            SqlConnection con = new SqlConnection("Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=finalproject;Integrated Security=True;");

            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from AllUserss";

            // Initialize the SqlDataAdapter object with the SqlCommand object
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["username"].ToString());
            }

            con.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

