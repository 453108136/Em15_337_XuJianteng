namespace informationsafety
{
    partial class thribleDES
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chiperteztWrong = new System.Windows.Forms.Label();
            this.keyWrong = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ciphertext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.key = new System.Windows.Forms.TextBox();
            this.plaintext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chiperteztWrong
            // 
            this.chiperteztWrong.AutoSize = true;
            this.chiperteztWrong.ForeColor = System.Drawing.Color.Red;
            this.chiperteztWrong.Location = new System.Drawing.Point(65, 233);
            this.chiperteztWrong.Name = "chiperteztWrong";
            this.chiperteztWrong.Size = new System.Drawing.Size(89, 12);
            this.chiperteztWrong.TabIndex = 19;
            this.chiperteztWrong.Text = "输入正确的密文";
            this.chiperteztWrong.Visible = false;
            // 
            // keyWrong
            // 
            this.keyWrong.AutoSize = true;
            this.keyWrong.ForeColor = System.Drawing.Color.Red;
            this.keyWrong.Location = new System.Drawing.Point(110, 434);
            this.keyWrong.Name = "keyWrong";
            this.keyWrong.Size = new System.Drawing.Size(77, 12);
            this.keyWrong.TabIndex = 18;
            this.keyWrong.Text = "请输入16字符";
            this.keyWrong.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "密文";
            // 
            // ciphertext
            // 
            this.ciphertext.Location = new System.Drawing.Point(29, 248);
            this.ciphertext.Multiline = true;
            this.ciphertext.Name = "ciphertext";
            this.ciphertext.Size = new System.Drawing.Size(320, 148);
            this.ciphertext.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "密钥(16字符）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "明文";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(254, 490);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "解密";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 490);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "加密";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // key
            // 
            this.key.Location = new System.Drawing.Point(29, 449);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(321, 21);
            this.key.TabIndex = 11;
            // 
            // plaintext
            // 
            this.plaintext.AcceptsReturn = true;
            this.plaintext.AcceptsTab = true;
            this.plaintext.Location = new System.Drawing.Point(29, 33);
            this.plaintext.Multiline = true;
            this.plaintext.Name = "plaintext";
            this.plaintext.Size = new System.Drawing.Size(321, 171);
            this.plaintext.TabIndex = 10;
            // 
            // thribleDES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 558);
            this.Controls.Add(this.chiperteztWrong);
            this.Controls.Add(this.keyWrong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ciphertext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.key);
            this.Controls.Add(this.plaintext);
            this.Name = "thribleDES";
            this.Text = "3DES";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.thribleDES_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label chiperteztWrong;
        private System.Windows.Forms.Label keyWrong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ciphertext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox key;
        private System.Windows.Forms.TextBox plaintext;
    }
}