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
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
            Exppopulate();
            Incpopulate();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            FilterIncome();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {}

        private void panel3_Paint(object sender, PaintEventArgs e)
        {}

        private void panel5_Paint(object sender, PaintEventArgs e)
        {}

        private void panel4_Paint(object sender, PaintEventArgs e)
        {}

        private void panel7_Paint(object sender, PaintEventArgs e)
        {}

        private void label19_Click(object sender, EventArgs e)
        {
            DashBorad ns = new DashBorad();
            ns.Show();
            this.Hide();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Cows ns = new Cows();
            ns.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MilkProduction ns = new MilkProduction();
            ns.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            CowHealth ns = new CowHealth();
            ns.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Breeding ns = new Breeding();
            ns.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            MilkSales ns = new MilkSales();
            ns.Show();
            this.Hide();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\DFarm.mdf;Integrated Security=True;Connect Timeout=30");

        private void Exppopulate()
        {
            con.Open();
            string Query = "select * from ExpenditureTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Incpopulate()
        {
            con.Open();
            string Query = "select * from IncomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds); 
            IncDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void FilterIncome()
        {
            con.Open();
            string Query = "select * from IncomeTbl where IncDate='"+IncomeDateFilter.Value.Date+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void FilterExp()
        {
            con.Open();
            string Query = "select * from ExpenditureTbl where ExpDate='" + ExpDateFilter.Value.Date + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void clearExp()
        {
            PurpCb.SelectedIndex = -1;
            AmountTb.Text = "";
        }
        private void clearInc()
        {
            IncPurpCb.SelectedIndex = -1;
            AmountTb.Text = "";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (PurpCb.SelectedIndex == -1 || AmountTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into ExpenditureTbl values('" + ExpDate.Value.Date + "','" + PurpCb.SelectedItem.ToString() + "'," + AmountTb.Text + "," + EmpIdLbl.Text + ")";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expenditure Saved");
                    con.Close();
                    Exppopulate();
                    clearExp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ExpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IncPurpCb.SelectedIndex == -1 || IncAmountTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into IncomeTbl values('" + IncDate.Value.Date + "','" + IncPurpCb.SelectedItem.ToString() + "'," + IncAmountTb.Text + "," + EmpIdLbl.Text + ")";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income Saved");
                    con.Close();
                    Incpopulate();
                    clearInc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Incpopulate();
        }
    }
}
