﻿namespace QuanLyNhaTro
{
    partial class frmThongTinPhanMem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongTinPhanMem));
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbxLogoNhom = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoNhom)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxLogo
            // 
            this.pbxLogo.Location = new System.Drawing.Point(12, 21);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(100, 96);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 0;
            this.pbxLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐỒ ÁN LẬP TRÌNH WINDOWS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(142, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(421, 66);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thiết kế phần mềm quản lý nhà trọ\r\nEntity Framework\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(189, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 72);
            this.label3.TabIndex = 3;
            this.label3.Text = "GVHD: THS. NGUYỄN MINH ĐẠO\r\nMÃ HP: WIPR230579_21_2_09\r\nHỌC KỲ: 2 - NĂM HỌC: 2021/" +
    "2022";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(189, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 72);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nhóm sinh viên thực hiện:\r\nNguyễn Văn Thuận - 20110732\r\nPhan Quan Huy - 20110652";
            // 
            // pbxLogoNhom
            // 
            this.pbxLogoNhom.Location = new System.Drawing.Point(522, 294);
            this.pbxLogoNhom.Name = "pbxLogoNhom";
            this.pbxLogoNhom.Size = new System.Drawing.Size(135, 119);
            this.pbxLogoNhom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogoNhom.TabIndex = 5;
            this.pbxLogoNhom.TabStop = false;
            // 
            // frmThongTinPhanMem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(669, 425);
            this.Controls.Add(this.pbxLogoNhom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongTinPhanMem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin phần mềm";
            this.Load += new System.EventHandler(this.frmThongTinPhanMem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoNhom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbxLogoNhom;
    }
}