using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Register : Form
    {
        SqlConnection conn;
        SqlDataReader reader;
        SqlCommand cmd;
        public Register()
        {
            InitializeComponent();
        }



        private void Register_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\Apps\Windows\WinFormsApp1\WinFormsApp1\Database1.mdf;Integrated Security=True");
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String Password = textBox2.Text;
            if (username != String.Empty || Password != String.Empty)
            {
                cmd = new SqlCommand("select * from VerificationTable where username='" + username + "'", conn);
                reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    reader.Close();
                    MessageBox.Show("Username already exists!");
                }
                else
                {
                    reader.Close();
                    cmd = new SqlCommand("insert into VerficationTable values(@username, @password)", conn);
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", Password);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created!");

                    this.Hide();
                    login login = new login();
                    login.ShowDialog();
                }
            }


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }
    }
}
