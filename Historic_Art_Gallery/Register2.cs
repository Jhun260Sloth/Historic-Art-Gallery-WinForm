using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Historic_Art_Gallery
{
    public partial class Register2 : Form
    {
        public Register2()
        {
            InitializeComponent();
        }

        public void ClearText()
        {
            username.Text = "";
            password.Text = "";
            fullname.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Login myNewForm = new Login();

            myNewForm.Visible = true;
            this.Hide();
        }

        private void Register2_Load(object sender, EventArgs e)
        {
            msg.Hide();
            Statz2.Hide();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                Statz2.ForeColor = Color.Green;
                Statz2.BackColor = Color.Green;
               

            }

            catch
            {
                Statz2.ForeColor = Color.Red;
                Statz2.BackColor = Color.Red;
                Statz2.Show();
            }
        }

        

        private void Log_Click_1(object sender, EventArgs e)
        {
            string sqladd = "Insert Into Acc Values('" + username.Text + "', '" + password.Text + "', '" + fullname.Text + "')";
            DatClass db = new DatClass();
            if (db.addregis(sqladd) > 0)
            {
                msg.Show();
                msg.Text = "Registered";
                msg.ForeColor = Color.Green;
                ClearText();
            }
            else
            {
                msg.Show();
                msg.ForeColor = Color.Red;
                msg.Text = "Error";
            }
        }

    }
}
