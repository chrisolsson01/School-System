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

namespace School_sys
{ 
    /*
     * -------------------------------
     * Author: Liam Lillieroth
     * -------------------------------
     * Class schoolsys_admin:
     * Handle everything that is happening in admin panel 
     * -------------------------------
     * Requests:
     * Get connection , open connection and close connection from DB Class.
     * Send string value to HashString Class to hash pwd string.
     * -------------------------------
     */
    public partial class schoolsys_admin : Form
    {

        public string[] selectedNews;
        public schoolsys_admin()
        {
            InitializeComponent();
            loadKlass();
            loadElev();

        }

        private void sendMessage()
        {
            //Send message as admin

            DB db = new DB();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `nyhet`(`nyhet_cont`, `nyhet_from`, `nyhet_to`) VALUES (@cont, @from, @to)", db.getConnection());
            cmd.Parameters.Add("@cont", MySqlDbType.VarChar).Value = news_msg_tb.Text;
            cmd.Parameters.Add("@from", MySqlDbType.VarChar).Value = Properties.Settings.Default.Username;
            if (news_elev_clb.SelectedItem == null)
            {
                cmd.Parameters.Add("@to", MySqlDbType.VarChar).Value = news_klass_clb.SelectedItem;
            }
            else
            {
                cmd.Parameters.Add("@to", MySqlDbType.VarChar).Value = news_elev_clb.SelectedItem;
            }
            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Meddelandet skickat");
            }
            else
            {
                MessageBox.Show("Error msg");
            }
            db.closeConnection();

            news_msg_tb.Clear();
            news_klass_clb.ClearSelected();
            news_elev_clb.ClearSelected();
        }

