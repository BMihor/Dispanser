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
using historyOfCertificate;

namespace settings
{
    public partial class changeSettings : Form
    {
        public changeSettings()
        {
            InitializeComponent();
        }
        private struct Records
        {
            public string name;
        }  private Records rec;
        // оголошення  лінійнійного списку\
        private LinkedList<Records> lst = new LinkedList<Records>();
        private int vidileniy = 0;
        private void functionAddElement()
        {
            if (nameOfType.Text.Length > 0)
            {
                rec.name = nameOfType.Text;
                lst.AddLast(rec);
                int n = listView1.Items.Count + 1;
                int index = listView1.Items.Add(n.ToString()).Index;
                listView1.Items[index].SubItems.Add(nameOfType.Text);
                nameOfType.Text = "";
            }
        }
        private void addElement_Click(object sender, EventArgs e)
        {
            functionAddElement();
        }
        private void infoAddElement_Click(object sender, EventArgs e)
        {
            functionAddElement();
        }
        private void deleteElements(int num)
        {
            try
            {
                rec.name = nameOfType.Text;
                listView1.Items[num].Remove();
                lst.Remove(rec);
                int i = lst.Count - 1;
                for (; i >= 0; i--)
                {
                    listView1.Items.Remove(listView1.Items[i]);
                }
                for (LinkedListNode<Records> itm = lst.First; itm != null; itm = itm.Next)
                {
                    int n = listView1.Items.Count + 1;
                    int index = listView1.Items.Add(n.ToString()).Index;
                    listView1.Items[index].SubItems.Add(itm.Value.name);
                }
            }
            catch
            {
                return;
            }
        }
        private void deleteElement_Click(object sender, EventArgs e)
        {
            try
            {
                int num = listView1.FocusedItem.Index;
                deleteElements(num);
                nameOfType.Text = "";
            }
            catch
            {
                return;
            }
        }
        private void infoDeleteElement_Click(object sender, EventArgs e)
        {
            try
            {
                int num = listView1.FocusedItem.Index;
                deleteElements(num);
                nameOfType.Text = "";
            }
            catch
            {
                return;
            }
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            listView1.Items[vidileniy].BackColor = ColorTranslator.FromHtml("#FFFFFF");
            int ind = listView1.FocusedItem.Index;
            nameOfType.Text = listView1.Items[ind].SubItems[1].Text;
        }
        private void functionEdit()
        {
            try
            {
                rec.name = nameOfType.Text;
                int i = 0;
                int ind = listView1.FocusedItem.Index;
                for (LinkedListNode<Records> itm = lst.First; itm != null; itm = itm.Next)
                {
                    if (i == ind)
                    {
                        itm.Value = rec;
                        break;
                    }
                    i++;
                }
                i = lst.Count - 1;
                for (; i >= 0; i--)
                {
                    listView1.Items.Remove(listView1.Items[i]);
                }
                i = 0;
                for (LinkedListNode<Records> itm = lst.First; itm != null; itm = itm.Next)
                {
                    int n = listView1.Items.Count + 1;
                    int index = listView1.Items.Add(n.ToString()).Index;
                    listView1.Items[index].SubItems.Add(itm.Value.name);
                }
            }
            catch
            {
                return;
            }
            nameOfType.Text = "";
        }
        private void editElement_Click(object sender, EventArgs e)
        {
            functionEdit();
        }
        private void infoEditElement_Click(object sender, EventArgs e)
        {
            functionEdit(); 
        }
        private void functionSave()
        {
            String fname = @"database\database.dat";
            int ncol = 2;

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
            nameOfType.Text = "";
        }
        private void saveElement_Click(object sender, EventArgs e)
        {
            functionSave();
        }
        private void infoSaveElement_Click(object sender, EventArgs e)
        {
            functionSave();
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
            String fname = @"database\database.dat";
            Records cur;
            cur.name = null;
            if (File.Exists(fname)) // якщо файл існує 
            {
                String[] buf = new String[100]; // буфер рядків 
                string item = "", sc = "", sd = "";
                char delim = (char)9;
                int i = 0, n = 0, j = 0, l = 0, p = 0, index = 0;
                // відкрити потік для читання 
                StreamReader streamreader = new StreamReader(fname);
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
                                    if (cur.name != null)
                                    {
                                        lst.AddLast(cur);
                                        cur.name = null;
                                    }
                                    index = listView1.Items.Add(sc).Index;
                                }
                                // заносимо в список решту полів 
                                else
                                {
                                    if (j == 1) cur.name = sc;
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
            if (cur.name != null)
            {
                lst.AddLast(cur);
                cur.name = null;
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
                listView1.Items[index].SubItems.Add(itm.Value.name);
            }
        }
        public int lenghtFillingForString()
        {
            fillingValues();
            int n = listView1.Items.Count;
            return n;
        }
        public string[] fillingForString()
        {
            fillingValues();
            int n = listView1.Items.Count;
            string[] stringArr = new string[n];
            for (int i = 0; i < n; i++)
            {
                stringArr[i] = listView1.Items[i].SubItems[1].Text;
            }
            return stringArr;
        }
        private void changeSettings_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap addElementImage = new Bitmap(@"images\add.png");
                addElement.Image = addElementImage;
            }
            catch
            {
                addElement.Image = null;
            }
            try
            {
                Bitmap editElementImage = new Bitmap(@"images\Edit.png");
                editElement.Image = editElementImage;
            }
            catch 
            {
                editElement.Image = null;
            }
            try
            {
                Bitmap saveImage = new Bitmap(@"images\save.png");
                saveElement.Image = saveImage;
            }
            catch
            {
                saveElement.Image = null;
            }
            try
            {
                Bitmap deleteElementImage = new Bitmap(@"images\delete.png");
                deleteElement.Image = deleteElementImage;
            }
            catch
            {
                deleteElement.Image = null;
            }
            try
            {
                Bitmap HistoryImage = new Bitmap(@"images\history.png");
                history.Image = HistoryImage;
            }
            catch
            {
                history.Image = null;
            }
            fillingValues();
        }
        private void functionHistory()
        {
            historyCertificate programHistory = new historyCertificate();
            this.Hide();
            programHistory.ShowDialog();
        }
        private void history_Click(object sender, EventArgs e)
        { 
            functionHistory();
            this.Show();
        }
        private void infoHistory_Click(object sender, EventArgs e)
        {
            functionHistory();
            this.Show();
        }
    }
}