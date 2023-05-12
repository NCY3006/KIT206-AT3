namespace RAPForms
{
    partial class cumulativecountform
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
            this.lsbcumulativecount = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(35, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cumulative Count";
            // 
            // lsbcumulativecount
            // 
            this.lsbcumulativecount.FormattingEnabled = true;
            this.lsbcumulativecount.ItemHeight = 15;
            this.lsbcumulativecount.Location = new System.Drawing.Point(35, 61);
            this.lsbcumulativecount.MultiColumn = true;
            this.lsbcumulativecount.Name = "lsbcumulativecount";
            this.lsbcumulativecount.Size = new System.Drawing.Size(414, 349);
            this.lsbcumulativecount.TabIndex = 2;
            // 
            // cumulativecountform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 450);
            this.Controls.Add(this.lsbcumulativecount);
            this.Controls.Add(this.label1);
            this.Name = "cumulativecountform";
            this.Text = "cumulativecountform";
            this.Load += new System.EventHandler(this.cumulativecountform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ListBox lsbcumulativecount;
    }
}