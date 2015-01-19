namespace settings
{
    partial class changeSettings
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changeSettings));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.infoEditElement = new System.Windows.Forms.Label();
            this.editElement = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.infoSaveElement = new System.Windows.Forms.Label();
            this.saveElement = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.infoAddElement = new System.Windows.Forms.Label();
            this.addElement = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.infoDeleteElement = new System.Windows.Forms.Label();
            this.deleteElement = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nameOfType = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.infoHistory = new System.Windows.Forms.Label();
            this.history = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 62);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(605, 323);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "№";
            this.columnHeader1.Width = 51;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Назва";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 548;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(236, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Налаштування";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 176);
            this.panel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(605, 34);
            this.panel3.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(-1, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 146);
            this.panel2.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.infoEditElement);
            this.groupBox2.Controls.Add(this.editElement);
            this.groupBox2.Location = new System.Drawing.Point(117, -7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(121, 146);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // infoEditElement
            // 
            this.infoEditElement.AutoSize = true;
            this.infoEditElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoEditElement.Location = new System.Drawing.Point(10, 118);
            this.infoEditElement.Name = "infoEditElement";
            this.infoEditElement.Size = new System.Drawing.Size(96, 16);
            this.infoEditElement.TabIndex = 30;
            this.infoEditElement.Text = "Редагувати";
            this.infoEditElement.Click += new System.EventHandler(this.infoEditElement_Click);
            // 
            // editElement
            // 
            this.editElement.FlatAppearance.BorderSize = 0;
            this.editElement.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.editElement.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.editElement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editElement.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.editElement.Location = new System.Drawing.Point(4, 8);
            this.editElement.Name = "editElement";
            this.editElement.Size = new System.Drawing.Size(115, 101);
            this.editElement.TabIndex = 25;
            this.editElement.UseVisualStyleBackColor = false;
            this.editElement.Click += new System.EventHandler(this.editElement_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.infoSaveElement);
            this.groupBox4.Controls.Add(this.saveElement);
            this.groupBox4.Location = new System.Drawing.Point(237, -7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(121, 146);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // infoSaveElement
            // 
            this.infoSaveElement.AutoSize = true;
            this.infoSaveElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoSaveElement.Location = new System.Drawing.Point(23, 118);
            this.infoSaveElement.Name = "infoSaveElement";
            this.infoSaveElement.Size = new System.Drawing.Size(78, 16);
            this.infoSaveElement.TabIndex = 29;
            this.infoSaveElement.Text = "Зберегти";
            this.infoSaveElement.Click += new System.EventHandler(this.infoSaveElement_Click);
            // 
            // saveElement
            // 
            this.saveElement.FlatAppearance.BorderSize = 0;
            this.saveElement.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.saveElement.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.saveElement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveElement.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveElement.Location = new System.Drawing.Point(5, 9);
            this.saveElement.Name = "saveElement";
            this.saveElement.Size = new System.Drawing.Size(111, 101);
            this.saveElement.TabIndex = 26;
            this.saveElement.UseVisualStyleBackColor = false;
            this.saveElement.Click += new System.EventHandler(this.saveElement_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.infoAddElement);
            this.groupBox1.Controls.Add(this.addElement);
            this.groupBox1.Location = new System.Drawing.Point(-2, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // infoAddElement
            // 
            this.infoAddElement.AutoSize = true;
            this.infoAddElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoAddElement.Location = new System.Drawing.Point(28, 118);
            this.infoAddElement.Name = "infoAddElement";
            this.infoAddElement.Size = new System.Drawing.Size(62, 16);
            this.infoAddElement.TabIndex = 31;
            this.infoAddElement.Text = "Додати";
            this.infoAddElement.Click += new System.EventHandler(this.infoAddElement_Click);
            // 
            // addElement
            // 
            this.addElement.FlatAppearance.BorderSize = 0;
            this.addElement.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.addElement.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.addElement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addElement.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addElement.Location = new System.Drawing.Point(10, 9);
            this.addElement.Name = "addElement";
            this.addElement.Size = new System.Drawing.Size(108, 101);
            this.addElement.TabIndex = 24;
            this.addElement.UseVisualStyleBackColor = false;
            this.addElement.Click += new System.EventHandler(this.addElement_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.infoDeleteElement);
            this.groupBox3.Controls.Add(this.deleteElement);
            this.groupBox3.Location = new System.Drawing.Point(357, -7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(121, 146);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // infoDeleteElement
            // 
            this.infoDeleteElement.AutoSize = true;
            this.infoDeleteElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoDeleteElement.Location = new System.Drawing.Point(16, 118);
            this.infoDeleteElement.Name = "infoDeleteElement";
            this.infoDeleteElement.Size = new System.Drawing.Size(80, 16);
            this.infoDeleteElement.TabIndex = 28;
            this.infoDeleteElement.Text = "Видалити";
            this.infoDeleteElement.Click += new System.EventHandler(this.infoDeleteElement_Click);
            // 
            // deleteElement
            // 
            this.deleteElement.FlatAppearance.BorderSize = 0;
            this.deleteElement.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.deleteElement.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.deleteElement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteElement.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteElement.Location = new System.Drawing.Point(4, 9);
            this.deleteElement.Name = "deleteElement";
            this.deleteElement.Size = new System.Drawing.Size(111, 101);
            this.deleteElement.TabIndex = 27;
            this.deleteElement.UseVisualStyleBackColor = false;
            this.deleteElement.Click += new System.EventHandler(this.deleteElement_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.listView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 175);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(607, 387);
            this.panel4.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.nameOfType);
            this.panel5.Location = new System.Drawing.Point(-1, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(607, 60);
            this.panel5.TabIndex = 1;
            // 
            // nameOfType
            // 
            this.nameOfType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameOfType.Location = new System.Drawing.Point(3, 3);
            this.nameOfType.Multiline = true;
            this.nameOfType.Name = "nameOfType";
            this.nameOfType.Size = new System.Drawing.Size(597, 50);
            this.nameOfType.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.infoHistory);
            this.groupBox5.Controls.Add(this.history);
            this.groupBox5.Location = new System.Drawing.Point(477, -7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(128, 146);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            // 
            // infoHistory
            // 
            this.infoHistory.AutoSize = true;
            this.infoHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoHistory.Location = new System.Drawing.Point(24, 118);
            this.infoHistory.Name = "infoHistory";
            this.infoHistory.Size = new System.Drawing.Size(58, 16);
            this.infoHistory.TabIndex = 28;
            this.infoHistory.Text = "Історія";
            this.infoHistory.Click += new System.EventHandler(this.infoHistory_Click);
            // 
            // history
            // 
            this.history.FlatAppearance.BorderSize = 0;
            this.history.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.history.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.history.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.history.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.history.Location = new System.Drawing.Point(4, 9);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(111, 101);
            this.history.TabIndex = 27;
            this.history.UseVisualStyleBackColor = false;
            this.history.Click += new System.EventHandler(this.history_Click);
            // 
            // changeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 562);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "changeSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Налаштування";
            this.Load += new System.EventHandler(this.changeSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button addElement;
        private System.Windows.Forms.Button editElement;
        private System.Windows.Forms.Button saveElement;
        private System.Windows.Forms.Button deleteElement;
        private System.Windows.Forms.Label infoEditElement;
        private System.Windows.Forms.Label infoSaveElement;
        private System.Windows.Forms.Label infoAddElement;
        private System.Windows.Forms.Label infoDeleteElement;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox nameOfType;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label infoHistory;
        private System.Windows.Forms.Button history;


    }
}

