using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using historyOfCertificate;

namespace printCertificate
{
    public partial class certificatePrint : Form
    {
        public certificatePrint()
        {
            InitializeComponent();
            Margins margins = new Margins(0, 0, 0, 0);
            documentPrint.DefaultPageSettings.Margins = margins;
            documentPrint.PrintPage += new PrintPageEventHandler(documentForPrint);
        }
        string[] arrOfField;
        private PrintDocument documentPrint = new PrintDocument();

        private void documentForPrint(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Size oldsize = panelShowCertificate.Size;
            while (panelShowCertificate.HorizontalScroll.Visible)
                panelShowCertificate.Size = Size.Add(panelShowCertificate.Size, new Size(1, 0));
            while (panelShowCertificate.VerticalScroll.Visible)
                panelShowCertificate.Size = Size.Add(panelShowCertificate.Size, new Size(0, 1));
            Bitmap bmp = new Bitmap(this.panelShowCertificate.ClientRectangle.Width, this.panelShowCertificate.ClientRectangle.Height);
            this.panelShowCertificate.DrawToBitmap(bmp, panelShowCertificate.ClientRectangle);
            e.Graphics.DrawImageUnscaled(bmp, Point.Empty);
            panelShowCertificate.Size = oldsize;
        }

        private void certificatePrint_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap backImage = new Bitmap(@"images\back.png");
                back.BackgroundImage = backImage;
            }
            catch
            {
                back.BackgroundImage = null;
            }
            try
            {
                Bitmap printCertificateImage = new Bitmap(@"images\Printer.png");
                printCertificate.BackgroundImage = printCertificateImage;
            }
            catch
            {
                printCertificate.BackgroundImage = null;
            }
            try
            {
                Bitmap panelShowCertificateImage = new Bitmap(@"images\bg.png");
                panelShowCertificate.BackgroundImage = panelShowCertificateImage;
            }
            catch
            {
                panelShowCertificate.BackgroundImage = null;
            }
            try
            {
                Bitmap button2Image = new Bitmap(@"images\email.png");
                button2.BackgroundImage = button2Image;
            }
            catch
            {
                button2.BackgroundImage = null;
            }
            #region "Прізвище + Ім'я"
            showSurName.BackColor = Color.Transparent;
            #endregion
            #region "По батькові"
            showMiddleName.BackColor = Color.Transparent;
            #endregion
            #region "Дата народження"
            showDateOfBirth.BackColor = Color.Transparent;
            #endregion
            #region "Адрес"
            showAddress_1.BackColor = Color.Transparent;
            showAddress_2.BackColor = Color.Transparent;
            #endregion
            #region "Дата проходження огладу"
            showDateOfPassage.BackColor = Color.Transparent;
            #endregion
            #region "Результати огляду"
            #region "Наркологічні протипоказання до виконання"
            showAReviewOfA_1.BackColor = Color.Transparent;
            showAReviewOfA_2.BackColor = Color.Transparent;
            #endregion
            #region "Наркологічні протипоказання до провадження"
            showAReviewOfB_1.BackColor = Color.Transparent;
            showAReviewOfB_2.BackColor = Color.Transparent;
            #endregion
            #endregion
            #region "Результати обстеження..."
            showAReviewOfC_1.BackColor = Color.Transparent;
            showAReviewOfC_2.BackColor = Color.Transparent;
            #endregion
            #region "Сертифікат дійсний до"
            showValid.BackColor = Color.Transparent;
            #endregion
            #region "Дата"
            showCurrentDate.BackColor = Color.Transparent;
            #endregion
            changeLocationForPrint("show");
        }

        private int golosna(char c)
        {
            char[] bukvy = new char[] {'а', 'о', 'у', 'е', 'и', 'і', 'ї', 
                'А', 'О', 'У', 'Е', 'И', 'І', 'Ї',};
            int nbukvy = bukvy.Length;
            int i;
            for (i = 0; i < nbukvy; i++)
                if (bukvy[i] == c)
                    return 1;
            return 0;
        }
        private string[] checkFields(int countLeters, string arr)
        {
            string[] fields = new string[2];
            if (arr.Length <= countLeters)
            {
                fields[0] = arr;
                fields[1] = "";
            }
            else
            {
                char[] copyArr = arr.ToCharArray();
                if (copyArr[countLeters - 1] == ' ')
                {
                    fields[0] = "";
                    fields[1] = "";
                    for (int i = 0; i < countLeters - 1; i++)
                    {
                        fields[0] = fields[0] + copyArr[i];
                    }
                    for (int i = countLeters; i < copyArr.Length; i++)
                    {
                        fields[1] = fields[1] + copyArr[i];
                    }
                }
                else
                {
                    fields[0] = "";
                    fields[1] = "";
                    int position = 0;
                    for (int i = countLeters - 1; i >= 0; i--)
                    {
                        if (copyArr[i] == ' ' || copyArr[i] == '.')
                        {
                            position = countLeters - 3;
                        }
                    }
                    for (int i = 0; i <= position; i++)
                    {
                        fields[0] = fields[0] + copyArr[i];
                    }
                    for (int i = position + 1; i < copyArr.Length; i++)
                    {
                        fields[1] = fields[1] + copyArr[i];
                    }
                    if (position == countLeters - 3)
                    {
                        fields[0] = fields[0] + " -";
                    }
                }
            }
            return fields;
        }
        public void changeNameOfFields(string[] arr)
        {
            arrOfField = arr;
            string[] valueOfFields = new string[] { "", "" };
            #region "Прізвище + Ім'я + По батькові"
            if (arr[0].Length + arr[1].Length + arr[2].Length <= 22)
            {
                showSurName.Text = arr[0] + " " + arr[1] + " " + arr[2];
                showMiddleName.Text = "";
            }
            else
            {
                showSurName.Text = arr[0] + " " + arr[1];
                showMiddleName.Text = arr[2];
            }
            #endregion
            #region "Дата народження"
            showDateOfBirth.Text = arr[3];
            #endregion
            #region "Адреса:"
            valueOfFields = checkFields(35, arr[4]);
            showAddress_1.Text = valueOfFields[0];
            showAddress_2.Text = valueOfFields[1];
            #endregion
            #region "Дата проходження огладу:"
            showDateOfPassage.Text = arr[5];
            #endregion
            #region "Результати огляду"
            #region "Наркологічні протипоказання до виконання:"
            valueOfFields = checkFields(19, arr[6]);
            showAReviewOfA_1.Text = valueOfFields[0];
            showAReviewOfA_2.Text = valueOfFields[1];
            #endregion
            #region "Наркологічні протипоказання до провадження"
            valueOfFields = checkFields(19, arr[7]);
            showAReviewOfB_1.Text = valueOfFields[0];
            showAReviewOfB_2.Text = valueOfFields[1];
            #endregion
            #endregion
            #region "Результати обстеження..."
            valueOfFields = checkFields(34, arr[8]);
            showAReviewOfC_1.Text = valueOfFields[0];
            showAReviewOfC_2.Text = valueOfFields[1];
            #endregion
            #region "Сертифікат дійсний до"
            showValid.Text = arr[9];
            #endregion
            #region "Дата"
            showCurrentDate.Text = arr[10];
            #endregion
        }
        #region "Повернутися назад"
        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void infoBack_2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void infoBack_1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region "Друкувати сертифікат"
        private void functionPrintCertificate()
        {
            changeLocationForPrint("print");
            panelShowCertificate.BackgroundImage = null;
            documentPrint.Print();
            historyCertificate programHistory = new historyCertificate();
            char[] date = new char[showCurrentDate.Text.Length];
            date = arrOfField[10].ToCharArray();
            string[] arrSearch = new string[] { date[0].ToString() + date[1].ToString(),
                date[3].ToString() + date[4].ToString(), date[6].ToString() + date[7].ToString()
                + date[8].ToString() + date[9].ToString(), arrOfField[0], arrOfField[1], 
                arrOfField[2], arrOfField[3], arrOfField[4], arrOfField[6], arrOfField[7], 
                arrOfField[8], arrOfField[9]};
                programHistory.functionAddElement(arrSearch);
            try
            {
                Bitmap bg = new Bitmap(@"images\bg.png");
                panelShowCertificate.BackgroundImage = bg;
            }
            catch
            {
                panelShowCertificate.BackgroundImage = null;
            }
            this.Close();

        }

        private void printCertificate_Click(object sender, EventArgs e)
        {
            functionPrintCertificate();

        }
        private void infoPrintCertificate_Click(object sender, EventArgs e)
        {
            functionPrintCertificate();
        }
        #endregion

        private void changeLocationForPrint(string parametr)
        {
            switch (parametr)
            {
                case "print":
                    {
                        #region "Прізвище + Ім'я"
                        showSurName.Location = new Point(216, 324);
                        #endregion
                        #region "По батькові"
                        showMiddleName.Location = new Point(306, 346);
                        #endregion
                        #region "Дата народження"
                        showDateOfBirth.Location = new Point(190, 346);
                        #endregion
                        #region "Адрес"
                        showAddress_1.Location = new Point(116, 369);
                        showAddress_2.Location = new Point(306, 390);
                        #endregion
                        #region "Дата проходження огладу"
                        showDateOfPassage.Location = new Point(190, 390);
                        #endregion
                        #region "Результати огляду"
                        #region "Наркологічні протипоказання до виконання"
                        showAReviewOfA_1.Location = new Point(276, 427);
                        showAReviewOfA_2.Location = new Point(66, 451);
                        #endregion
                        #region "Наркологічні протипоказання до провадження"
                        showAReviewOfB_1.Location = new Point(276, 482);
                        showAReviewOfB_2.Location = new Point(66, 504);
                        #endregion
                        #endregion
                        #region "Результати обстеження..."
                        showAReviewOfC_1.Location = new Point(126, 552);
                        showAReviewOfC_2.Location = new Point(66, 572);
                        #endregion
                        #region "Сертифікат дійсний до"
                        showValid.Location = new Point(320, 593);
                        #endregion
                        #region "Дата"
                        showCurrentDate.Location = new Point(320, 653);
                        #endregion
                    }
                    break;
                case "show":
                    {
                        #region "Прізвище + Ім'я"
                        showSurName.Location = new Point(216, 334);
                        #endregion
                        #region "По батькові"
                        showMiddleName.Location = new Point(306, 356);
                        #endregion
                        #region "Дата народження"
                        showDateOfBirth.Location = new Point(190, 356);
                        #endregion
                        #region "Адрес"
                        showAddress_1.Location = new Point(116, 379);
                        showAddress_2.Location = new Point(306, 400);
                        #endregion
                        #region "Дата проходження огладу"
                        showDateOfPassage.Location = new Point(190, 400);
                        #endregion
                        #region "Результати огляду"
                        #region "Наркологічні протипоказання до виконання"
                        showAReviewOfA_1.Location = new Point(276, 437);
                        showAReviewOfA_2.Location = new Point(66, 461);
                        #endregion
                        #region "Наркологічні протипоказання до провадження"
                        showAReviewOfB_1.Location = new Point(276, 492);
                        showAReviewOfB_2.Location = new Point(66, 514);
                        #endregion
                        #endregion
                        #region "Результати обстеження..."
                        showAReviewOfC_1.Location = new Point(126, 562);
                        showAReviewOfC_2.Location = new Point(66, 582);
                        #endregion
                        #region "Сертифікат дійсний до"
                        showValid.Location = new Point(320, 603);
                        #endregion
                        #region "Дата"
                        showCurrentDate.Location = new Point(320, 663);
                        #endregion
                    }
                    break;
            }

        }
    }
}