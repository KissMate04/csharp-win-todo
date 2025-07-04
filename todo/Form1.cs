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
        List<string> todoList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void ListUpdate()
        {
            
            sr = new StreamReader(@"..\..\..\todo.txt");
            while (!sr.EndOfStream) listBox.Items.Add(sr.ReadLine());
            sr.Close();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ListUpdate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Add() {
            if (tbItem.Text != "")
            {
                string date = "", priority = "";
                if (tbDate.Text != "") date = tbDate.Text;
                if (checkBox.Checked) priority = "!";

                sw = new StreamWriter(@"..\..\..\todo.txt", true);
                sw.WriteLine($"{tbItem.Text}\t{date}\t{priority}");
                sw.Close();
                listBox.Items.Clear();
                ListUpdate();
                tbItem.Clear();
                tbDate.Clear();
            }
            tbItem.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void Del() {
            int i = listBox.SelectedIndex;
            if (i >= 0)
            {
                todoList.Clear();
                sr = new StreamReader(@"..\..\..\todo.txt");
                while (!sr.EndOfStream) { todoList.Add(sr.ReadLine()); }
                sr.Close();
                todoList.RemoveAt(i);
                sw = new StreamWriter(@"..\..\..\todo.txt");
                foreach (var item in todoList)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
                listBox.Items.Clear();
                ListUpdate();
            }
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
    }
}
