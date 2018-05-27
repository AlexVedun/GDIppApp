using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDIppApp
{
    public partial class Form1 : Form
    {
        private ArrayList ellipsesList = new ArrayList();
        private const int ellipseWidth = 40;
        private const int ellipseHeight = 60;
        private int ellipseX = 0;
        private int ellipseY = 0;
        private Random random = new Random();
        private Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void onClick(int x = 0, int y = 0) {

            if (x != 0 && y != 0)
            {
                ellipseX = x;
                ellipseY = y;
            }
            else {
                ellipseX = random.Next(50, 300);
                ellipseY = random.Next(50, 300);
            }
           
            ellipsesList.Add(new Rectangle(ellipseX, ellipseY, ellipseWidth, ellipseHeight));
            g = this.CreateGraphics();
            this.Refresh();
        }

        private void addEllipseButton_Click(object sender, EventArgs e)
        {
            onClick();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (Rectangle item in ellipsesList)
            {
                g.DrawEllipse(new Pen(Color.Red), item);
                Console.WriteLine(item);
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            onClick(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
        }
    }
}
