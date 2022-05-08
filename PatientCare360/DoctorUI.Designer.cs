namespace PatientCare360
{
    partial class DoctorUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorUI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MaxmizeBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnPatHistory = new System.Windows.Forms.Button();
            this.btnNewPat = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.btnPatHistory);
            this.panel1.Controls.Add(this.btnNewPat);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 948);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(354, 103);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(354, 760);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1068, 188);
            this.panel2.TabIndex = 1;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.DarkCyan;
            this.panelLeft.Location = new System.Drawing.Point(281, 108);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(10, 111);
            this.panelLeft.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ExitButton);
            this.panel4.Controls.Add(this.MaxmizeBtn);
            this.panel4.Controls.Add(this.minimizeBtn);
            this.panel4.Location = new System.Drawing.Point(1212, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(210, 41);
            this.panel4.TabIndex = 4;
            // 
            // ExitButton
            // 
            this.ExitButton.BackgroundImage = global::PatientCare360.Properties.Resources.icon_close;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(151, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(69, 43);
            this.ExitButton.TabIndex = 11;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MaxmizeBtn
            // 
            this.MaxmizeBtn.BackgroundImage = global::PatientCare360.Properties.Resources.icon_maximize;
            this.MaxmizeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MaxmizeBtn.FlatAppearance.BorderSize = 0;
            this.MaxmizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaxmizeBtn.Location = new System.Drawing.Point(79, 0);
            this.MaxmizeBtn.Name = "MaxmizeBtn";
            this.MaxmizeBtn.Size = new System.Drawing.Size(75, 43);
            this.MaxmizeBtn.TabIndex = 10;
            this.MaxmizeBtn.UseVisualStyleBackColor = true;
            this.MaxmizeBtn.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackgroundImage = global::PatientCare360.Properties.Resources.icon_minimize;
            this.minimizeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Location = new System.Drawing.Point(3, 0);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(76, 43);
            this.minimizeBtn.TabIndex = 9;
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.Location = new System.Drawing.Point(3, 798);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(277, 147);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnPatHistory
            // 
            this.btnPatHistory.FlatAppearance.BorderSize = 0;
            this.btnPatHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatHistory.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatHistory.ForeColor = System.Drawing.Color.White;
            this.btnPatHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnPatHistory.Image")));
            this.btnPatHistory.Location = new System.Drawing.Point(0, 337);
            this.btnPatHistory.Name = "btnPatHistory";
            this.btnPatHistory.Size = new System.Drawing.Size(280, 108);
            this.btnPatHistory.TabIndex = 5;
            this.btnPatHistory.Text = "Patient History";
            this.btnPatHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPatHistory.UseVisualStyleBackColor = true;
            this.btnPatHistory.Click += new System.EventHandler(this.btnPatHistory_Click);
            // 
            // btnNewPat
            // 
            this.btnNewPat.FlatAppearance.BorderSize = 0;
            this.btnNewPat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewPat.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewPat.ForeColor = System.Drawing.Color.White;
            this.btnNewPat.Image = ((System.Drawing.Image)(resources.GetObject("btnNewPat.Image")));
            this.btnNewPat.Location = new System.Drawing.Point(3, 223);
            this.btnNewPat.Name = "btnNewPat";
            this.btnNewPat.Size = new System.Drawing.Size(277, 108);
            this.btnNewPat.TabIndex = 4;
            this.btnNewPat.Text = "New Patient";
            this.btnNewPat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewPat.UseVisualStyleBackColor = true;
            this.btnNewPat.Click += new System.EventHandler(this.btnNewPat_Click);
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(0, 109);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(280, 108);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "Home";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(354, 103);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // DoctorUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1422, 948);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DoctorUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DoctorUI";
            this.Load += new System.EventHandler(this.DoctorUI_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNewPat;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnPatHistory;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button MaxmizeBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Button ExitButton;
    }
}