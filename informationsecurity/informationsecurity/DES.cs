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
    public partial class DES : Form
    {
        public DES()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key.Text.Length == 8)// && TextHandle.isBcd(key.Text.ToString()))
            {

                keyWrong.Visible = false;
                this.ciphertext.Text = DesFunctions.DES_Encrypt(plaintext.Text.ToString(), key.Text.ToString());
            }
            else
            {
                keyWrong.Visible = true;
            }
        }

        private void DES_Load(object sender, EventArgs e)
        {

        }

        private void DES_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.mainpage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key.Text.Length == 8)// && TextHandle.isBcd(key.Text.ToString()))
            {
                if (true)//this.ciphertext.ToString().Length % 16 == 0)
                {
                    keyWrong.Visible = false;
                    chiperteztWrong.Visible = false;
                    this.plaintext.Text = DesFunctions.DES_Decrypt(ciphertext.Text.ToString(), key.Text.ToString());
                }
                else
                {
                    chiperteztWrong.Visible = true;
                }
            }
            else
            {
                keyWrong.Visible = true;
            }
        }

        private void DES_Load_1(object sender, EventArgs e)
        {

        }
    }
}
