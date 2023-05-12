namespace RENESAS_I1C_CRC_CALCULATOR
{
    partial class Form1
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
            this.Btn_cal_crc = new System.Windows.Forms.Button();
            this.Btn_brwse_Hex = new System.Windows.Forms.Button();
            this.Tb_crcval = new System.Windows.Forms.RichTextBox();
            this.Btn_about = new System.Windows.Forms.Button();
            this.Lb_hexfilesize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_cal_crc
            // 
            this.Btn_cal_crc.BackColor = System.Drawing.Color.Pink;
            this.Btn_cal_crc.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_cal_crc.Location = new System.Drawing.Point(111, 173);
            this.Btn_cal_crc.Name = "Btn_cal_crc";
            this.Btn_cal_crc.Size = new System.Drawing.Size(137, 31);
            this.Btn_cal_crc.TabIndex = 0;
            this.Btn_cal_crc.Text = "CALCULATE CRC";
            this.Btn_cal_crc.UseVisualStyleBackColor = false;
            this.Btn_cal_crc.Click += new System.EventHandler(this.Btn_cal_crc_Click);
            // 
            // Btn_brwse_Hex
            // 
            this.Btn_brwse_Hex.BackColor = System.Drawing.Color.LightSalmon;
            this.Btn_brwse_Hex.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_brwse_Hex.Location = new System.Drawing.Point(36, 64);
            this.Btn_brwse_Hex.Name = "Btn_brwse_Hex";
            this.Btn_brwse_Hex.Size = new System.Drawing.Size(290, 31);
            this.Btn_brwse_Hex.TabIndex = 1;
            this.Btn_brwse_Hex.Text = "BROWSE HEX FILE";
            this.Btn_brwse_Hex.UseVisualStyleBackColor = false;
            this.Btn_brwse_Hex.Click += new System.EventHandler(this.Btn_brwse_Hex_Click);
            // 
            // Tb_crcval
            // 
            this.Tb_crcval.BackColor = System.Drawing.Color.Aquamarine;
            this.Tb_crcval.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tb_crcval.Location = new System.Drawing.Point(36, 115);
            this.Tb_crcval.Name = "Tb_crcval";
            this.Tb_crcval.ReadOnly = true;
            this.Tb_crcval.Size = new System.Drawing.Size(290, 28);
            this.Tb_crcval.TabIndex = 2;
            this.Tb_crcval.Text = "";
            this.Tb_crcval.TextChanged += new System.EventHandler(this.Tb_crcval_TextChanged);
            // 
            // Btn_about
            // 
            this.Btn_about.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_about.Location = new System.Drawing.Point(372, 12);
            this.Btn_about.Name = "Btn_about";
            this.Btn_about.Size = new System.Drawing.Size(55, 22);
            this.Btn_about.TabIndex = 3;
            this.Btn_about.Text = "About";
            this.Btn_about.UseVisualStyleBackColor = true;
            this.Btn_about.Click += new System.EventHandler(this.Btn_about_Click);
            // 
            // Lb_hexfilesize
            // 
            this.Lb_hexfilesize.AutoSize = true;
            this.Lb_hexfilesize.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_hexfilesize.Location = new System.Drawing.Point(332, 73);
            this.Lb_hexfilesize.Name = "Lb_hexfilesize";
            this.Lb_hexfilesize.Size = new System.Drawing.Size(70, 16);
            this.Lb_hexfilesize.TabIndex = 4;
            this.Lb_hexfilesize.Text = "FILE SIZE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(446, 268);
            this.Controls.Add(this.Lb_hexfilesize);
            this.Controls.Add(this.Btn_about);
            this.Controls.Add(this.Tb_crcval);
            this.Controls.Add(this.Btn_brwse_Hex);
            this.Controls.Add(this.Btn_cal_crc);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRC CALCULATOR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_cal_crc;
        private System.Windows.Forms.Button Btn_brwse_Hex;
        private System.Windows.Forms.RichTextBox Tb_crcval;
        private System.Windows.Forms.Button Btn_about;
        private System.Windows.Forms.Label Lb_hexfilesize;
    }
}

