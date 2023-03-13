using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DairyFarmSystem
{
    public partial class MilkSales : Form
    {
        public MilkSales()
        {
            InitializeComponent();
            FillEmpId();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
            CowHealth ns = new CowHealth();
            ns.Show();
            this.Hide();
        }
        private void label6_Click(object sender, EventArgs e)
        {}

        private void label15_Click(object sender, EventArgs e)
        {}

        private void label7_Click(object sender, EventArgs e)
        {}

        private void label17_Click(object sender, EventArgs e)
        {}

        private void label7_Click_1(object sender, EventArgs e)
        {
            Breeding ns = new Breeding();
            ns.Show();
            this.Hide();
        }

        private void label15_Click_1(object sender, EventArgs e)
        {
            CowHealth ns = new CowHealth();
            ns.Show();
            this.Hide();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            MilkProduction ns = new MilkProduction();
            ns.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Finance ns = new Finance();
            ns.Show();
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            DashBorad ns = new DashBorad();
            ns.Show();
            this.Hide();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\DFarm.mdf;Integrated Security=True;Connect Timeout=30");

        private void FillEmpId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select EmpId from EmployeeTbl", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId", typeof(int));
            dt.Load(Rdr);
            CowIdCb.ValueMember = "EmpId";
            CowIdCb.DataSource = dt;
            con.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {

        }
    }
}
