using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace printErrors
{
    public partial class errorsForm : Form
    {
        public errorsForm()
        {
            InitializeComponent();
        }
       public void showError(string nameOfStatus)
        {         
            printErrorForUser.Text = printErrorForUser.Text  + nameOfStatus;           
            printErrorForUser.Text = printErrorForUser.Text + Environment.NewLine;
            printErrorForUser.Height += 20;
            int Y = buttonOk.Location.Y;
            Y += 11;
            buttonOk.Location = new Point(152, Y);
        }
       private void buttonOk_Click(object sender, EventArgs e)
       {
           this.Hide();
       }

       private void errorsForm_Load(object sender, EventArgs e)
       {
           try
           {
               Bitmap panelAttention = new Bitmap(@"images\attention.png");
               attention.Image = panelAttention;
           }
           catch
           {
               attention.Image = null;
           }
       }
    }
}