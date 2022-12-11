using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Historic_Art_Gallery
{
    public partial class ZoomView : Form
    {
        public static string ZoomPic;
        public ZoomView()
        {
            InitializeComponent();
        }

        private void ZoomView_Load(object sender, EventArgs e)
        {

            string imagezoom = Gallery.ZoomPic;

             if (imagezoom == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    Image image = Image.FromFile(@"" + imagezoom);
                    this.pictureBox1.Image = image;
                }
             
        }
    }
}
