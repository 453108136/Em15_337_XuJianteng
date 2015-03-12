namespace informationsafety
{
    partial class DES
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
            this.plaintext = new System.Windows.Forms.TextBox();
            this.key = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ciphertext = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.keyWrong = new System.Windows.Forms.Label();
            this.chiperteztWrong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // plaintext
            // 
            this.plaintext.AcceptsReturn = true;
            this.plaintext.AcceptsTab = true;
            this.plaintext.Location = new System.Drawing.Point(47, 38);
            this.plaintext.Multiline = true;
            this.plaintext.Name = "plaintext";
            this.plaintext.Size = new System.Drawing.Size(321, 171);
            this.plaintext.TabIndex = 0;
            // 
            // key
            // 
            this.key.Location = new System.Drawing.Point(47, 454);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(321, 21);
            this.key.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 495);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "加密";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(272, 495);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "解密";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "明文";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "密钥(8字符）";
            // 
            // ciphertext
            // 
            this.ciphertext.Location = new System.Drawing.Point(47, 253);
            this.ciphertext.Multiline = true;
            this.ciphertext.Name = "ciphertext";
            this.ciphertext.Size = new System.Drawing.Size(320, 148);
            this.ciphertext.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "密文";
            // 
            // keyWrong
            // 
            this.keyWrong.AutoSize = true;
            this.keyWrong.ForeColor = System.Drawing.Color.Red;
            this.keyWrong.Location = new System.Drawing.Point(128, 439);
            this.keyWrong.Name = "keyWrong";
            this.keyWrong.Size = new System.Drawing.Size(71, 12);
            this.keyWrong.TabIndex = 8;
            this.keyWrong.Text = "请输入8字符";
            this.keyWrong.Visible = false;
            // 
            // chiperteztWrong
            // 
            this.chiperteztWrong.AutoSize = true;
            this.chiperteztWrong.ForeColor = System.Drawing.Color.Red;
            this.chiperteztWrong.Location = new System.Drawing.Point(83, 238);
            this.chiperteztWrong.Name = "chiperteztWrong";
            this.chiperteztWrong.Size = new System.Drawing.Size(89, 12);
            this.chiperteztWrong.TabIndex = 9;
            this.chiperteztWrong.Text = "输入正确的密文";
            this.chiperteztWrong.Visible = false;
            // 
            // DES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 559);
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
            this.Name = "DES";
            this.Text = "DES";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DES_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox plaintext;
        private System.Windows.Forms.TextBox key;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ciphertext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label keyWrong;
        private System.Windows.Forms.Label chiperteztWrong;
    }
}