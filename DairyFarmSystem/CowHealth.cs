﻿using System;
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
    public partial class CowHealth : Form
    {
        public CowHealth()
        {
            InitializeComponent();
            FillCowId();
            populate();
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
       
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\DFarm.mdf;Integrated Security=True;Connect Timeout=30");

        private void FillCowId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select CowId from CowsTbl", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId", typeof(int));
            dt.Load(Rdr);
            CowIdCb.ValueMember = "CowId";
            CowIdCb.DataSource = dt;
            con.Close();
        }
        private void populate()
        {
            con.Open();
            string Query = "select * from HealthTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HealtDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void GetCowName()
        {
            con.Open();
            string query = "select * from CowsTbl Where CowId=" + CowIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CowNameTb.Text = dr["CowName"].ToString();
            }
            con.Close();
        }
        private void Clear()
        {
            CowNameTb.Text = "";
            EventTb.Text = "";
            DiagnosisTb.Text = "";
            VetNameTb.Text = "";
            CostTb.Text = "";
            TreatmentTb.Text = "";
            key = 0;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || EventTb.Text == "" || CostTb.Text == "" || VetNameTb.Text == "" || DiagnosisTb.Text == "" || TreatmentTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into HealthTbl values(" + CowIdCb.SelectedValue.ToString() + ",'" + CowNameTb.Text + "','" + Date.Value.Date + "','" + EventTb.Text + "','" + DiagnosisTb.Text + "','" + TreatmentTb.Text + "', '" + CostTb.Text + "', '" + VetNameTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Health Issue Saved");
                    con.Close();
                    populate();
                    Clear();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void CostTb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        int key = 0;
        private void HealtDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdCb.SelectedValue = HealtDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = HealtDGV.SelectedRows[0].Cells[2].Value.ToString();
            Date.Text = HealtDGV.SelectedRows[0].Cells[3].Value.ToString();
            EventTb.Text = HealtDGV.SelectedRows[0].Cells[4].Value.ToString();
            DiagnosisTb.Text = HealtDGV.SelectedRows[0].Cells[5].Value.ToString();
            TreatmentTb.Text = HealtDGV.SelectedRows[0].Cells[6].Value.ToString();
            CostTb.Text = HealtDGV.SelectedRows[0].Cells[7].Value.ToString();
            VetNameTb.Text = HealtDGV.SelectedRows[0].Cells[8].Value.ToString();
            if (CowNameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(HealtDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
