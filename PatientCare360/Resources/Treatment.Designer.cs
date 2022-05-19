
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
            this.Treatment_info.Location = new System.Drawing.Point(44, 55);
            this.Treatment_info.Name = "Treatment_info";
            this.Treatment_info.Size = new System.Drawing.Size(39, 21);
            this.Treatment_info.TabIndex = 0;
            this.Treatment_info.Text = "Info";
            // 
            // Final_Button_oK
            // 
            this.Final_Button_oK.Location = new System.Drawing.Point(353, 197);
            this.Final_Button_oK.Name = "Final_Button_oK";
            this.Final_Button_oK.Size = new System.Drawing.Size(166, 58);
            this.Final_Button_oK.TabIndex = 1;
            this.Final_Button_oK.Text = "Finish";
            this.Final_Button_oK.UseVisualStyleBackColor = true;
            // 
            // Treatment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 313);
            this.Controls.Add(this.Final_Button_oK);
            this.Controls.Add(this.Treatment_info);
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