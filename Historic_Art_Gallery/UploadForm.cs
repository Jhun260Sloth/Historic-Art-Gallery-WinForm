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

namespace Historic_Art_Gallery
{
    public partial class UploadForm : Form
    {
        public static string Usernamez;
        public UploadForm()
        {
            InitializeComponent();
        }

        public void showArt()
        {
            DatClass db = new DatClass();
            UpForm.DataSource = db.GalleryAcc("SELECT * FROM HisArtGallery");
           
        }

        public void hideCol()
        {
            this.UpForm.Columns[0].Visible = false;
            this.UpForm.Columns[1].Visible = false;
            this.UpForm.Columns[2].Visible = false;
            this.UpForm.Columns[3].Visible = false;
            this.UpForm.Columns[4].Visible = false;
            this.UpForm.Columns[6].Visible = false;
        }
       
        private void UploadForm_Load(object sender, EventArgs e)
        {

            UserUp.Text = Gallery.Usernamez;
            if (UserUp.Text == "Admin")
            {
                Upda.Show();
                Delt.Show();
                UpForm.Show();
                showArt();
                hideCol();
                artitle.ReadOnly = true;
            }
            else
            {
                Upda.Hide();
                Delt.Hide();
                UpForm.Hide();
               
                Statx.Hide();
            }
           
        }

        public void ClearBoxes()
        {
            artist.Clear();
            artdescrip.Clear();
            artistinfo.Clear();
            artdate.Clear();
            artitle.Clear();
        }

        private void Up_Click(object sender, EventArgs e)
        {

            string sqladd = "INSERT INTO HisArtGallery Values('" + UserUp.Text + "', '" + artist.Text + "', '" + artdescrip.Text + "', '" + artistinfo.Text + "', '" + artdate.Text + "', '" + artitle.Text + "', '" + label8.Text + "')";
            DatClass db = new DatClass();
            if (db.addregis(sqladd) > 0)
            {
                Statx.Show();
                Statx.ForeColor = Color.Green;
                Statx.Text = "Uploaded";
                ClearBoxes();
                
            }
            else
            {
                Statx.Show();
                Statx.Text = "Not Recorded Error";
                ClearBoxes();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gallery myNewForm = new Gallery();
            myNewForm.Visible = true;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqladd = "UPDATE HisArtGallery set Uploader='" + UserUp.Text + "',Artist='" + artist.Text + "',Art_Description='" + artdescrip.Text + "',Artist_Information='" + artistinfo.Text + "',Art_Published='" + artdate.Text + "',Art='" + label8.Text + "'WHERE Art_Title='" + artitle.Text + "'";
            DatClass db = new DatClass();
            if (db.addregis(sqladd) > 0)
            {

                Statx.Show();
                Statx.ForeColor = Color.Green;
                Statx.Text = "Updated";
                ClearBoxes();

            }
            else
            {
                Statx.Show();
                Statx.Text = "Not Recorded Error";
                ClearBoxes();
            }
        }

        private void UpForm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRows = UpForm.Rows[index];
                UserUp.Text = selectedRows.Cells[0].Value.ToString();
                artist.Text = selectedRows.Cells[1].Value.ToString();
                artdescrip.Text = selectedRows.Cells[2].Value.ToString();
                artistinfo.Text = selectedRows.Cells[3].Value.ToString();
                artdate.Text = selectedRows.Cells[4].Value.ToString();
                artitle.Text = selectedRows.Cells[5].Value.ToString();
                string artpath = selectedRows.Cells[6].Value.ToString();
                label8.Text = selectedRows.Cells[6].Value.ToString();
                if (artpath == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    Image image = Image.FromFile(@"" + artpath);
                    this.pictureBox1.Image = image;
                }
            }
            catch
            {

            }
        }

        private void Delt_Click(object sender, EventArgs e)
        {
            string sqladd = "DELETE FROM HisArtGallery WHERE Art_Title='" + artitle.Text + "'";
            DatClass db = new DatClass();
            if (db.addregis(sqladd) > 0)
            {
                showArt();
                Statx.Show();
                Statx.ForeColor = Color.Green;
                Statx.Text = "Deleted";
                ClearBoxes();

            }
            else
            {
                Statx.Show();
                Statx.Text = "Not Recorded Error";
                ClearBoxes();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;*.jfif)|*.jpg;*.jpeg;.*.gif;*.jfif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                label8.Text = opnfd.FileName;
                pictureBox1.Image = Image.FromFile(opnfd.FileName);
            }  
        }
    }
}
