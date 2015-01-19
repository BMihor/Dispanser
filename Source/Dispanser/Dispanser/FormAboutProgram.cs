using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aboutProgram
{
    public partial class windowAboutProgram : Form
    {
        public windowAboutProgram()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void windowAboutProgram_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap panel1Image = new Bitmap(@"images\emblema.png");
                panel1.BackgroundImage = panel1Image;
            }
            catch
            {
                panel1.BackgroundImage = null;
            }

        }
    }
}
