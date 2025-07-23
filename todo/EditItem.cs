using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace todo
{
    public partial class EditItem : Form
    {
        
        public EditItem()
        {
            InitializeComponent();
            
        }

        public EditItem(Item item) : this()
        {
            EditFormSetup(item);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tbItem.Text != "")
            {
                Form1.edited = new Item(
                    tbItem.Text, cbNodate.Checked ? "" : datePicker.Text, cbPrio.Checked, tbDesc.Text
                );
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                MessageBox.Show("Item title cannot be empty", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void EditFormSetup(Item item) {
            tbItem.Text = item.Title;
            if (item.Date == "")
            {
                cbNodate.Checked = true;
                datePicker.Enabled = false;
            }
            else
            {
                cbNodate.Checked = false;
                datePicker.Enabled = true;
                if (DateTime.TryParse(item.Date, out DateTime date))
                {
                    datePicker.Value = date;
                }
            }
            cbPrio.Checked = item.Priority;
            tbDesc.Text = item.Description;
            tbItem.Focus();
        }

        private void EditItem_Load(object sender, EventArgs e)
        {

        }

        private void EditItem_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void EditItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void cbNodate_CheckedChanged(object sender, EventArgs e)
        {
            datePicker.Enabled = !cbNodate.Checked;
        }
    }
}
