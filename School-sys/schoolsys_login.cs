using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;


namespace School_sys
{
    public partial class schoolsys_login : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private void login_mouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public schoolsys_login()
        {
            InitializeComponent();
        }
        
        private void loginForm_login_btn_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string pwd = GetHashString(formLogin_password_tb.Text);
            string name = formLogin_username_tb.Text.ToLower();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users` WHERE `users`.`Username` = @username AND `users`.`Password` = @password", db.getConnection());
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = pwd;
            db.openConnection();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()){
                Properties.Settings.Default.Username = formLogin_username_tb.Text;
                Properties.Settings.Default.User_Role = dr["User_Role"].ToString();
                Properties.Settings.Default.Save();

                Application.Restart();
            }
            else {
                MessageBox.Show("Fel användarnamn eller lösenord!");
            }
            dr.Close();
            db.closeConnection();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
