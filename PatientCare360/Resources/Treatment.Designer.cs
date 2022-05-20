
namespace PatientCare360.Resources
{
    partial class Treatment
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
            this.Treatment_info = new System.Windows.Forms.Label();
            this.Final_Button_oK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Treatment_info
            // 
            this.Treatment_info.AutoSize = true;
            this.Treatment_info.Location = new System.Drawing.Point(22, 29);
            this.Treatment_info.Name = "Treatment_info";
            this.Treatment_info.Size = new System.Drawing.Size(37, 20);
            this.Treatment_info.TabIndex = 0;
            this.Treatment_info.Text = "Info";
            this.Treatment_info.Click += new System.EventHandler(this.Treatment_info_Click);
            // 
            // Final_Button_oK
            // 
            this.Final_Button_oK.Location = new System.Drawing.Point(533, 306);
            this.Final_Button_oK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Final_Button_oK.Name = "Final_Button_oK";
            this.Final_Button_oK.Size = new System.Drawing.Size(187, 72);
            this.Final_Button_oK.TabIndex = 1;
            this.Final_Button_oK.Text = "Finish";
            this.Final_Button_oK.UseVisualStyleBackColor = true;
            this.Final_Button_oK.Click += new System.EventHandler(this.Final_Button_oK_Click);
            // 
            // Treatment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 391);
            this.Controls.Add(this.Final_Button_oK);
            this.Controls.Add(this.Treatment_info);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Treatment";
            this.Text = "Treatment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Treatment_info;
        private System.Windows.Forms.Button Final_Button_oK;
    }
}