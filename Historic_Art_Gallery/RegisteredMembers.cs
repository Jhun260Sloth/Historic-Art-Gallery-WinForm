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
    public partial class RegisteredMembers : Form
    {
        public RegisteredMembers()
        {
            InitializeComponent();
        }
        public void showUsers()
        {
            DatClass db = new DatClass();
            dataGridView1.DataSource = db.GalleryAcc("SELECT Fullname, Username from Acc");


        }
        private void RegisteredMembers_Load(object sender, EventArgs e)
        {
            button2.Hide();
            label3.Text = Gallery.Usernamez;
            showUsers();
            if (label3.Text == "Admin")
            {
                button2.Show();
            }
            else
            {

            }
          

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                int index = e.RowIndex;
                DataGridViewRow selectedRows = dataGridView1.Rows[index];
                label5.Text = selectedRows.Cells[0].Value.ToString();
            }
            catch
            {

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
            string sqladd = "DELETE FROM Acc WHERE Fullname='" + label5.Text + "'";
            DatClass db = new DatClass();
            if (db.addregis(sqladd) > 0)
            {
                showUsers();
                label5.Text = "Removed";

            }
            else
            {
                label5.Text = "Error";
            }
        }
    }
}
