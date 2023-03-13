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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            populate();
        }

        int key = 0;
        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
            DOB.Text = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenCb.SelectedValue = EmpDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = EmpDGV.SelectedRows[0].Cells[4].Value.ToString();
            AddressTb.Text = EmpDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (NameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(EmpDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\DFarm.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            con.Open();
            string Query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Clear()
        {
            NameTb.Text = "";
            PhoneTb.Text = "";
            AddressTb.Text = "";
            GenCb.SelectedIndex = -1;
            key = 0;   
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || GenCb.SelectedIndex == -1 || PhoneTb.Text == "" || AddressTb.Text=="")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into EmployeeTbl values('" + NameTb.Text + "','" + DOB.Value.Date + "','" + GenCb.SelectedItem.ToString() + "','" + PhoneTb.Text + "','" + AddressTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Saved");
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

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Employee To Be Deleted");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "delete from EmployeeTbl where EmpId= " + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted");
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
