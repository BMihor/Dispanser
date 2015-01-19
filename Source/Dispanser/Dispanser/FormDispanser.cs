using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using printErrors;
using printCertificate;
using aboutProgram;
using settings;

namespace Dispanser
{
    public partial class mainDispanser : Form
    {
        public mainDispanser()
        {
            InitializeComponent();
        }
        private bool[] booleanStatus = new bool[] {false, false, false, 
            false, false, true, false, false, true, true, true};
        // Завантаження форми
        private void mainDispanser_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap newCertificateImage = new Bitmap(@"images\NewFile.png");
                newCertificate.Image = newCertificateImage;
            }
            catch
            {
                newCertificate.Image = null;
            }
            try
            {
                Bitmap printCertificateImage = new Bitmap(@"images\Printer.png");
                printCertificate.Image = printCertificateImage;
            }
            catch
            {
                printCertificate.Image = null;
            }
            try
            {
                Bitmap settingsImage = new Bitmap(@"images\Settings.png");
                settings.Image = settingsImage;
            }
            catch
            {
                settings.Image = null;
            }
            try
            {
                Bitmap aboutImage = new Bitmap(@"images\info.png");
                about.Image = aboutImage;
            }
            catch
            {
                about.Image = null;
            }
            #region "Прізвище"
            defaultValueSurname();
            #endregion
            #region "Ім'я"
            defaultValueName();
            #endregion
            #region "По батькові"
            defaultValueMiddleName();
            #endregion
            #region "Дата народження"
            defaultValueDateOfBirth();
            #endregion
            #region "Адрес"
            defaultValueAddress();
            #endregion
            #region "Дата проходження огладу"
            defaultValueDateOfPassage();
            #endregion
            #region "Результати огляду"
            #region "Наркологічні протипоказання до виконання"
            defaultValueAReviewOfA();
            #endregion
            #region "Наркологічні протипоказання до провадження"
            defaultValueAReviewOfB();
            #endregion
            #endregion
            #region "Результати обстеження..."
            defaultValueAReviewOfC();
            #endregion
            #region "Сертифікат дійсний до"
            defaultValueValid();
            #endregion
            #region "Дата"
            defaultCurrentDate();
            #endregion
        }
        #region "Прізвище"
        private void inputSurname_Enter(object sender, EventArgs e)
        {
            statusSurname.Image = changeStatus("Surname", "Edit");
        }
        private void inputSurname_Leave(object sender, EventArgs e)
        {
            statusSurname.Image = inputAfterLeave(inputSurname.Text, "прізвище", "Surname");
        }       
        #endregion
        #region "Ім'я"
        private void inputName_Enter(object sender, EventArgs e)
        {
            statusName.Image = changeStatus("Name", "Edit");
        }
        private void inputName_Leave(object sender, EventArgs e)
        {
            statusName.Image = inputAfterLeave(inputName.Text, "ім'я", "Name");
        }
        #endregion
        #region "По батькові"
        private void inputMiddleName_Enter(object sender, EventArgs e)
        {
            statusMiddleName.Image = changeStatus("MiddleName", "Edit");
        }
        private void inputMiddleName_Leave(object sender, EventArgs e)
        {
            statusMiddleName.Image = inputAfterLeave(inputMiddleName.Text, "по батькові", "MiddleName");
        }
        #endregion
        #region "Дата народження"
        #region "День"
        private void inputDateOfBirthDay_Enter(object sender, EventArgs e)
        {
            statusDateOfBirth.Image = changeStatus("DateOfBirth", "Edit");
        }
        private void inputDateOfBirthDay_Leave(object sender, EventArgs e)
        {
            if (inputDateOfBirthDay.Text == "")
            {
                statusDateOfBirth.Image = changeStatus("DateOfBirth", "No");
            }
            else
            {
                inputDateOfBirthDay.Text = inputAfterLeaveForDay(inputDateOfBirthDay.Text,
    inputDateOfBirthMonth.Text, inputDateOfBirthYear.Text);
                statusDateOfBirth.Image = statusAfterLeave(inputDateOfBirthDay.Text,
    inputDateOfBirthMonth.Text, inputDateOfBirthYear.Text, "DateOfBirth");
            }
        }
        private void inputDateOfBirthDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }
        #endregion
        #region "Місяць"
        private void inputDateOfBirthMonth_Enter(object sender, EventArgs e)
        {
            statusDateOfBirth.Image = changeStatus("DateOfBirth", "Edit");
        }
        private void inputDateOfBirthMonth_Leave(object sender, EventArgs e)
        {
            if (inputDateOfBirthMonth.Text == "")
            {
                statusDateOfBirth.Image = changeStatus("DateOfBirth", "No");
            }
            else
            {
                inputDateOfBirthMonth.Text = inputAfterLeaveForMonth(inputDateOfBirthDay.Text,
    inputDateOfBirthMonth.Text, inputDateOfBirthYear.Text);
                statusDateOfBirth.Image = statusAfterLeave(inputDateOfBirthDay.Text,
    inputDateOfBirthMonth.Text, inputDateOfBirthYear.Text, "DateOfBirth");
            }
        }
        private void inputDateOfBirthMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }
        #endregion
        #region "Рік"
        private void inputDateOfBirthYear_Enter(object sender, EventArgs e)
        {
            statusDateOfBirth.Image = changeStatus("DateOfBirth", "Edit");
        }
        private void inputDateOfBirthYear_Leave(object sender, EventArgs e)
        {
            inputDateOfBirthYear.Text = inputAfterLeaveForYear(inputDateOfBirthDay.Text,
    inputDateOfBirthMonth.Text, inputDateOfBirthYear.Text);
            statusDateOfBirth.Image = statusAfterLeave(inputDateOfBirthDay.Text,
inputDateOfBirthMonth.Text, inputDateOfBirthYear.Text, "DateOfBirth");
        }
        private void inputDateOfBirthYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }
        #endregion
        #endregion
        #region "Адрес"
        private void inputAddress_Enter(object sender, EventArgs e)
        {
            statusAddress.Image = changeStatus("Address", "Edit");
        }
        private void inputAddress_Leave(object sender, EventArgs e)
        {
            statusAddress.Image = inputAfterLeave(inputAddress.Text, "адресу", "Address");
        }
        #endregion
        #region "Дата проходження огладу"
        #region "День"
        private void inputDateOfPassageDay_Enter(object sender, EventArgs e)
        {
            statusDateOfPassage.Image = changeStatus("DateOfPassage", "Edit");
        }
        private void inputDateOfPassageDay_Leave(object sender, EventArgs e)
        {
            if (inputDateOfPassageDay.Text == "")
            {
                statusDateOfPassage.Image = changeStatus("DateOfPassage", "No");
            }
            else
            {
                inputDateOfPassageDay.Text = inputAfterLeaveForDay(inputDateOfPassageDay.Text,
    inputDateOfPassageMonth.Text, inputDateOfPassageYear.Text);
                statusDateOfPassage.Image = statusAfterLeave(inputDateOfPassageDay.Text,
    inputDateOfPassageMonth.Text, inputDateOfPassageYear.Text, "DateOfPassage");
            }
        }
        private void inputDateOfPassageDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }
        #endregion
        #region "Місяць"
        private void inputDateOfPassageMonth_Enter(object sender, EventArgs e)
        {
            statusDateOfPassage.Image = changeStatus("DateOfPassage", "Edit");
        }
        private void inputDateOfPassageMonth_Leave(object sender, EventArgs e)
        {
            if (inputDateOfPassageMonth.Text == "")
            {
                statusDateOfPassage.Image = changeStatus("DateOfPassage", "No");
            }
            else
            {
                inputDateOfPassageMonth.Text = inputAfterLeaveForMonth(inputDateOfPassageDay.Text,
        inputDateOfPassageMonth.Text, inputDateOfPassageYear.Text);
                statusDateOfPassage.Image = statusAfterLeave(inputDateOfPassageDay.Text,
    inputDateOfPassageMonth.Text, inputDateOfPassageYear.Text, "DateOfPassage");
            }
        }
        private void inputDateOfPassageMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }
        #endregion
        #region "Рік"
        private void inputDateOfPassageYear_Enter(object sender, EventArgs e)
        {
            statusDateOfPassage.Image = changeStatus("DateOfPassage", "Edit");
        }
        private void inputDateOfPassageYear_Leave(object sender, EventArgs e)
        {
            inputDateOfPassageYear.Text = inputAfterLeaveForYear(inputDateOfPassageDay.Text,
                inputDateOfPassageMonth.Text, inputDateOfPassageYear.Text);
            statusDateOfPassage.Image = statusAfterLeave(inputDateOfPassageDay.Text,
    inputDateOfPassageMonth.Text, inputDateOfPassageYear.Text, "DateOfPassage");
        }
        private void inputDateOfPassageYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }
        #endregion
        #endregion
        #region "Результати огляду"
        #region "Наркологічні протипоказання до виконання"
        private void inputAReviewOfA_Enter(object sender, EventArgs e)
        {
            statusAReviewOfA.Image = changeStatus("AReviewOfA", "Edit");
        }
        private void inputAReviewOfA_Leave(object sender, EventArgs e)
        {
            statusAReviewOfA.Image = inputAfterLeaveForComboBox(inputAReviewOfA.SelectedIndex,
                "наркологічні протипоказання до виконання", "AReviewOfA");
        }
        #endregion
        #region "Наркологічні протипоказання до провадження"
        private void inputAReviewOfB_Enter(object sender, EventArgs e)
        {
            statusAReviewOfB.Image = changeStatus("AReviewOfB", "Edit");
        }
        private void inputAReviewOfB_Leave(object sender, EventArgs e)
        {
            statusAReviewOfB.Image = inputAfterLeaveForComboBox(inputAReviewOfB.SelectedIndex,
                "наркологічні протипоказання до провадження", "AReviewOfB");
        }
        #endregion
        #endregion
        #region "Результати обстеження..."
        private void inputAReviewOfC_Enter(object sender, EventArgs e)
        {
            statusAReviewOfC.Image = changeStatus("AReviewOfC", "Edit");
        }
        private void inputAReviewOfC_Leave(object sender, EventArgs e)
        {
            if ((inputAReviewOfC.Text == "") || inputAReviewOfC.Text.Length > 0)
            {
                statusAReviewOfC.Image = changeStatus("AReviewOfC", "Yes");
            }
        }
        #endregion
        #region "Сертифікат дійсний до"
        #region "День"
        private void inputValidDay_Enter(object sender, EventArgs e)
        {
            statusValid.Image = changeStatus("Valid", "Edit");
        }
        private void inputValidDay_Leave(object sender, EventArgs e)
        {
            if (inputValidDay.Text == "")
            {
                statusValid.Image = changeStatus("Valid", "No");
            }
            else
            {
                inputValidDay.Text = inputAfterLeaveForDay(inputValidDay.Text,
        inputValidMonth.Text, inputValidYear.Text);
                statusValid.Image = statusAfterLeave(inputValidDay.Text,
    inputValidMonth.Text, inputValidYear.Text, "Valid");
            }
        }
        private void inputValidDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }
        #endregion
        #region "Місяць"
        private void inputValidMonth_Enter(object sender, EventArgs e)
        {
            statusValid.Image = changeStatus("Valid", "Edit");
        }
        private void inputValidMonth_Leave(object sender, EventArgs e)
        {
            if (inputValidMonth.Text == "")
            {
                statusValid.Image = changeStatus("Valid", "No");
            }
            else
            {
                inputValidMonth.Text = inputAfterLeaveForMonth(inputValidDay.Text,
                    inputValidMonth.Text, inputValidYear.Text);
                statusValid.Image = statusAfterLeave(inputValidDay.Text,
    inputValidMonth.Text, inputValidYear.Text, "Valid");
            }
        }
        private void inputValidMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }
        #endregion
        #region "Рік"
        private void inputValidYear_Enter(object sender, EventArgs e)
        {
            statusValid.Image = changeStatus("Valid", "Edit");
        }
        private void inputValidYear_Leave(object sender, EventArgs e)
        {
            inputValidYear.Text = inputAfterLeaveForYear(inputValidDay.Text,
                inputValidMonth.Text, inputValidYear.Text);
            statusValid.Image = statusAfterLeave(inputValidDay.Text,
                inputValidMonth.Text, inputValidYear.Text, "Valid");
        }
        private void inputValidYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }
        #endregion
        #endregion
        #region "Дата"
        #region "День"
        private void inputCurrentDateDay_Enter(object sender, EventArgs e)
        {
            statusCurrentDate.Image = changeStatus("CurrentDate", "Edit");
        }
        private void inputCurrentDateDay_Leave(object sender, EventArgs e)
        {
            if (inputCurrentDateDay.Text == "")
            {
                statusCurrentDate.Image = changeStatus("CurrentDate", "No");
            }
            else
            {
                inputCurrentDateDay.Text = inputAfterLeaveForDay(inputCurrentDateDay.Text,
                    inputCurrentDateMonth.Text, inputCurrentDateYear.Text);
                statusCurrentDate.Image = statusAfterLeave(inputCurrentDateDay.Text,
    inputCurrentDateMonth.Text, inputCurrentDateYear.Text, "CurrentDate");
            }
        }
        private void inputCurrentDateDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }
        #endregion
        #region "Місяць"
        private void inputCurrentDateMonth_Enter(object sender, EventArgs e)
        {
            statusCurrentDate.Image = changeStatus("CurrentDate", "Edit");
        }
        private void inputCurrentDateMonth_Leave(object sender, EventArgs e)
        {
            if (inputCurrentDateMonth.Text == "")
            {
                statusCurrentDate.Image = changeStatus("CurrentDate", "No");
            }
            else
            {
                inputCurrentDateMonth.Text = inputAfterLeaveForMonth(inputCurrentDateDay.Text,
                    inputCurrentDateMonth.Text, inputCurrentDateYear.Text);
                statusCurrentDate.Image = statusAfterLeave(inputCurrentDateDay.Text,
    inputCurrentDateMonth.Text, inputCurrentDateYear.Text, "CurrentDate");
            }
        }
        private void inputCurrentDateMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }
        #endregion
        #region "Рік"
        private void inputCurrentDateYear_Enter(object sender, EventArgs e)
        {
            statusCurrentDate.Image = changeStatus("CurrentDate", "Edit");
        }
        private void inputCurrentDateYear_Leave(object sender, EventArgs e)
        {
            inputCurrentDateYear.Text = inputAfterLeaveForYear(inputCurrentDateDay.Text,
                inputCurrentDateMonth.Text, inputCurrentDateYear.Text);
            statusCurrentDate.Image = statusAfterLeave(inputCurrentDateDay.Text,
                inputCurrentDateMonth.Text, inputCurrentDateYear.Text, "CurrentDate");
        }
        private void inputCurrentDateYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }
        #endregion
        #endregion
        #region "Новий сертифікат"
        private void newCertificate_Click(object sender, EventArgs e)
        {          
            mainDispanser_Load(sender, e);
        }
        private void infonewCertificate_Click(object sender, EventArgs e)
        {
            mainDispanser_Load(sender, e);
        }
        #endregion
        #region "Друкувати сертифікат"
        private void print()
        {
            if (checkFilling())
            {
                string[] arrOfValue = new string[] {inputSurname.Text.ToString(), inputName.Text.ToString(), 
                inputMiddleName.Text.ToString(), inputDateOfBirthDay.Text.ToString() + "." + 
                inputDateOfBirthMonth.Text.ToString() + "." + inputDateOfBirthYear.Text.ToString(), 
                inputAddress.Text.ToString(), inputDateOfPassageDay.Text.ToString() + "." + 
                inputDateOfPassageMonth.Text.ToString() + "." + inputDateOfPassageYear.Text.ToString(),
                inputAReviewOfA.Text.ToString(), inputAReviewOfB.Text.ToString(), inputAReviewOfC.Text.ToString(),
                inputValidDay.Text.ToString() + "." + inputValidMonth.Text.ToString() + "." + 
                inputValidYear.Text.ToString(), inputCurrentDateDay.Text.ToString() + "." + 
                inputCurrentDateMonth.Text.ToString() + "." + inputCurrentDateYear.Text.ToString()};
                certificatePrint certificate = new certificatePrint();
                certificate.changeNameOfFields(arrOfValue);
                certificate.ShowDialog();
            }
        }
        private void printCertificate_Click(object sender, EventArgs e)
        {
            print();
        }
        private void infoPrintCertificate_Click(object sender, EventArgs e)
        {
            print();
        }
        #endregion
        #region "Про програму"
        private void aboutPrograms()
        {
            windowAboutProgram programAbout = new windowAboutProgram();
            programAbout.ShowDialog();
        }
        private void about_Click(object sender, EventArgs e)
        {
            aboutPrograms();
        }
        private void infoAbout_Click(object sender, EventArgs e)
        {
            aboutPrograms();
        }
        #endregion
        #region "Значення за замовчуванням"
        #region "Прізвище"
        private void defaultValueSurname()
        {
            inputSurname.Text = "Введіть прізвище";
            statusSurname.Image = changeStatus("Surname", "No");
        }
        #endregion
        #region "Ім'я"
        private void defaultValueName()
        {
            inputName.Text = "Введіть ім'я";
            statusName.Image = changeStatus("Name", "No");
        }
        #endregion
        #region "По батькові"
        private void defaultValueMiddleName()
        {
            inputMiddleName.Text = "Введіть по батькові";
            statusMiddleName.Image = changeStatus("MiddleName", "No");
        }
        #endregion
        #region "Дата народження"
        private void defaultValueDateOfBirth()
        {
            #region "Дeнь"
            inputDateOfBirthDay.MaxLength = 2;
            inputDateOfBirthDay.Text = "";
            #endregion
            #region "Місяць"
            inputDateOfBirthMonth.MaxLength = 2;
            inputDateOfBirthMonth.Text = "";
            #endregion
            #region "Рік"
            inputDateOfBirthYear.MaxLength = 4;
            inputDateOfBirthYear.Text = "";
            #endregion
            statusDateOfBirth.Image = changeStatus("DateOfBirth", "No");
        }
        #endregion
        #region "Адрес"
        private void defaultValueAddress()
        {
            inputAddress.Text = "Введіть адресу";
            statusAddress.Image = changeStatus("Address", "No");
        }
        #endregion
        #region "Дата проходження огладу"
        private void defaultValueDateOfPassage()
        {
            #region "Поточна дата"
            int cDay = DateTime.Today.Day;
            int cMonth = DateTime.Today.Month;
            int cYear = DateTime.Today.Year;
            #endregion
            #region "Дeнь"
            inputDateOfPassageDay.MaxLength = 2;
            inputDateOfPassageDay.Text = "";
            inputDateOfPassageDay.Text = changeDigit(cDay, inputDateOfPassageDay.Text);
            #endregion
            #region "Місяць"
            inputDateOfPassageMonth.MaxLength = 2;
            inputDateOfPassageMonth.Text = "";
            inputDateOfPassageMonth.Text = changeDigit(cMonth, inputDateOfPassageMonth.Text);
            #endregion
            #region "Рік"
            inputDateOfPassageYear.MaxLength = 4;
            inputDateOfPassageYear.Text = "";
            inputDateOfPassageYear.AppendText(cYear.ToString());
            #endregion
            statusDateOfPassage.Image = changeStatus("DateOfPassage", "Yes");
        }
        #endregion
        #region "Результати огляду"
        #region "Наркологічні протипоказання до виконання"
        private void defaultValueAReviewOfA()
        {
            inputAReviewOfA.Items.Clear();
            inputAReviewOfA.Text = "Введіть наркологічні протипоказання до виконання";         
            changeSettings Setting = new changeSettings();
            string[] arrString = new string[Setting.lenghtFillingForString()];
            arrString = Setting.fillingForString();
            inputAReviewOfA.Items.AddRange(arrString);
            statusAReviewOfA.Image = changeStatus("AReviewOfA", "No");
        }
        #endregion
        #region "Наркологічні протипоказання до провадження"
        private void defaultValueAReviewOfB()
        {
            inputAReviewOfB.Items.Clear();
            inputAReviewOfB.Text = "Введіть наркологічні протипоказання до виконання";
            changeSettings Setting = new changeSettings();
            string[] arrString = new string[Setting.lenghtFillingForString()];
            arrString = Setting.fillingForString();
            inputAReviewOfB.Items.AddRange(arrString);
            statusAReviewOfB.Image = changeStatus("AReviewOfB", "No");
        }
        #endregion
        #endregion
        #region "Результати обстеження..."
        private void defaultValueAReviewOfC()
        {
            inputAReviewOfC.Text = "";
            statusAReviewOfC.Image = changeStatus("AReviewOfC", "Yes");
        }
        #endregion
        #region "Сертифікат дійсний до"
        private void defaultValueValid()
        {
            #region "Поточна дата"
            int cDay = DateTime.Today.Day;
            int cMonth = DateTime.Today.Month;
            int cYear = DateTime.Today.Year;
            #endregion
            #region "Дeнь"
            inputValidDay.MaxLength = 2;
            inputValidDay.Text = "";
            inputValidDay.Text = changeDigit(cDay, inputValidDay.Text);
            #endregion
            #region "Місяць"
            inputValidMonth.MaxLength = 2;
            inputValidMonth.Text = "";
            inputValidMonth.Text = changeDigit(cMonth, inputValidMonth.Text);
            #endregion
            #region "Рік"
            inputValidYear.MaxLength = 4;
            inputValidYear.Text = "";
            int tcYear = cYear + 2;
            inputValidYear.AppendText(tcYear.ToString());
            #endregion
            statusValid.Image = changeStatus("Valid", "Yes");
        }
        #endregion
        #region "Дата"
        private void defaultCurrentDate()
        {
            #region "Поточна дата"
            int cDay = DateTime.Today.Day;
            int cMonth = DateTime.Today.Month;
            int cYear = DateTime.Today.Year;
            #endregion
            #region "Дeнь"
            inputCurrentDateDay.MaxLength = 2;
            inputCurrentDateDay.Text = "";
            inputCurrentDateDay.Text = changeDigit(cDay, inputCurrentDateDay.Text);
            #endregion
            #region "Місяць"
            inputCurrentDateMonth.MaxLength = 2;
            inputCurrentDateMonth.Text = "";
            inputCurrentDateMonth.Text = changeDigit(cMonth, inputCurrentDateMonth.Text);
            #endregion
            #region "Рік"
            inputCurrentDateYear.MaxLength = 4;
            inputCurrentDateYear.Text = "";
            inputCurrentDateYear.AppendText(cYear.ToString());
            #endregion
            statusCurrentDate.Image = changeStatus("CurrentDate", "Yes");
        }
        #endregion
        #endregion
        #region "Зміна статуса"
        private Image changeStatus(string statusName, string status)
        {
            Image imageStatus = null;
            string[] nameStatusField = new string[] {"Surname", "Name", "MiddleName", 
                "DateOfBirth", "Address", "DateOfPassage", "AReviewOfA", "AReviewOfB", 
                "AReviewOfC", "Valid", "CurrentDate"};
            int pos = 0;
            for (int j = 0; j < booleanStatus.Length; j++)
            {
                if (statusName == nameStatusField[j])
                {
                    pos = j;
                    break;
                }
            }
            switch (status)
            {
                #region "No"
                case "No":
                    {
                        try
                        {
                            Bitmap Edit_No = new Bitmap(@"images\Edit_No.png");
                            imageStatus = Edit_No;
                        }
                        catch 
                        {
                            imageStatus = null;
                        }                       
                        booleanStatus[pos] = false;
                    }
                    break;
                #endregion
                #region "Yes"
                case "Yes":
                    {
                        try
                        {
                            Bitmap Edit_Yes = new Bitmap(@"images\Edit_Yes.png");
                            imageStatus = Edit_Yes;
                        }
                        catch
                        {
                            imageStatus = null;
                        }
                        booleanStatus[pos] = true;
                    }
                    break;
                #endregion
                #region "Edit"
                case "Edit":
                    {
                        try
                        {
                            Bitmap Edit = new Bitmap(@"images\Edit_status.png");
                            imageStatus = Edit;
                        }
                        catch
                        {
                            imageStatus = null;
                        }
                    }
                    break;
                #endregion
            }
            return imageStatus;
        }
        #endregion
        #region "Зміна формату числа"
        private string changeDigit(int digit, string input)
        {
            if (digit < 10)
            {
                input = "0" + digit.ToString();
            }
            else
            {
                input = digit.ToString();
            }
            return input;
        }
        #endregion
        #region "Коригування після введення даних"
        #region "Текст"
        private Image inputAfterLeave(string input, string str, string name)
        {
            Image imgStatus = null;
            if ((input != "Введіть " + str) && input.Length > 0)
            {
                imgStatus = changeStatus(name, "Yes");
            }
            else
            {
                imgStatus = changeStatus(name, "No");
            }
            return imgStatus;
        }
        private Image inputAfterLeaveForComboBox(int SelectedIndex, string str, string name)
        {
            Image imgStatus = null;
            if (SelectedIndex >= 0)
            {
                imgStatus = changeStatus(name, "Yes");
            }
            else
            {
                imgStatus = changeStatus(name, "No");
            }
            return imgStatus;
        }
        #endregion
        #region "Статус"
        private Image statusAfterLeave(string inputDay, string inputMonth, string inputYear, string name)
        {
            Image statusImg = null;
            if (inputDay != "" && inputMonth != "" && inputYear != "")
            {
                statusImg = changeStatus(name, "Yes");
            }
            else
            {
                statusImg = changeStatus(name, "No");
            }
            return statusImg;
        }
        #endregion
        #region "Дата"
        #region "Только цифри в дате"
        private void onlyDigit(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
        #endregion
        #region "Коректне заповнення поля "День""
        private string inputAfterLeaveForDay(string inputDay, string inputMonth, string inputYear)
        {
            if (int.Parse(inputDay) <= 0 || int.Parse(inputDay) > 31)
            {
                inputDay = "";
            }
            else
            {
                inputDay = changeDigit(int.Parse(inputDay), inputDay);
            }
            return inputDay;
        }
        #endregion
        #region "Коректне заповнення поля "Місяць""
        private string inputAfterLeaveForMonth(string inputDay, string inputMonth, string inputYear)
        {
            if (int.Parse(inputMonth) <= 0 || int.Parse(inputMonth) > 12)
            {
                inputMonth = "";
            }
            else
            {
                inputMonth = changeDigit(int.Parse(inputMonth), inputMonth);
            }
            return inputMonth;
        }
        #endregion
        #region "Коректне заповнення поля "Рік""
        private string inputAfterLeaveForYear(string inputDay, string inputMonth, string inputYear)
        {
            int cYear = DateTime.Today.Year;
            int digit = 0;
            if (inputYear.Length == 1)
            {
                inputYear = 200.ToString() + inputYear;
            }
            else
            {
                if (inputYear.Length == 2)
                {
                    if (int.Parse(inputYear) <= cYear - 2000)
                    {
                        digit = 20;
                    }
                    else
                    {
                        digit = 19;
                    }
                    inputYear = digit.ToString() + inputYear;
                }
                else
                    if (inputYear.Length < 2 || (inputYear.Length > 2 && inputYear.Length < 4))
                    {
                        inputYear = "";
                    }
            }
            return inputYear;
        }
        #endregion
        #endregion
        #endregion
        #region "Перевірка на коректне заповнення всіх полів"
        private bool checkFilling()
        {
            if (inputAReviewOfC.Text == "")
            {
                inputAReviewOfC.Text = " ";
            }
            errorsForm formOferror = new errorsForm();
            formOferror.Height = 166;
            string[] valueStatusField = new string[] {"Прізвище", "Ім'я", "По батькові", 
                "Дата народження", "Адреса", "Дата проходження огладу", "Результати огляду (a)", 
                "Результати огляду (б)", "Результати обстеження...", "Сертифікат дійсний до", "Дата"};
            bool check = false;
            int countCheckFalse = 0;
            for (int i = 0; i < booleanStatus.Length; i++)
            {
                if (!booleanStatus[i])
                {
                    formOferror.showError(valueStatusField[i]);
                    formOferror.Height += 11;
                }
                else
                {
                    countCheckFalse++;
                }
            }
            if (countCheckFalse != booleanStatus.Length)
            {
                check = false;
                formOferror.ShowDialog();
            }
            else
            {
                check = true;
            }
            return check;
        }
        #endregion       
        #region "очищення поля"
        #region "Прізвище"
        private void statusSurname_Click(object sender, EventArgs e)
        {
            inputSurname.Text = "";
            statusSurname.Image = changeStatus("Surname", "No");
        }
        #endregion
        #region "Ім'я"
        private void statusName_Click(object sender, EventArgs e)
        {
            inputName.Text = "";
            statusName.Image = changeStatus("Name", "No");
        }
        #endregion
        #region "По батькові"
        private void statusMiddleName_Click(object sender, EventArgs e)
        {
            inputMiddleName.Text = "";
            statusMiddleName.Image = changeStatus("MiddleName", "No");
        }
        #endregion
        #region "Дата народження"
        private void statusDateOfBirth_Click(object sender, EventArgs e)
        {
            defaultValueDateOfBirth();
        }
        #endregion
        #region "Адрес"
        private void statusAddress_Click(object sender, EventArgs e)
        {
            inputAddress.Text = "";
            statusAddress.Image = changeStatus("Address", "No");
        }
        #endregion
        #region "Дата проходження огладу"
        private void statusDateOfPassage_Click(object sender, EventArgs e)
        {
            defaultValueDateOfPassage();
        }
        #endregion
        #region "Результати огляду"
        #region "Наркологічні протипоказання до виконання"
        private void statusAReviewOfA_Click(object sender, EventArgs e)
        {
            inputAReviewOfA.SelectedIndex = -1;
            statusAReviewOfA.Image = changeStatus("AReviewOfA", "No");
        }
        #endregion
        #region "Наркологічні протипоказання до провадження"
        private void statusAReviewOfB_Click(object sender, EventArgs e)
        {
            inputAReviewOfB.SelectedIndex = -1;
            statusAReviewOfB.Image = changeStatus("AReviewOfB", "No");
        }
        #endregion
        #endregion
        #region "Результати обстеження..."
        private void statusAReviewOfC_Click(object sender, EventArgs e)
        {
            defaultValueAReviewOfC();
        }
        #endregion
        #region "Сертифікат дійсний до"
        private void statusValid_Click(object sender, EventArgs e)
        {
            defaultValueValid();
        }
        #endregion
        #region "Дата"
        private void statusCurrentDate_Click(object sender, EventArgs e)
        {
            defaultCurrentDate();
        }
        #endregion    

        private void inputAReviewOfA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region "Налаштування"
        private void _setting_()
        {           
            changeSettings Setting = new changeSettings();
            this.Hide();
            Setting.ShowDialog();
            defaultValueAReviewOfA();
            defaultValueAReviewOfB();
            
        }
        private void settings_Click(object sender, EventArgs e)
        {
            _setting_();
            this.Show();
        }
        private void infoSettings_Click(object sender, EventArgs e)
        {
            _setting_();
            this.Show();
        }
        #endregion
    }
}