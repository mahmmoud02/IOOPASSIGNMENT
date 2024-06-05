using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace final_project_2._0
{
    public partial class Form1 : Form
    {
        private UserManager userManager = new UserManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {
            string Username = Txtusername.Text;
            int password;

            // Check if the input password can be parsed as an integer
            if (int.TryParse(TxtPassword.Text, out password))
            {
                string role = userManager.GetUserRole(Username, password.ToString());

                if (role != null)
                {
                    Session.Username = Username;
                    switch (role)
                    {

                        case "Admin":
                            MessageBox.Show("Welcome " + Username);
                            this.Hide();
                            AdminMainDashboard dashboard = new AdminMainDashboard();
                            dashboard.Show();


                            break;
                        case "Customer":
                            MessageBox.Show("Welcome " + Username);
                            this.Hide();
                           CustomerMainDashboard customer = new CustomerMainDashboard();
                            customer.Show();
                            break;

                        // Add more cases for other roles
                        case "Manager":
                            MessageBox.Show("Welcome " + Username);
                            this.Hide();
                            ManagerMainDashboard manager = new ManagerMainDashboard();
                            manager.Show();
                            break;

                        case "Worker":
                            MessageBox.Show("Welcome " + Username);
                            this.Hide();
                            WorkerMaindashboard worker = new WorkerMaindashboard();
                            worker.Show();
                            break;


                        default:
                            MessageBox.Show("Welcome " + Username);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            else
            {
                MessageBox.Show("Invalid password format. Password should be an integer.");
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Txtusername.Clear();
            TxtPassword.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    public static class Session
    {
        public static string Username { get; set; }
    }
}
