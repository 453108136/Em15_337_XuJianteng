using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace informationsafety
{
    public partial class Mainpage : Form
    {
        public Mainpage()
        {
            InitializeComponent();
        }

        private void Mainpage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DES des = new DES();
            des.Show();
            this.Hide();
        }

        private void threedes_Click(object sender, EventArgs e)
        {

            thribleDES des = new thribleDES();
            des.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            playfair plf = new playfair();
            plf.Show();
            this.Hide();
        }
    }
}
