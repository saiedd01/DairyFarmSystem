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
    public partial class DashBorad : Form
    {
        public DashBorad()
        {
            InitializeComponent();
            Finance();
            Logistic();
            GetMax();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {}

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Finance ns = new Finance();
            ns.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            MilkSales ns = new MilkSales();
            ns.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Breeding ns = new Breeding();
            ns.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
             CowHealth ns = new CowHealth ();
            ns.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MilkProduction ns = new MilkProduction();
            ns.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Cows ns = new Cows();
            ns.Show();
            this.Hide();
        }

        private void DashBorad_Load(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\DFarm.mdf;Integrated Security=True;Connect Timeout=30");

        private void Finance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(IncAmt) from IncomeTbl",con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(ExpAmount) from ExpenditureTbl", con);
            int inc, exp;
            double bal;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            inc = Convert.ToInt32(dt.Rows[0][0].ToString());
            IncLbl.Text = "Rs"+dt.Rows[0][0].ToString();
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            exp = Convert.ToInt32(dt1.Rows[0][0].ToString());
            ExpLbl.Text = "Rs"+dt1.Rows[0][0].ToString();
            bal = inc - exp;
            BalLbl.Text = "Rs" + bal;
            con.Close();
        }

        private void Logistic()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from CowsTbl", con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select Sum(TotalMilk) from MilkTbl", con);
            SqlDataAdapter sda2 = new SqlDataAdapter("select Count(*) from EmployeeTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CownumLbl.Text= dt.Rows[0][0].ToString();
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            MilkLbl.Text = dt1.Rows[0][0].ToString()+" "+ "Liters";
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            EmpnumLbl.Text = dt2.Rows[0][0].ToString();
            con.Close();
        }
        private void GetMax()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(IncAmt) from IncomeTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            HighAmtLbl.Text = "Rs" + dt.Rows[0][0].ToString();
        }
    }
}
