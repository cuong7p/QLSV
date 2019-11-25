namespace Login_
{
    partial class Statics
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
            this.lbNu = new System.Windows.Forms.Label();
            this.lbNam = new System.Windows.Forms.Label();
            this.lbSiso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbNu
            // 
            this.lbNu.BackColor = System.Drawing.Color.PaleGreen;
            this.lbNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNu.Location = new System.Drawing.Point(267, 169);
            this.lbNu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNu.Name = "lbNu";
            this.lbNu.Size = new System.Drawing.Size(168, 101);
            this.lbNu.TabIndex = 5;
            this.lbNu.Text = "Nữ:";
            this.lbNu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNam
            // 
            this.lbNam.BackColor = System.Drawing.Color.Peru;
            this.lbNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNam.Location = new System.Drawing.Point(103, 169);
            this.lbNam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNam.Name = "lbNam";
            this.lbNam.Size = new System.Drawing.Size(168, 101);
            this.lbNam.TabIndex = 4;
            this.lbNam.Text = "Nam:";
            this.lbNam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSiso
            // 
            this.lbSiso.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbSiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSiso.Location = new System.Drawing.Point(103, 68);
            this.lbSiso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSiso.Name = "lbSiso";
            this.lbSiso.Size = new System.Drawing.Size(332, 101);
            this.lbSiso.TabIndex = 3;
            this.lbSiso.Text = "Tổng số học sinh:";
            this.lbSiso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Statics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 338);
            this.Controls.Add(this.lbNu);
            this.Controls.Add(this.lbNam);
            this.Controls.Add(this.lbSiso);
            this.Name = "Statics";
            this.Text = "Statics";
            this.Load += new System.EventHandler(this.Statics_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNu;
        private System.Windows.Forms.Label lbNam;
        private System.Windows.Forms.Label lbSiso;
    }
}