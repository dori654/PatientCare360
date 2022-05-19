using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientCare360.Resources
{
    public partial class Treatment : Form
    {
        public Treatment()
        {
            InitializeComponent();
        }

        public void info_Treatment(string text)
        {
            Treatment_info.Text=text;
        }
        private void Treatment_info_Click(object sender, EventArgs e)
        {

        }
    }
}
