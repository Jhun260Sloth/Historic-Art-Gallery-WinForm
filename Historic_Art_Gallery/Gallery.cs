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
using System.IO;
using System.Drawing.Imaging;

namespace Historic_Art_Gallery
{
    public partial class Gallery : Form
    {
        public static string Usernamez;
        public static string ZoomPic;
        public Gallery()
        {
            InitializeComponent();
        }

        public void showArt()
        {
            DatClass db = new DatClass();
            dataGridView1.DataSource = db.GalleryAcc("SELECT * FROM HisArtGallery");


        }

        public void hideCol()
        {
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Visible = false;
            this.dataGridView1.Columns[2].Visible = false;
            this.dataGridView1.Columns[3].Visible = false;
            this.dataGridView1.Columns[4].Visible = false;
            this.dataGridView1.Columns[6].Visible = false;
            dataGridView1.ColumnHeadersVisible = false;
        }




        private void Gallery_Load(object sender, EventArgs e)
        {
            pictureBox3.Show();
            Ar.Hide();
            Statz2.Hide();
            try
            {
                showArt();
                Statz2.ForeColor = Color.Green;
                Statz2.BackColor = Color.Green;
                User_name.Text = Login.Usernamez;
                hideCol();
            }
            catch
            {
                Statz2.ForeColor = Color.Red;
                Statz2.BackColor = Color.Red;
                Statz2.Show();
            }

            if (User_name.Text == "Guest")
            {
                label3.Text = "Exit";
                Uploadbtn.Text = "Register";
                label1.Hide();
            }
            else
            {
                pictureBox1.Image = Historic_Art_Gallery.Properties.Resources.dfgd;
            }

            if (User_name.Text == "Admin")
            {
                Uploadbtn.Text = "Admin Panel";
                label3.Text = "Registered Users";
                label1.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.Text == "Registered Users")
            {
                string user12 = User_name.Text;
                Usernamez = user12;
                RegisteredMembers myNewForm = new RegisteredMembers();
                myNewForm.Visible = true;
                this.Hide();
            }
            else if (label3.Text == "Members")
            {
                string user12 = User_name.Text;
                Usernamez = user12;
                RegisteredMembers myNewForm = new RegisteredMembers();
                myNewForm.Visible = true;
                this.Hide();
            }
            else
            {
                Login myNewForm = new Login();
                myNewForm.Visible = true;
                this.Hide();
            }

        }

        private void Uploadbtn_Click(object sender, EventArgs e)
        {
            if (Uploadbtn.Text == "Upload")
            {
                string user12 = User_name.Text;
                Usernamez = user12;
                UploadForm myNewForm = new UploadForm();
                myNewForm.Visible = true;
                this.Hide();

            }
            else if (User_name.Text == "Admin")
            {
                string user12 = User_name.Text;
                Usernamez = user12;
                UploadForm myNewForm = new UploadForm();
                myNewForm.Visible = true;
                this.Hide();
            }
            else
            {
                Register2 myNewForm = new Register2();
                myNewForm.Visible = true;
                this.Hide();
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Login myNewForm = new Login();
            myNewForm.Visible = true;
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            showArt();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Ar.Show();
            pictureBox3.Hide();
            try
            {
               
                int index = e.RowIndex;
                DataGridViewRow selectedRows = dataGridView1.Rows[index];
                Up.Text = selectedRows.Cells[0].Value.ToString();
                Artiz.Text = selectedRows.Cells[1].Value.ToString();
                Ard.Text = selectedRows.Cells[2].Value.ToString();
                ArIn.Text = selectedRows.Cells[3].Value.ToString();
                Arp.Text = selectedRows.Cells[4].Value.ToString();
                ArTi.Text = selectedRows.Cells[5].Value.ToString();
                picz.Text = selectedRows.Cells[6].Value.ToString();
                string artpath = selectedRows.Cells[6].Value.ToString();

                if (artpath == null)
                {
                    pictureBox2.Image = null;
                }
                else
                {
                    Image image = Image.FromFile(@"" + artpath);
                    this.pictureBox2.Image = image;
                }
                
            }
            catch
            {

            }




        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string picture = picz.Text;
            ZoomPic = picture;
            ZoomView artView = new ZoomView();
            artView.ShowDialog();
           
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

