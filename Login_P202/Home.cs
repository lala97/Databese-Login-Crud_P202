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
    public partial class Home : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lala.M\Documents\P202.mdf;Integrated Security=True;Connect Timeout=30");
       

        public Home()
        {
            InitializeComponent();
            getAdminData();
            conn.Open();

        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            string insert_username = txt_username.Text;
            string insert_pass = txt_password.Text;

            string query = "INSERT INTO Admin(username,password) VALUES('" + insert_username + "','" + insert_pass + "')";
           
            SqlCommand command = new SqlCommand(query, conn);
            int netice=  command.ExecuteNonQuery();
            if (netice>0)
            {
                getAdminData();
            }
        }


        private void getAdminData()
        {
            string query = "select * from Admin";
            SqlCommand command = new SqlCommand(query, conn);

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable table = new DataTable();

            da.Fill(table);
            gridAdmin.DataSource = table;

        }

        private void gridAdmin_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt_delete_id.Text= gridAdmin.Rows[e.RowIndex].Cells[0].Value.ToString();
            //  MessageBox.Show("id="+ txt_delete_id.Text);          
        }


        private void btn_delete_Click_1(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txt_delete_id.Text);
            string query = "Delete from Admin where id='" + id + "'";
            SqlCommand command = new SqlCommand(query, conn);

            int netice = command.ExecuteNonQuery();
            if (netice > 0)
            {
                getAdminData();
            }
        }
    }
}
