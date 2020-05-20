using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace School_sys
{
    public partial class schoolsys_start : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        //Navigation pages
        string[] pages = new string[] { 
            "Startsida",
            "Elever",
            "Schema",
            "Kurser",
            "Boklån"
        };
        //set active page
        string activePages;
        //Move Around Window

        public schoolsys_start()
        {
            InitializeComponent();
            string namn = Properties.Settings.Default.Username.Replace(".", " ");
            namn = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(namn);
            navbar_username_lbl.Text = namn;
            loadMessages();
        }

        //Load messages on startpage
        private void loadMessages()
        {
            ////Gör om användarnamnet till namn
            //string namn = Properties.Settings.Default.Username.Replace(".", " ");
            //namn = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(namn);
            ////Hämta meddelanden
            //DB db = new DB();
            //MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM nyhet WHERE nyhet_to='" + namn + "'", dbs.getConnection());
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    string[] meddelande = new string[dt.Rows.Count];
            //    string[] from = new string[dt.Rows.Count];
            //    string[] to = new string[dt.Rows.Count];
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        meddelande[i] = dt.Rows[i]["nyhet_cont"].ToString();
            //        from[i] = dt.Rows[i]["nyhet_from"].ToString();
            //        to[i] = dt.Rows[i]["nyhet_to"].ToString();
            //        start_msgnew_from_lbl.Text = dt.Rows[i]["nyhet_from"].ToString();
            //    }
            //}
            //else
            //{
            //    message_msg_lbl.Text = "Du har inga nya meddelanden";
            //}

            var dataFromDb = GetData();
            foreach (var itm in dataFromDb)
            {
                flowLayoutPanel1.Controls.Add(GetPanel(itm, 156, 100));
            }
        }

        private Panel GetPanel(Category c, int width, int height)
        {
            Panel p = new Panel();
            p.Size = new Size(width, height);
            p.ForeColor = Color.Gray;
            var y = 20;
            foreach(var itm in c.Items)
            {
                Label lb = new Label();
                lb.Text = itm;
                lb.ForeColor = Color.White;
                lb.Location = new Point(5, y);
                p.Controls.Add(lb);
                y += 20;
            }
            return p;
        }

        private List<Category> GetData()
        {
            DB db = new DB();
            string namn = Properties.Settings.Default.Username.Replace(".", " ");
            namn = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(namn);
            //MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM nyhet WHERE nyhet_to='" + namn + "'", db.getConnection());
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM nyhet", db.getConnection());

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Category> result = new List<Category>();
            foreach (DataRow dr in dt.Rows)
            {
                Category c = new Category(dr["nyhet_from"].ToString(), new List<string>() { dr["nyhet_cont"].ToString(), dr["nyhet_to"].ToString() });
                MessageBox.Show(dr["nyhet_cont"].ToString());
            }
            return result;
        }

        class Category
        {
            public string Name;
            public List<string> Items;

            public Category(string name, List<string> items)
            {
                this.Name = name;
                this.Items = items;
            }
        }


        private void navbar_elever_lbl_Click(object sender, EventArgs e)
        {
            navar_panl.Controls.Clear();
            activePages = pages[1];
            School_sys_elever elever_tab = new School_sys_elever()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
            };
            navar_panl.Controls.Add(elever_tab);
            elever_tab.Show();
        }

        private void navbar_startsida_lbl_Click(object sender, EventArgs e)
        {
            //activePages = pages[0];
            //navar_panl.Controls.Clear();
            //schoolsys_start start = new schoolsys_start()
            //{
            //    Dock = DockStyle.Fill,
            //    TopLevel = false,
            //    TopMost = true,
            //};
            //navar_panl.Controls.Add(start);
            //start.Show();
            Application.Restart();
            
        }

        private void navbar_schema_lbl_Click(object sender, EventArgs e)
        {
            activePages = pages[2];
            navar_panl.Controls.Clear();
            activePages = pages[1];
            schoolsys_schema schema = new schoolsys_schema()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
            };
            navar_panl.Controls.Add(schema);
            schema.Show();
        }

        private void navbar_kurser_lbl_Click(object sender, EventArgs e)
        {
            navar_panl.Controls.Clear();
            activePages = pages[3];
            schoolsys_kurser kurser_tab = new schoolsys_kurser()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
            };
            navar_panl.Controls.Add(kurser_tab);
            kurser_tab.Show();
        }

        private void navbar_bok_lbl_Click(object sender, EventArgs e)
        {
            activePages = pages[4];
        }

        private void messages_gb_Enter(object sender, EventArgs e)
        {

        }

        private void navbar_admin_lbl_Click(object sender, EventArgs e)
        {
            navar_panl.Controls.Clear();
            activePages = pages[1];
            schoolsys_admin admin = new schoolsys_admin()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
            };
            navar_panl.Controls.Add(admin);
            admin.Show();
        }

        private void navbar_loggaut_lbl_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Application.Restart();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolBar_mousedown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void r_btn_Click(object sender, EventArgs e)
        {
            loadMessages();
        }
    }
}
