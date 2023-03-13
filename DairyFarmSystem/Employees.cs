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

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    string Query = "insert into EmployeeTbl values('" + NameTb.Text + "','" + DOB.Value.Date + "','" + GenCb.SelectedValue.ToString() + "','" + PhoneTb.Text + "','" + AddressTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Saved");
                    con.Close();
                    populate();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
