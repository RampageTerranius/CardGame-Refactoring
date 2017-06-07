using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Settings : Form
    {        
        public Settings()
        {
            InitializeComponent();
        }

        public Form form;

        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton) sender;
            if (rb.Checked) {
                switch(rb.Text)
                {
                    case "White":
                        this.form.BackColor = Color.White;
                        break;
                    case "Black":
                        this.form.BackColor = Color.Black;
                        break;
                    case "Grey":
                        this.form.BackColor = Color.LightGray;
                        break;
                    case "Blue":
                        this.form.BackColor = Color.Blue;
                        break;
                    case "Yellow":
                        this.form.BackColor = Color.Yellow;
                        break;
                    case "Green":
                        this.form.BackColor = Color.Green;
                        break;
                }
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
