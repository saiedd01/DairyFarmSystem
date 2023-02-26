﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DairyFarmSystem
{
    public partial class Cows : Form
    {
        public Cows()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\DFarm.mdf;Integrated Security=True;Connect Timeout=30");
        private void Cows_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

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
        private void populate()
        {
            con.Open();
            string Query = "select * from CowTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CowDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        int age = 0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(CowNameTb.Text ==""|| EarTagTb.Text==""|| ColorTb.Text == "" || BreedTb.Text == "" || WeightTb.Text == "" || AgeTb.Text == "" || PastureTb.Text=="")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into CowTbl values('" + CowNameTb.Text + "','" + EarTagTb.Text + "','" + ColorTb.Text + "','" + BreedTb.Text + "'," + age + "," + WeightTb.Text + ", '" + PastureTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Saved");
                    con.Close();
                    populate();
                    Clear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DOBDate_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days)/365;
            
        }

        private void DOBDate_MarginChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
            AgeTb.Text = "" + age;
        }

        private void DOBDate_MouseLeave(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
            AgeTb.Text = "" + age;
        }
        private void Clear()
        {
            CowNameTb.Text = "";
            EarTagTb.Text = "";
            ColorTb.Text = "";
            AgeTb.Text = "";
            WeightTb.Text = "";
            PastureTb.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
