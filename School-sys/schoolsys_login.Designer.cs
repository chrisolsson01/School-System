namespace School_sys
{
    partial class schoolsys_login
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
            this.loginForm_gb = new System.Windows.Forms.GroupBox();
            this.formLogin_password_tb = new System.Windows.Forms.TextBox();
            this.formLogin_username_tb = new System.Windows.Forms.TextBox();
            this.loginForm_login_btn = new System.Windows.Forms.Button();
            this.loginForm_password_lbl = new System.Windows.Forms.Label();
            this.loginForm_username_lbl = new System.Windows.Forms.Label();
            this.logo_lbl = new System.Windows.Forms.Label();
            this.close_btn = new System.Windows.Forms.Button();
            this.loginForm_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginForm_gb
            // 
            this.loginForm_gb.Controls.Add(this.formLogin_password_tb);
            this.loginForm_gb.Controls.Add(this.formLogin_username_tb);
            this.loginForm_gb.Controls.Add(this.loginForm_login_btn);
            this.loginForm_gb.Controls.Add(this.loginForm_password_lbl);
            this.loginForm_gb.Controls.Add(this.loginForm_username_lbl);
            this.loginForm_gb.Location = new System.Drawing.Point(249, 101);
            this.loginForm_gb.Name = "loginForm_gb";
            this.loginForm_gb.Size = new System.Drawing.Size(528, 405);
            this.loginForm_gb.TabIndex = 0;
            this.loginForm_gb.TabStop = false;
            // 
            // formLogin_password_tb
            // 
            this.formLogin_password_tb.ForeColor = System.Drawing.Color.Gray;
            this.formLogin_password_tb.Location = new System.Drawing.Point(101, 191);
            this.formLogin_password_tb.MaxLength = 32;
            this.formLogin_password_tb.Name = "formLogin_password_tb";
            this.formLogin_password_tb.PasswordChar = '*';
            this.formLogin_password_tb.Size = new System.Drawing.Size(315, 29);
            this.formLogin_password_tb.TabIndex = 4;
            // 
            // formLogin_username_tb
            // 
            this.formLogin_username_tb.ForeColor = System.Drawing.Color.Gray;
            this.formLogin_username_tb.Location = new System.Drawing.Point(101, 89);
            this.formLogin_username_tb.Name = "formLogin_username_tb";
            this.formLogin_username_tb.Size = new System.Drawing.Size(315, 29);
            this.formLogin_username_tb.TabIndex = 3;
            // 
            // loginForm_login_btn
            // 
            this.loginForm_login_btn.Location = new System.Drawing.Point(207, 298);
            this.loginForm_login_btn.Name = "loginForm_login_btn";
            this.loginForm_login_btn.Size = new System.Drawing.Size(101, 37);
            this.loginForm_login_btn.TabIndex = 2;
            this.loginForm_login_btn.Text = "Login";
            this.loginForm_login_btn.UseVisualStyleBackColor = true;
            this.loginForm_login_btn.Click += new System.EventHandler(this.loginForm_login_btn_Click);
            // 
            // loginForm_password_lbl
            // 
            this.loginForm_password_lbl.AutoSize = true;
            this.loginForm_password_lbl.Font = new System.Drawing.Font("Yu Gothic UI", 15F);
            this.loginForm_password_lbl.ForeColor = System.Drawing.Color.White;
            this.loginForm_password_lbl.Location = new System.Drawing.Point(202, 149);
            this.loginForm_password_lbl.Name = "loginForm_password_lbl";
            this.loginForm_password_lbl.Size = new System.Drawing.Size(94, 28);
            this.loginForm_password_lbl.TabIndex = 1;
            this.loginForm_password_lbl.Text = "Password";
            // 
            // loginForm_username_lbl
            // 
            this.loginForm_username_lbl.AutoSize = true;
            this.loginForm_username_lbl.Font = new System.Drawing.Font("Yu Gothic UI", 15F);
            this.loginForm_username_lbl.ForeColor = System.Drawing.Color.White;
            this.loginForm_username_lbl.Location = new System.Drawing.Point(202, 49);
            this.loginForm_username_lbl.Name = "loginForm_username_lbl";
            this.loginForm_username_lbl.Size = new System.Drawing.Size(99, 28);
            this.loginForm_username_lbl.TabIndex = 0;
            this.loginForm_username_lbl.Text = "Username";
            // 
            // logo_lbl
            // 
            this.logo_lbl.AutoSize = true;
            this.logo_lbl.Font = new System.Drawing.Font("Yu Gothic UI", 31.75F, System.Drawing.FontStyle.Bold);
            this.logo_lbl.ForeColor = System.Drawing.Color.White;
            this.logo_lbl.Location = new System.Drawing.Point(382, 23);
            this.logo_lbl.Name = "logo_lbl";
            this.logo_lbl.Size = new System.Drawing.Size(231, 59);
            this.logo_lbl.TabIndex = 0;
            this.logo_lbl.Text = "School Sys";
            // 
            // close_btn
            // 
            this.close_btn.ForeColor = System.Drawing.Color.Black;
            this.close_btn.Location = new System.Drawing.Point(991, 12);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(24, 30);
            this.close_btn.TabIndex = 2;
            this.close_btn.Text = "X";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // schoolsys_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(1027, 606);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.logo_lbl);
            this.Controls.Add(this.loginForm_gb);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "schoolsys_login";
            this.Text = "School - System";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_mouseDown);
            this.loginForm_gb.ResumeLayout(false);
            this.loginForm_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox loginForm_gb;
        private System.Windows.Forms.TextBox formLogin_password_tb;
        private System.Windows.Forms.TextBox formLogin_username_tb;
        private System.Windows.Forms.Button loginForm_login_btn;
        private System.Windows.Forms.Label loginForm_password_lbl;
        private System.Windows.Forms.Label loginForm_username_lbl;
        private System.Windows.Forms.Label logo_lbl;
        private System.Windows.Forms.Button close_btn;
    }
}