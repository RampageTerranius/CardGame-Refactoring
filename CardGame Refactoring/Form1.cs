using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame_Refactoring
{
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
        }

        Controller controller;
        public Controller Controller
        {
            get
            {
                return controller;
            }

            set
            {
                controller = value;
            }
        }
    }
}
