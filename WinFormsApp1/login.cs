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

namespace WinFormsApp1
{
    public partial class login : Form
    {
        SqlConnection conn;
        SqlDataReader reader;
        SqlCommand cmd;

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            MessageBox.Show("Hello " + username + "\nLogged in successfully!");
            if (username != String.Empty || password != String.Empty )
            {
                cmd = new SqlCommand("select * from VerificationTable where username='" + username + "' and password='" + password + "';", conn);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    MessageBox.Show("Login Successful!");
                }
                else
                {
                    reader.Close();
                    MessageBox.Show("Incorrect credentials, Try again");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void login_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\Apps\Windows\WinFormsApp1\WinFormsApp1\Database1.mdf;Integrated Security=True");
            conn.Open();
        }
    }
}
