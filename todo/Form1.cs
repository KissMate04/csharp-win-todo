using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace todo
{
    public partial class Form1 : Form
    {
        StreamWriter sw;
        StreamReader sr;
        List<Item> todoList = new List<Item>();
        public static Item edited;
        string currentPath = Path.GetFullPath(Properties.Settings.Default.DataFilePath);
        string prevPath = Path.GetFullPath(Properties.Settings.Default.DataFilePath);
        public Form1()
        {
            InitializeComponent();
            listBox.DrawMode = DrawMode.OwnerDrawVariable;
            listBox.DrawItem += listBox_DrawItem;
            listBox.MeasureItem += listBox_MeasureItem;
        }

        private void Add()
        {
            if (tbItem.Text != "")
            {
                string date;
                if (!cbNodate.Checked) date = datePicker.Text;
                else date = "";

                bool priority = cbPrio.Checked;

                Item item = new Item(tbItem.Text, date, priority, tbDesc.Text);

                sw = new StreamWriter(currentPath, true);
                sw.WriteLine(item.ToShortString());
                sw.Close();
                todoList.Add(item);
                UpdateList();
                tbItem.Clear();
                tbDesc.Clear();
            }
            tbItem.Focus();
        }

        private void Del()
        {
            int i = listBox.SelectedIndex;
            if (i >= 0)
            {
                todoList.RemoveAt(i);
                sw = new StreamWriter(currentPath);
                foreach (var item in todoList)
                {
                    sw.WriteLine(item.ToShortString());
                }
                sw.Close();
                UpdateList();
            }
        }

        private void UpdateList()
        {
            listBox.Items.Clear();
            foreach (var item in todoList)
            {
                listBox.Items.Add(item.ToString());
            }
        }

        private void InitializeList()
        {
            if (!File.Exists(currentPath))
            {
                MessageBox.Show($"File not found: {currentPath}");
                currentPath = Path.GetFullPath(@"..\..\..\todo.txt");
            }

            sr = new StreamReader(currentPath);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    Item item = Item.Parse(line);
                    if (item != null)
                    {
                        todoList.Add(item);
                        listBox.Items.Add(item.ToString());
                    }

                }
            }
            sr.Close();
        }

        private void ClearAll()
        {
            todoList.Clear();
            sw = new StreamWriter(currentPath);
            sw.Write("");
            sw.Close();
            UpdateList();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            tbPath.Text = currentPath;
            tbPath.Enabled = false;
            InitializeList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void tbItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) Add();
        }

        private void tbDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) Add();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) Add();
        }

        private void listBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back)) Del();
        }

        private void cbNodate_CheckedChanged(object sender, EventArgs e)
        {
            datePicker.Enabled = !cbNodate.Checked;
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            string text = listBox.Items[e.Index].ToString();
            using (var brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, e.Font, brush, e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        private void listBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;
            string text = listBox.Items[e.Index].ToString();
            SizeF size = e.Graphics.MeasureString(text, listBox.Font, listBox.Width);
            e.ItemHeight = (int)size.Height;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save text Files";
            sfd.CheckFileExists = false;
            sfd.CheckPathExists = true;
            sfd.DefaultExt = "txt";
            sfd.Filter = "Text files|*.txt|CSV files|*.csv";
            sfd.FileName = "todo.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName != currentPath)
                {
                    currentPath = sfd.FileName;
                    DialogResult result = MessageBox.Show(
                        "Would you like to transfer your current items to the new file?",
                        "Transfer Items",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question
                    );

                    Properties.Settings.Default.DataFilePath = currentPath;
                    Properties.Settings.Default.Save();

                    if (result == DialogResult.Yes)
                    {
                        TransferToFile();
                    }
                    else if (result == DialogResult.No)
                    {
                        ClearAll();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        currentPath = prevPath;
                        Properties.Settings.Default.DataFilePath = currentPath;
                        Properties.Settings.Default.Save();
                    }
                }

                tbPath.Text = sfd.FileName;
            }
        }

        private void TransferToFile()
        {
            try
            {
                sw = new StreamWriter(currentPath);
                foreach (var item in todoList)
                {

                    sw.Write(item.ToShortString() + "\n");
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error transferring items to file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex >= 0)
            {
                Item item = todoList[listBox.SelectedIndex];
                EditItem editItemForm = new EditItem(item);

                if (editItemForm.ShowDialog() == DialogResult.Yes)
                {
                    InsertEditedItem(listBox.SelectedIndex, edited);
                }


            }


        }
        private void InsertEditedItem(int index, Item item)
        {
            todoList[index] = item;
            sw = new StreamWriter(currentPath);
            foreach (var i in todoList)
            {
                sw.WriteLine(i.ToShortString());
            }
            sw.Close();
            UpdateList();
        }
    }
}