using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace historyOfCertificate
{
    public partial class historyCertificate : Form
    {
        public historyCertificate()
        {
            InitializeComponent();
        }

        private struct Records
        {
            public string day;
            public string month;
            public string year;
            public string Surname;
            public string Name;
            public string MiddleName;
            public string DateOfBirth;
            public string Address;
            public string AReviewOfA;
            public string AReviewOfB;
            public string AReviewOfC;
            public string Valid;
        }  private Records rec;

        // оголошення  лінійнійного списку\
        private LinkedList<Records> lst = new LinkedList<Records>();
        // оголошення  лінійнійного списку\
        private LinkedList<Records> lstSearchResults = new LinkedList<Records>();

        public void functionAddElement(string[] arrSearch)
        {
            fillingValues();
            rec.day = arrSearch[0];
            rec.month = arrSearch[1];
            rec.year = arrSearch[2];
            rec.Surname = arrSearch[3];
            rec.Name = arrSearch[4];
            rec.MiddleName = arrSearch[5];
            rec.DateOfBirth = arrSearch[6];
            rec.Address = arrSearch[7];
            rec.AReviewOfA = arrSearch[8];
            rec.AReviewOfB = arrSearch[9];
            rec.AReviewOfC = arrSearch[10];
            rec.Valid = arrSearch[11];
            lst.AddLast(rec);
            int n = listView1.Items.Count + 1;
            int index = listView1.Items.Add(n.ToString()).Index;
            for (int i = 0; i < 12; i++)
            {
                listView1.Items[index].SubItems.Add(arrSearch[i]);
            }
            functionSave();
        }
        private void functionSave()
        {
            String fname = @"database\history.dat";
            int ncol = 13;
            int i, j, n;
            char delim = (char)9; // роздільник полів - Tab 
            string s, sitem, sdelim = delim.ToString();
            // відкрити потік для запису 
            StreamWriter streamwriter = new StreamWriter(fname);
            n = listView1.Items.Count; // кількість записів 
            for (i = 0; i < n; i++) // цикл по записах 
            {
                s = "";
                for (j = 0; j < ncol; j++) // цикл по полях запису 
                {
                    sitem = listView1.Items[i].SubItems[j].Text;
                    s = s + sitem + sdelim;
                }
                streamwriter.WriteLine(s); // запис у файл 
            }
            streamwriter.Close(); // закрити потік 
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            listView1.Items[0].BackColor = ColorTranslator.FromHtml("#FFFFFF");
            int ind = listView1.FocusedItem.Index;
        }
        private void fillingValues()
        {
            int jj = listView1.Items.Count;
            if (jj > 0)
            {
                for (int i = 0; i < jj; i++)
                {
                    listView1.Items[0].Remove();
                }
                lst.Clear();
            }
            int counting = lst.Count;
            String fname = @"database\history.dat";
            Records cur;
            cur.day = null;
            cur.month = null;
            cur.year = null;
            cur.Surname = null;
            cur.Name = null;
            cur.MiddleName = null;
            cur.DateOfBirth = null;
            cur.Address = null;
            cur.AReviewOfA = null;
            cur.AReviewOfB = null;
            cur.AReviewOfC = null;
            cur.Valid = null;
            if (File.Exists(fname)) // якщо файл існує 
            {
                String line;
                Int64 countLine = 0;
                string item = "", sc = "", sd = "";
                char delim = (char)9;
                int i = 0, n = 0, j = 0, l = 0, p = 0, index = 0;
                // відкрити потік для читання 
                StreamReader streamreader = new StreamReader(fname);
                streamreader.BaseStream.Position = 0;
                while ((line = streamreader.ReadLine()) != null) //читаем по одной линии(строке) пока не вычитаем все из потока (пока не достигнем конца файла)
                {
                    countLine++;
                }

                String[] buf = new String[countLine]; // буфер рядків 
                streamreader.BaseStream.Position = 0;
                // поки є записи 
                while ((item = streamreader.ReadLine()) != null)
                {
                    buf[i] = item; i++; // зберігати записи в буфері 
                }
                streamreader.Close(); // закрити потік 
                n = i; // запам'ятати кількість записів 
                if (n > 0)
                {
                    for (i = 0; i < n; i++) // цикл по записах 
                    {
                        item = buf[i] + delim.ToString(); // запам'ятати запис 
                        l = item.Length; // довжина запису 
                        j = 0;
                        while (l > 1) // цикл по рядку 
                        {
                            // позиція роздільника полів 
                            p = item.IndexOf(delim);
                            if (p > 0)
                            {
                                // копіюємо частину рядка 
                                sc = item.Substring(0, p);
                                // заносимо в список поле 0 
                                if (j == 0)
                                {
                                    if (cur.day != null &&
                                    cur.month != null &&
                                    cur.year != null &&
                                    cur.Surname != null &&
                                    cur.Name != null &&
                                    cur.MiddleName != null &&
                                    cur.DateOfBirth != null &&
                                    cur.Address != null &&
                                    cur.AReviewOfA != null &&
                                    cur.AReviewOfB != null &&
                                    cur.AReviewOfC != null &&
                                    cur.Valid != null)
                                    {
                                        lst.AddLast(cur);
                                        cur.day = null;
                                        cur.month = null;
                                        cur.year = null;
                                        cur.Surname = null;
                                        cur.Name = null;
                                        cur.MiddleName = null;
                                        cur.DateOfBirth = null;
                                        cur.Address = null;
                                        cur.AReviewOfA = null;
                                        cur.AReviewOfB = null;
                                        cur.AReviewOfC = null;
                                        cur.Valid = null;
                                    }
                                    index = listView1.Items.Add(sc).Index;
                                }
                                // заносимо в список решту полів 
                                else
                                {
                                    if (j == 1) cur.day = sc;
                                    else if (j == 2) cur.month = sc;
                                    else if (j == 3) cur.year = sc;
                                    else if (j == 4) cur.Surname = sc;
                                    else if (j == 5) cur.Name = sc;
                                    else if (j == 6) cur.MiddleName = sc;
                                    else if (j == 7) cur.DateOfBirth = sc;
                                    else if (j == 8) cur.Address = sc;
                                    else if (j == 9) cur.AReviewOfA = sc;
                                    else if (j == 10) cur.AReviewOfB = sc;
                                    else if (j == 11) cur.AReviewOfC = sc;
                                    else if (j == 12) cur.Valid = sc;
                                    listView1.Items[index].SubItems.Add(sc);
                                }
                                // зберігаємо частину рядка, що залишилася 
                                sd = item.Substring(p + 1, l - p - 1);
                                item = sd;
                                // визначаємо довжину частини рядка, що залишилася 
                                l = item.Length;
                                j++; // перехід до наступного поля 
                            }
                        }
                    }
                }
            }
            if (cur.day != null &&
            cur.month != null &&
            cur.year != null &&
            cur.Surname != null &&
            cur.Name != null &&
            cur.MiddleName != null &&
            cur.DateOfBirth != null &&
            cur.Address != null &&
            cur.AReviewOfA != null &&
            cur.AReviewOfB != null &&
            cur.AReviewOfC != null &&
            cur.Valid != null)
            {
                lst.AddLast(cur);
                cur.day = null;
                cur.month = null;
                cur.year = null;
                cur.Surname = null;
                cur.Name = null;
                cur.MiddleName = null;
                cur.DateOfBirth = null;
                cur.Address = null;
                cur.AReviewOfA = null;
                cur.AReviewOfB = null;
                cur.AReviewOfC = null;
                cur.Valid = null;
            }
            int i1 = lst.Count - 1;
            for (; i1 >= 0; i1--)
            {
                try
                {
                    listView1.Items.Remove(listView1.Items[i1]);
                }
                catch
                {
                    continue;
                }
            }
            i1 = 0;
            for (LinkedListNode<Records> itm = lst.First; itm != null; itm = itm.Next)
            {
                int n = listView1.Items.Count + 1;
                int index = listView1.Items.Add(n.ToString()).Index;
                listView1.Items[index].SubItems.Add(itm.Value.day);
                listView1.Items[index].SubItems.Add(itm.Value.month);
                listView1.Items[index].SubItems.Add(itm.Value.year);
                listView1.Items[index].SubItems.Add(itm.Value.Surname);
                listView1.Items[index].SubItems.Add(itm.Value.Name);
                listView1.Items[index].SubItems.Add(itm.Value.MiddleName);
                listView1.Items[index].SubItems.Add(itm.Value.DateOfBirth);
                listView1.Items[index].SubItems.Add(itm.Value.Address);
                listView1.Items[index].SubItems.Add(itm.Value.AReviewOfA);
                listView1.Items[index].SubItems.Add(itm.Value.AReviewOfB);
                listView1.Items[index].SubItems.Add(itm.Value.AReviewOfC);
                listView1.Items[index].SubItems.Add(itm.Value.Valid);
            }
        }
        private void historyCertificate_Load(object sender, EventArgs e)
        {
            fillingValues();
            try
            {
                Bitmap backImage = new Bitmap(@"images\back.png");
                back.Image = backImage;
            }
            catch
            {
                back.Image = null;
            }
            try
            {
                Bitmap searchImage = new Bitmap(@"images\search.png");
                search.Image = searchImage;
            }
            catch
            {
                search.Image = null;
            }
            try
            {
                Bitmap cancelImage = new Bitmap(@"images\cancel.png");
                cancel.Image = cancelImage;
            }
            catch
            {
                cancel.Image = null;
            }
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
        }
        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void infoBack_1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void infoBack_2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearSearch()
        {
            int jj = listView1.Items.Count;
            if (jj > 0)
            {
                for (int i = 0; i < jj; i++)
                {
                    listView1.Items[0].Remove();
                }
                lst.Clear();
            }
            fillingValues();
        }
        private void addSearch(int i)
        {
            rec.day = listView1.Items[i].SubItems[1].Text;
            rec.month = listView1.Items[i].SubItems[2].Text;
            rec.year = listView1.Items[i].SubItems[3].Text;
            rec.Surname = listView1.Items[i].SubItems[4].Text;
            rec.Name = listView1.Items[i].SubItems[5].Text;
            rec.MiddleName = listView1.Items[i].SubItems[6].Text;
            rec.DateOfBirth = listView1.Items[i].SubItems[7].Text;
            rec.Address = listView1.Items[i].SubItems[8].Text;
            rec.AReviewOfA = listView1.Items[i].SubItems[9].Text;
            rec.AReviewOfB = listView1.Items[i].SubItems[10].Text;
            rec.AReviewOfC = listView1.Items[i].SubItems[11].Text;
            rec.Valid = listView1.Items[i].SubItems[12].Text;
            lstSearchResults.AddLast(rec);
        }
        private void search_Click(object sender, EventArgs e)
        {
            //0000
            if (inputDateOfBirthDay.Text == "" && inputDateOfBirthMonth.Text == "" &&
            inputDateOfBirthYear.Text == "" && textBox1.Text == "")
            {
                clearSearch();
            }
            else
            {
                clearSearch();
                lstSearchResults.Clear();
                int jj = listView1.Items.Count;
                if (jj == 0)
                {
                    fillingValues();
                    jj = listView1.Items.Count;
                }
                if (jj > 0)
                {

                    //1111
                    if (inputDateOfBirthDay.Text != "" && inputDateOfBirthMonth.Text != "" &&
                    inputDateOfBirthYear.Text != "" && textBox1.Text != "")
                    {
                        for (int i = 0; i < jj; i++)
                            if (listView1.Items[i].SubItems[1].Text == inputDateOfBirthDay.Text &&
                            listView1.Items[i].SubItems[2].Text == inputDateOfBirthMonth.Text &&
                            listView1.Items[i].SubItems[3].Text == inputDateOfBirthYear.Text &&
                            listView1.Items[i].SubItems[4].Text == textBox1.Text)
                            {
                                addSearch(i);
                            }
                    }
                    else
                        //0001
                        if (inputDateOfBirthDay.Text == "" && inputDateOfBirthMonth.Text == "" &&
                        inputDateOfBirthYear.Text == "" && textBox1.Text != "")
                        {
                            for (int i = 0; i < jj; i++)
                                if (listView1.Items[i].SubItems[4].Text == textBox1.Text)
                                {
                                    addSearch(i);
                                }
                        }
                        else
                            //0010
                            if (inputDateOfBirthDay.Text == "" && inputDateOfBirthMonth.Text == "" &&
                            inputDateOfBirthYear.Text != "" && textBox1.Text == "")
                            {
                                for (int i = 0; i < jj; i++)
                                    if (listView1.Items[i].SubItems[3].Text == inputDateOfBirthYear.Text)
                                    {
                                        addSearch(i);
                                    }
                            }
                            else
                                //0011
                                if (inputDateOfBirthDay.Text == "" && inputDateOfBirthMonth.Text == "" &&
                                inputDateOfBirthYear.Text != "" && textBox1.Text != "")
                                {
                                    for (int i = 0; i < jj; i++)
                                        if (listView1.Items[i].SubItems[3].Text == inputDateOfBirthYear.Text &&
                                        listView1.Items[i].SubItems[4].Text == textBox1.Text)
                                        {
                                            addSearch(i);
                                        }
                                }
                                else
                                    //0100
                                    if (inputDateOfBirthDay.Text == "" && inputDateOfBirthMonth.Text != "" &&
                                    inputDateOfBirthYear.Text == "" && textBox1.Text == "")
                                    {
                                        for (int i = 0; i < jj; i++)
                                            if (listView1.Items[i].SubItems[2].Text == inputDateOfBirthMonth.Text)
                                            {
                                                addSearch(i);
                                            }
                                    }
                                    else
                                        //0101
                                        if (inputDateOfBirthDay.Text == "" && inputDateOfBirthMonth.Text != "" &&
                                        inputDateOfBirthYear.Text == "" && textBox1.Text != "")
                                        {
                                            for (int i = 0; i < jj; i++)
                                                if (listView1.Items[i].SubItems[2].Text == inputDateOfBirthMonth.Text &&
                                                listView1.Items[i].SubItems[4].Text == textBox1.Text)
                                                {
                                                    addSearch(i);
                                                }
                                        }
                                        else
                                            //0110
                                            if (inputDateOfBirthDay.Text == "" && inputDateOfBirthMonth.Text != "" &&
                                            inputDateOfBirthYear.Text != "" && textBox1.Text == "")
                                            {
                                                for (int i = 0; i < jj; i++)
                                                    if (listView1.Items[i].SubItems[2].Text == inputDateOfBirthMonth.Text &&
                                                    listView1.Items[i].SubItems[3].Text == inputDateOfBirthYear.Text)
                                                    {
                                                        addSearch(i);
                                                    }
                                            }
                                            else
                                                //0111
                                                if (inputDateOfBirthDay.Text == "" && inputDateOfBirthMonth.Text != "" &&
                                                inputDateOfBirthYear.Text != "" && textBox1.Text != "")
                                                {
                                                    for (int i = 0; i < jj; i++)
                                                        if (listView1.Items[i].SubItems[2].Text == inputDateOfBirthMonth.Text &&
                                                        listView1.Items[i].SubItems[3].Text == inputDateOfBirthYear.Text &&
                                                        listView1.Items[i].SubItems[4].Text == textBox1.Text)
                                                        {
                                                            addSearch(i);
                                                        }
                                                }
                                                else
                                                    //1000
                                                    if (inputDateOfBirthDay.Text != "" && inputDateOfBirthMonth.Text == "" &&
                                                    inputDateOfBirthYear.Text == "" && textBox1.Text == "")
                                                    {
                                                        for (int i = 0; i < jj; i++)
                                                            if (listView1.Items[i].SubItems[1].Text == inputDateOfBirthDay.Text)
                                                            {
                                                                addSearch(i);
                                                            }
                                                    }
                                                    else
                                                        //1001
                                                        if (inputDateOfBirthDay.Text != "" && inputDateOfBirthMonth.Text == "" &&
                                                        inputDateOfBirthYear.Text == "" && textBox1.Text != "")
                                                        {
                                                            for (int i = 0; i < jj; i++)
                                                                if (listView1.Items[i].SubItems[1].Text == inputDateOfBirthDay.Text &&
                                                                listView1.Items[i].SubItems[4].Text == textBox1.Text)
                                                                {
                                                                    addSearch(i);
                                                                }
                                                        }
                                                        else
                                                            //1010
                                                            if (inputDateOfBirthDay.Text != "" && inputDateOfBirthMonth.Text == "" &&
                                                            inputDateOfBirthYear.Text != "" && textBox1.Text == "")
                                                            {
                                                                for (int i = 0; i < jj; i++)
                                                                    if (listView1.Items[i].SubItems[1].Text == inputDateOfBirthDay.Text &&
                                                                    listView1.Items[i].SubItems[3].Text == inputDateOfBirthYear.Text)
                                                                    {
                                                                        addSearch(i);
                                                                    }
                                                            }
                                                            else
                                                                //1011
                                                                if (inputDateOfBirthDay.Text != "" && inputDateOfBirthMonth.Text == "" &&
                                                                inputDateOfBirthYear.Text != "" && textBox1.Text != "")
                                                                {
                                                                    for (int i = 0; i < jj; i++)
                                                                        if (listView1.Items[i].SubItems[1].Text == inputDateOfBirthDay.Text &&
                                                                        listView1.Items[i].SubItems[3].Text == inputDateOfBirthYear.Text &&
                                                                        listView1.Items[i].SubItems[4].Text == textBox1.Text)
                                                                        {
                                                                            addSearch(i);
                                                                        }
                                                                }
                                                                else
                                                                    //1100
                                                                    if (inputDateOfBirthDay.Text != "" && inputDateOfBirthMonth.Text != "" &&
                                                                    inputDateOfBirthYear.Text == "" && textBox1.Text == "")
                                                                    {
                                                                        for (int i = 0; i < jj; i++)
                                                                            if (listView1.Items[i].SubItems[1].Text == inputDateOfBirthDay.Text &&
                                                                            listView1.Items[i].SubItems[2].Text == inputDateOfBirthMonth.Text)
                                                                            {
                                                                                addSearch(i);
                                                                            }
                                                                    }
                                                                    else
                                                                        //1101
                                                                        if (inputDateOfBirthDay.Text != "" && inputDateOfBirthMonth.Text != "" &&
                                                                        inputDateOfBirthYear.Text == "" && textBox1.Text != "")
                                                                        {
                                                                            for (int i = 0; i < jj; i++)
                                                                                if (listView1.Items[i].SubItems[1].Text == inputDateOfBirthDay.Text &&
                                                                                listView1.Items[i].SubItems[2].Text == inputDateOfBirthMonth.Text &&
                                                                                listView1.Items[i].SubItems[4].Text == textBox1.Text)
                                                                                {
                                                                                    addSearch(i);
                                                                                }
                                                                        }
                                                                        else
                                                                            //1110
                                                                            if (inputDateOfBirthDay.Text != "" && inputDateOfBirthMonth.Text != "" &&
                                                                            inputDateOfBirthYear.Text != "" && textBox1.Text == "")
                                                                            {
                                                                                for (int i = 0; i < jj; i++)
                                                                                    if (listView1.Items[i].SubItems[1].Text == inputDateOfBirthDay.Text &&
                                                                                    listView1.Items[i].SubItems[2].Text == inputDateOfBirthMonth.Text &&
                                                                                    listView1.Items[i].SubItems[3].Text == inputDateOfBirthYear.Text)
                                                                                    {
                                                                                        addSearch(i);
                                                                                    }
                                                                            }
                    for (int i = 0; i < jj; i++)
                    {
                        listView1.Items[0].Remove();
                    }
                    lst.Clear();
                }
                int counting = lstSearchResults.Count;
                if (counting > 0)
                {
                    for (LinkedListNode<Records> itm = lstSearchResults.First; itm != null; itm = itm.Next)
                    {
                        int n = listView1.Items.Count + 1;
                        int index = listView1.Items.Add(n.ToString()).Index;
                        listView1.Items[index].SubItems.Add(itm.Value.day);
                        listView1.Items[index].SubItems.Add(itm.Value.month);
                        listView1.Items[index].SubItems.Add(itm.Value.year);
                        listView1.Items[index].SubItems.Add(itm.Value.Surname);
                        listView1.Items[index].SubItems.Add(itm.Value.Name);
                        listView1.Items[index].SubItems.Add(itm.Value.MiddleName);
                        listView1.Items[index].SubItems.Add(itm.Value.DateOfBirth);
                        listView1.Items[index].SubItems.Add(itm.Value.Address);
                        listView1.Items[index].SubItems.Add(itm.Value.AReviewOfA);
                        listView1.Items[index].SubItems.Add(itm.Value.AReviewOfB);
                        listView1.Items[index].SubItems.Add(itm.Value.AReviewOfC);
                        listView1.Items[index].SubItems.Add(itm.Value.Valid);
                    }
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            inputDateOfBirthDay.Text = "";
            inputDateOfBirthMonth.Text = "";
            inputDateOfBirthYear.Text = "";
            textBox1.Text = "";
            clearSearch();
        }

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

        private void inputDateOfBirthDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }

        private void inputDateOfBirthMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }

        private void inputDateOfBirthYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyDigit(sender, e);
        }

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

        private void inputDateOfBirthDay_Leave(object sender, EventArgs e)
        {
            if (inputDateOfBirthDay.Text != "")
            {
                inputDateOfBirthDay.Text = inputAfterLeaveForDay(inputDateOfBirthDay.Text,
        inputDateOfBirthMonth.Text, inputDateOfBirthYear.Text);
            }
        }

        private void inputDateOfBirthMonth_Leave(object sender, EventArgs e)
        {
            if (inputDateOfBirthMonth.Text != "")
            {
                inputDateOfBirthMonth.Text = inputAfterLeaveForMonth(inputDateOfBirthDay.Text,
    inputDateOfBirthMonth.Text, inputDateOfBirthYear.Text);
            }
        }

        private void inputDateOfBirthYear_Leave(object sender, EventArgs e)
        {
            if (inputDateOfBirthYear.Text != "")
            {
                inputDateOfBirthYear.Text = inputAfterLeaveForYear(inputDateOfBirthDay.Text,
inputDateOfBirthMonth.Text, inputDateOfBirthYear.Text);
            }
        }



    }
}
