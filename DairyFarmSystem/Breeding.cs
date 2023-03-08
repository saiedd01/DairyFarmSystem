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
    public partial class Breeding : Form
    {
        public Breeding()
        {
            InitializeComponent();
            FillCowId();
            populate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {}

        private void panel3_Paint(object sender, PaintEventArgs e)
        {}

        private void panel5_Paint(object sender, PaintEventArgs e)
        {}

        private void panel7_Paint(object sender, PaintEventArgs e)
        {}

        private void panel6_Paint(object sender, PaintEventArgs e)
        {}

        private void panel8_Paint(object sender, PaintEventArgs e)
        {}

        private void label5_Click(object sender, EventArgs e)
        {
            CowHealth ns = new CowHealth();
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

        private void label17_Click(object sender, EventArgs e)
        {
            MilkSales ns = new MilkSales();
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
            string Query = "select * from BreedTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BreedingDGV.DataSource = ds.Tables[0];
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
                CowAgeTb.Text = dr["Age"].ToString();
            }
            con.Close();
        }
        private void Clear()
        {
            CowNameTb.Text = "";
            CowAgeTb.Text = "";
            RemarksTb.Text = "";
            key = 0;
            
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || RemarksTb.Text == "" || CowAgeTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into BreedTbl values('"+ HeatDate.Value.Date + "' ,'" + BreedDate.Value.Date + "' ," + CowIdCb.SelectedValue.ToString() + ",'" + CowNameTb.Text + "','" + PregDate.Value.Date + "','" + ExpDate.Value.Date + "' ,'" + DateCalved.Value.Date + "'," + CowAgeTb.Text + ", '" + RemarksTb .Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breeding Report Saved");
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

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
        int key = 0;
        private void BreedingDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HeatDate.Text = BreedingDGV.SelectedRows[0].Cells[1].Value.ToString();
            BreedDate.Text = BreedingDGV.SelectedRows[0].Cells[2].Value.ToString();
            CowIdCb.SelectedValue = BreedingDGV.SelectedRows[0].Cells[3].Value.ToString();
            CowNameTb.Text = BreedingDGV.SelectedRows[0].Cells[4].Value.ToString();
            PregDate.Text = BreedingDGV.SelectedRows[0].Cells[5].Value.ToString();
            ExpDate.Text = BreedingDGV.SelectedRows[0].Cells[6].Value.ToString();
            DateCalved.Text = BreedingDGV.SelectedRows[0].Cells[7].Value.ToString();
            CowAgeTb.Text = BreedingDGV.SelectedRows[0].Cells[8].Value.ToString();
            RemarksTb.Text = BreedingDGV.SelectedRows[0].Cells[9].Value.ToString();
            if (CowNameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(BreedingDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Breed Report To Be Deleted");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "delete from BreedTbl where BrId= " + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breed Deleted");
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
    }
}
