namespace todo
{
    partial class EditItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditItem));
            this.cbNodate = new System.Windows.Forms.CheckBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPrio = new System.Windows.Forms.CheckBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbNodate
            // 
            this.cbNodate.AutoSize = true;
            this.cbNodate.Location = new System.Drawing.Point(260, 33);
            this.cbNodate.Name = "cbNodate";
            this.cbNodate.Size = new System.Drawing.Size(85, 17);
            this.cbNodate.TabIndex = 19;
            this.cbNodate.Text = "No due date";
            this.cbNodate.UseVisualStyleBackColor = true;
            this.cbNodate.CheckedChanged += new System.EventHandler(this.cbNodate_CheckedChanged);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(307, 7);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(139, 20);
            this.datePicker.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "due date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "item:";
            // 
            // cbPrio
            // 
            this.cbPrio.AutoSize = true;
            this.cbPrio.Location = new System.Drawing.Point(67, 33);
            this.cbPrio.Name = "cbPrio";
            this.cbPrio.Size = new System.Drawing.Size(57, 17);
            this.cbPrio.TabIndex = 14;
            this.cbPrio.Text = "Priority";
            this.cbPrio.UseVisualStyleBackColor = true;
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(80, 63);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(357, 134);
            this.tbDesc.TabIndex = 13;
            // 
            // tbItem
            // 
            this.tbItem.Location = new System.Drawing.Point(42, 7);
            this.tbItem.Name = "tbItem";
            this.tbItem.Size = new System.Drawing.Size(200, 20);
            this.tbItem.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(104, 213);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(260, 213);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 21;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // EditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 253);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbNodate);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPrio);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditItem";
            this.Text = "Edit Item";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditItem_FormClosed);
            this.Load += new System.EventHandler(this.EditItem_Load);
            this.Shown += new System.EventHandler(this.EditItem_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbNodate;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbPrio;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.TextBox tbItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
    }
}