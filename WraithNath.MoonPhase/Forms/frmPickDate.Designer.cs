namespace WraithNath.MoonPhase.Forms
{
    partial class frmPickDate
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
            this.pictureBoxMoon = new System.Windows.Forms.PictureBox();
            this.monthCalendarDate = new System.Windows.Forms.MonthCalendar();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMoon
            // 
            this.pictureBoxMoon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxMoon.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxMoon.Name = "pictureBoxMoon";
            this.pictureBoxMoon.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxMoon.TabIndex = 0;
            this.pictureBoxMoon.TabStop = false;
            // 
            // monthCalendarDate
            // 
            this.monthCalendarDate.BackColor = System.Drawing.Color.Black;
            this.monthCalendarDate.Location = new System.Drawing.Point(72, 12);
            this.monthCalendarDate.MaxSelectionCount = 1;
            this.monthCalendarDate.Name = "monthCalendarDate";
            this.monthCalendarDate.TabIndex = 1;
            this.monthCalendarDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarDate_DateChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(72, 188);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 35);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(224, 186);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 35);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // frmPickDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(311, 235);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.monthCalendarDate);
            this.Controls.Add(this.pictureBoxMoon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPickDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moon Phase - Pick Date";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMoon;
        private System.Windows.Forms.MonthCalendar monthCalendarDate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
    }
}