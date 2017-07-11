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
using System.Data;

namespace WindowsFormsApplication1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter SA = new SqlDataAdapter();
                using (var con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\ocrwebservice\WindowsFormsApplication1\WindowsFormsApplication1\LoginDB.mdf;Integrated Security=True"))
                {
                    SqlCommand cmd = new SqlCommand("insert into Login(Name,Email,Password) values(@Name,@Email,@Password);", con);
                    SA.InsertCommand = cmd;
                    con.Open();
                    SA.InsertCommand.Parameters.AddWithValue("@Name", NameTxt.Text);
                    SA.InsertCommand.Parameters.AddWithValue("@Email", EmailTxt.Text);
                    SA.InsertCommand.Parameters.AddWithValue("@Password", PassTxt.Text);
                    SA.InsertCommand.ExecuteNonQuery();

                }
               // SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\WindowsFormsApplication1\WindowsFormsApplication1\LoginDB.mdf;Integrated Security=True;");
                MessageBox.Show("you are now registered");
              
               
            }
            catch (SqlException ex)
            {
              MessageBox.Show(ex.Message);
            }
           
        }
        Register reg;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Log = new Login();
            Log.ShowDialog();
            this.Close();
            
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
