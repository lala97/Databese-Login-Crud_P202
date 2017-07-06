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
namespace Login_P202
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lala.M\Documents\P202.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string pass = txt_pass.Text;

            conn.Open();
            if (conn.State==ConnectionState.Open)
            {
                string query = "SELECT * FROM Admin where username='" + username + "' and  password='" + pass + "'";
                //  MessageBox.Show(query.ToString());

                SqlCommand command = new SqlCommand(query, conn);
              
                SqlDataReader readQuery = command.ExecuteReader();
                if (readQuery.HasRows)
                {
                    while (readQuery.Read())
                    {
                        //  MessageBox.Show(readQuery["password"].ToString());
                        Home home_form = new Home();
                        this.Hide();
                        home_form.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Bele bir data yoxdur");
                }
               
             }
         }
    }
}
