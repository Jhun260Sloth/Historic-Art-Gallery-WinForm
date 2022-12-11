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


namespace Historic_Art_Gallery
{
    public partial class Login : Form
    {
        public static string Usernamez;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Statz.Hide();
            msg2.Hide();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                Statz.ForeColor = Color.Green;
                Statz.BackColor = Color.Green;

            }
            catch
            {
                Statz.ForeColor = Color.Red;
                Statz.BackColor = Color.Red;
                Statz.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Register2 myNewForm = new Register2();

            myNewForm.Visible = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usernamez = "Guest";
            Gallery myNewForm = new Gallery();
            myNewForm.Visible = true;
            this.Hide();

        }

        private void Log_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ACER\Documents\Visual Studio 2013\Projects\Historic_Art_Gallery\Historic_Art_Gallery\Accounts.mdf;Integrated Security=True");
            con.Open();
            string userid = UserR.Text;  
            string password = passwoR.Text;
            string str = "SELECT Username,Password from Acc WHERE Username='" + userid + "'and Password='" + password + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
          
            if (dr.HasRows)  
            {
                if (UserR.Text == "")
                {
                    msg2.Show();
                    msg2.Text = "No Record";
                    msg2.ForeColor = Color.Red;
                }
                else if(passwoR.Text == "")
                {
                    msg2.Show();
                    msg2.Text = "No Record";
                    msg2.ForeColor = Color.Red;
                }
                else
                {
                    msg2.Show();
                    Usernamez = userid;
                    Gallery myNewForm = new Gallery();
                    myNewForm.Visible = true;
                    this.Hide();
                }
               
            }  
            else  
            {
                msg2.Show();
                msg2.Text = "No Record";
                msg2.ForeColor = Color.Red;
            }  
        }

    }

       
    }

