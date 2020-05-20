using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace School_sys
{
    public partial class schoolsys_kurser : Form
    {
        public schoolsys_kurser()
        {
            InitializeComponent();
        }

        

        private void schoolsys_load(object sender, EventArgs e)
        {
            var dataFromDb = GetData();
            foreach(var itm in dataFromDb)
            {

            }
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
                Category c = new Category(dr["elev_lektion"].ToString(), new List<string>() { dr["elev_lektion_sal"].ToString(), dr["elev_lektion_datum"].ToString() });
                result.Add(c);
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
    }
}
