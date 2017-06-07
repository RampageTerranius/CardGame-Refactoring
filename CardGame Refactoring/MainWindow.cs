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
    public partial class MainWindow : Form
    {
        Image[,] img;
        private ClientController controller;
        public ClientController Controller
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


        public MainWindow()
        {
            img = new Bitmap[13, 4];
            for (int i = 0; i < 4; i++)
                for (int n = 0; n < 13; n++)
                {
                    string str = "img\\" + (((Value)n).ToString()+ "_of_" + (Suit)i).ToString() + ".png";
                    
                    img[n, i] = new Bitmap(str);
                    //Console.WriteLine("Image loaded: "+ str);
                }

            
            InitializeComponent();            
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings form = new Settings();
            form.form = this;
            form.Show();
        }

        public void BtnDisable(string label)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    btnDraw.Enabled = false;
                    btnDraw.Text = label;
                }));
            }            
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            controller.NtAdapter.Send(controller.socket, "Draw<EOF>");
            controller.logCMD(0, "Draw<EOF>");
        }

        public void UpdateScreen()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {                    
                    this.Refresh();
                }));
            }            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //if (this.InvokeRequired)
            {
                //this.Invoke(new MethodInvoker(delegate {
                    for (int i = 0; i < controller.Model.player.Hand.GetLength(); i++)
                    {
                        int value = (int)controller.Model.player.Hand.GetValueAt(i).Value;
                        int suit = (int)controller.Model.player.Hand.GetValueAt(i).Suit;
                        e.Graphics.DrawImage(img[value,suit], 10 + (i * 42), 40);                        
                    }
                //}));
            }
            base.OnPaint(e);
        }
    }
}
