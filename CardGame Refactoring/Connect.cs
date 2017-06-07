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
    public partial class Connect : Form
    {
        private MainWindow mainWindow;

        public Connect()
        {
            InitializeComponent();
        }

        public MainWindow MainWindow
        {
            get
            {
                return mainWindow;
            }

            set
            {
                mainWindow = value;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Form window = this.MainWindow;
            this.Hide();
            this.mainWindow.Controller.NtAdapter.Start();
            window.Show();            
        }
    }
}
