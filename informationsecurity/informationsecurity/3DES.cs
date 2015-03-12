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
    public partial class thribleDES : Form
    {
        public thribleDES()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key.Text.Length == 16)
            {

                keyWrong.Visible = false;
                this.ciphertext.Text = DesFunctions.thribleDES_Encrypt(plaintext.Text.ToString(), key.Text.ToString());
            }
            else
            {
                keyWrong.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (key.Text.Length == 16)// && TextHandle.isBcd(key.Text.ToString()))
            {
                keyWrong.Visible = false;
                chiperteztWrong.Visible = false;
                this.plaintext.Text = DesFunctions.thribleDES_Decrypt(ciphertext.Text.ToString(), key.Text.ToString());

            }
            else
            {
                keyWrong.Visible = true;
            }
        }

        private void thribleDES_FormClosed(object sender, FormClosedEventArgs e)
        {

            Program.mainpage.Show();
            this.Hide();
        }
    }
}
