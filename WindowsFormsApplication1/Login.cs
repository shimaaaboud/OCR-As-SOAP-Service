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

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.Hide();
            Register reg = new Register();
            reg.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\ocrwebservice\WindowsFormsApplication1\WindowsFormsApplication1\LoginDB.mdf;Integrated Security=True"))
            using (SqlCommand cmd = new SqlCommand("SELECT Name FROM Login WHERE Name = @Name AND Password = @Password", cn))
            {
                cn.Open();

                cmd.Parameters.AddWithValue("@Name",Nametxt.Text);
                cmd.Parameters.AddWithValue("@Password", PassTxt.Text);

                var result = cmd.ExecuteScalar() as string;
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("There is an Error ,please try again Or Register first !");
                }
                else
                {
                   // MessageBox.Show("Welcom to OCR!");
                    this.Hide();
                    ocrservice ocr = new ocrservice();
                    ocr.ShowDialog();
                    this.Close();
   
                }
               // Nametxt.Text = "";
               // PassTxt.Text = "";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
