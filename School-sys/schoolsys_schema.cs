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
    public partial class schoolsys_schema : Form
    {
        public schoolsys_schema()
        {
            InitializeComponent();
            
        }

        public double[] mon;

        private void schoolsys_schema_Load(object sender, EventArgs e)
        {
            var dataFromDb = GetData();
            foreach (var itm in dataFromDb)
            {
                mon_pnl.Controls.Add(GetGroupBox(itm, 156, 100));
            }
        }

        private GroupBox GetGroupBox(Category c, int width, int height)
        {
            GroupBox g = new GroupBox();
            g.Size = new Size(width, height);
            g.ForeColor = Color.White;

            var y = 20;
            foreach (var itm in c.Items)
            {
                Label lb = new Label();
                lb.Text = itm;
                lb.ForeColor = Color.White;
                lb.Location = new Point(5, y);
                g.Controls.Add(lb);
                y += 20;
            }
            return g;
        }

        private void cb_SomeEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private List<Category> GetData()
        {
            DB db = new DB();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM elev_schema", db.getConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Category> result = new List<Category>();
            foreach (DataRow dr in dt.Rows)
            {
                if(dr["dag"].ToString() == "Måndag")
                {
                    Category c = new Category(dr["datum"].ToString(), new List<string>() { dr["tid"].ToString(), dr["lektion"].ToString() });
                    result.Add(c);
                }
                if (dr["dag"].ToString() == "Tisdag")
                {
                    Category c = new Category(dr["datum"].ToString(), new List<string>() { dr["tid"].ToString(), dr["lektion"].ToString() });
                    result.Add(c);
                }
                if (dr["dag"].ToString() == "Onsdag")
                {
                    Category c = new Category(dr["datum"].ToString(), new List<string>() { dr["tid"].ToString(), dr["lektion"].ToString() });
                    result.Add(c);
                }
                if (dr["dag"].ToString() == "Torsdag")
                {
                    Category c = new Category(dr["datum"].ToString(), new List<string>() { dr["tid"].ToString(), dr["lektion"].ToString() });
                    result.Add(c);
                }
                if (dr["dag"].ToString() == "Fredag")
                {
                    Category c = new Category(dr["datum"].ToString(), new List<string>() { dr["tid"].ToString(), dr["lektion"].ToString() });
                    result.Add(c);
                }
            }
            return result;
        }        
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
}
