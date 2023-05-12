namespace RAPForms
{
    partial class performancereportform
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbpoor = new System.Windows.Forms.ListBox();
            this.lsbbelow = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lsbminimum = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lsbstar = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Performance Report";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Copy Emails";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(48, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Poor";
            // 
            // lsbpoor
            // 
            this.lsbpoor.FormattingEnabled = true;
            this.lsbpoor.ItemHeight = 15;
            this.lsbpoor.Location = new System.Drawing.Point(50, 85);
            this.lsbpoor.Name = "lsbpoor";
            this.lsbpoor.Size = new System.Drawing.Size(339, 79);
            this.lsbpoor.TabIndex = 4;
            // 
            // lsbbelow
            // 
            this.lsbbelow.FormattingEnabled = true;
            this.lsbbelow.ItemHeight = 15;
            this.lsbbelow.Location = new System.Drawing.Point(48, 202);
            this.lsbbelow.Name = "lsbbelow";
            this.lsbbelow.Size = new System.Drawing.Size(341, 79);
            this.lsbbelow.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(48, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Below Expectations";
            // 
            // lsbminimum
            // 
            this.lsbminimum.FormattingEnabled = true;
            this.lsbminimum.ItemHeight = 15;
            this.lsbminimum.Location = new System.Drawing.Point(48, 312);
            this.lsbminimum.Name = "lsbminimum";
            this.lsbminimum.Size = new System.Drawing.Size(341, 79);
            this.lsbminimum.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(48, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Meeting Minimum";
            // 
            // lsbstar
            // 
            this.lsbstar.FormattingEnabled = true;
            this.lsbstar.ItemHeight = 15;
            this.lsbstar.Location = new System.Drawing.Point(48, 425);
            this.lsbstar.Name = "lsbstar";
            this.lsbstar.Size = new System.Drawing.Size(341, 94);
            this.lsbstar.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(48, 402);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Star Performers";
            // 
            // performancereportform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 532);
            this.Controls.Add(this.lsbstar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lsbminimum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lsbbelow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lsbpoor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "performancereportform";
            this.Text = "performancereportform";
            this.Load += new System.EventHandler(this.performancereportform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private ListBox lsbpoor;
        private ListBox lsbbelow;
        private Label label3;
        private ListBox lsbminimum;
        private Label label4;
        private ListBox lsbstar;
        private Label label5;
    }
}