        private void loadElev()
        {
            DB db = new DB();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM elev", db.getConnection());
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                news_elev_clb.Items.Add(dr["Namn"].ToString());
            }
        }

        private void loadKlass()
        {
            DB db = new DB();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM klasser", db.getConnection());
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                news_klass_clb.Items.Add(dr["klass_namn"].ToString());
            }
        }

        private void loadDGV()
        {
            //Hämta alla elever från elever tabellen
            DataTable dt = new DataTable();
            DB db = new DB();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM elev", db.getConnection());
            db.openConnection();
            MySqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            if (dt.Rows.Count > 0)
            {
                dgv_elever.DataSource = dt;
            }
        }

        private void loadData()
        {
            DataTable dt = new DataTable();
            DB db = new DB();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM elev", db.getConnection());
            db.openConnection();
            MySqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            if (dt.Rows.Count > 0)
            {
                dgv_elever.DataSource = dt;
            }
        }

        private void addKurs_btn_Click(object sender, EventArgs e)
        {
            //DB db = new DB();
            //MySqlCommand cmd1 = new MySqlCommand("CREATE TABLE `kurs_" + addKurs_kursnamn_tb.Text.Trim() + "` (ID int NOT NULL, Kursnamn varchar(64) NOT NULL, Larare varchar(64) NOT NULL, Elev varchar(64) NOT NULL, PRIMARY KEY(ID))", db.getConnection());
            //MySqlCommand cmd = new MySqlCommand("INSERT INTO `elever`(`namn`, `klass`, `personnummer`) VALUES (@name, @klass, @personnummer)", db.getConnection());
            //cmd1.Parameters.Add("@kursnamn", MySqlDbType.VarChar).Value = addKurs_kursnamn_tb.Text;
            //cmd.Parameters.Add("@larare", MySqlDbType.VarChar).Value = addKurs_larare_tb.Text;
            //cmd.Parameters.Add("@elev", MySqlDbType.VarChar).Value = addKurs_elev_tb.Text;

            //db.openConnection();
            //if (cmd1.ExecuteNonQuery() == 0)
            //{
            //    MessageBox.Show("Kurs skapad");
            //}
            //else
            //{
            //    MessageBox.Show("Error pupils");    
            //}
            //db.closeConnection();
        }

        private void schoolsys_admin_Load(object sender, EventArgs e)
        {
            //loadDGV();
            loadData();
            //DataGridView set width
            DataGridViewColumn column = dgv_elever.Columns[2];
            column.Width = 250;
            DataGridViewColumn column1 = dgv_elever.Columns[3];
            column1.Width = 95;
            DataGridViewColumn column2 = dgv_elever.Columns[4];
            column2.Width = 150;
        }

        private void searchBox_tb_TextChanged(object sender, EventArgs e)
        {
            (dgv_elever.DataSource as DataTable).DefaultView.RowFilter = string.Format("namn LIKE '%{0}%'", searchBox_tb.Text);
            pictureBox1.Hide();
            if (searchBox_tb.Text == "")
            {
                pictureBox1.Show();
            }
        }

        private void addElev_btn_Click(object sender, EventArgs e)
        {
            string username;
            DB db = new DB();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `elev`(`Namn`, `Klass`, `Personnummer`) VALUES (@name, @klass, @personnummer)", db.getConnection());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = addElev_namn_tb.Text;
            cmd.Parameters.Add("@klass", MySqlDbType.VarChar).Value = addElev_klass_tb.Text;
            cmd.Parameters.Add("@personnummer", MySqlDbType.VarChar).Value = addElev_personnummer_tb.Text;


            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                loadDGV();
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO `users`(`Username`, `Email`, `Password`, `Personnummer`, `User_Role`) VALUES(@username, @email, @password, @personnummer, @role)", db.getConnection());
                if (addElev_namn_tb.Text.Contains(" "))
                {
                    addElev_namn_tb.Text.Replace(" ", ".");
                    username = addElev_namn_tb.Text;
                }
                else
                {
                    username = addElev_namn_tb.Text;
                }
                username = addElev_namn_tb.Text.Replace(" ", ".");
                cmd1.Parameters.Add("@personnummer", MySqlDbType.VarChar).Value = addElev_personnummer_tb.Text;
                cmd1.Parameters.Add("@email", MySqlDbType.VarChar).Value = addElev_email_tb.Text;
                cmd1.Parameters.Add("@role", MySqlDbType.VarChar).Value = "elev";
                cmd1.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                cmd1.Parameters.Add("@password", MySqlDbType.VarChar).Value = HashString.GetHashString(addElev_pwd_tb.Text);
                if (cmd1.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Användare skapades!");
                }
            }
            else
            {
                MessageBox.Show("Error pupils");
            }
            db.closeConnection();
        }

        private void dgv_elever_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var senderGrid = (DataGridView)sender;

            //if (e.RowIndex >= 0)
            //{
            //    if (e.ColumnIndex == dgv_delete.Index)
            //    {
            //        DialogResult dialogResult = MessageBox.Show("Är du säker på att du vill ta bort:\n" + dgv_elever.Rows[e.RowIndex].Cells["namn"].Value.ToString(), "Varning!", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            DB db = new DB();
            //            MySqlCommand cmd = new MySqlCommand("DELETE FROM `elev` WHERE `elever`.`ID` = @ID", db.getConnection());
            //            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = dgv_elever.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            //            db.openConnection();
            //            if (cmd.ExecuteNonQuery() == 1)
            //            {
            //                MessageBox.Show("Borttagen");
            //                loadDGV();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Error");
            //            }
            //            db.closeConnection();
            //        }
            //        else if (dialogResult == DialogResult.No)
            //        {

            //        }

            //    }
            //    else if (e.ColumnIndex == dgv_redigera.Index)
            //    {
            //        DB db = new DB();
            //        MySqlCommand cmd = new MySqlCommand("UPDATE `elev` SET `Namn` = @name, `Klass` = @klass, `Personnummer` = @personnummer WHERE `elever`.`ID` = @ID;", db.getConnection());
            //        cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = dgv_elever.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            //        cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = dgv_elever.Rows[e.RowIndex].Cells["namn"].Value.ToString();
            //        cmd.Parameters.Add("@klass", MySqlDbType.VarChar).Value = dgv_elever.Rows[e.RowIndex].Cells["klass"].Value.ToString();
            //        cmd.Parameters.Add("@personnummer", MySqlDbType.VarChar).Value = dgv_elever.Rows[e.RowIndex].Cells["personnummer"].Value.ToString();
            //        db.openConnection();
            //        if (cmd.ExecuteNonQuery() == 1)
            //        {
            //            MessageBox.Show("Redigerad");
            //            loadDGV();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Error");
            //        }
            //        db.closeConnection();
            //    }
            //}
        }

        private void news_skicka_msg_Click(object sender, EventArgs e)
        {
            sendMessage();
        }
    }
}
