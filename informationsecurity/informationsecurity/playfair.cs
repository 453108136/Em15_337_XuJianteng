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
    public partial class playfair : Form
    {
        public playfair()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ciphertext.Text = PlayfairFunctions.playfair_Encrypt(this.plaintext.Text, this.key.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.plaintext.Text = PlayfairFunctions.playfair_Decrypt(this.ciphertext.Text, this.key.Text);
        }

        private void playfair_FormClosed(object sender, FormClosedEventArgs e)
        {

            Program.mainpage.Show();
            this.Hide();
        }
    }
}
