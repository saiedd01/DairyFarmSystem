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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PasswordTb.Text = "";
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\DFarm.mdf;Integrated Security=True;Connect Timeout=30");

        private void LoginBtn_Click(object sender, EventArgs e)
        {
           if(UnameTb.Text=="" || PasswordTb.Text == "")
           {
                MessageBox.Show("Enter UserName And Password");
           }
           else
           {
                if (RoleCb.SelectedIndex > -1)
                {
                    if(RoleCb.SelectedItem.ToString() == "Admin")
                    {
                       if(UnameTb.Text== "Admin" || PasswordTb.Text == "Admin")
                       {
                            Employees emp = new Employees();
                            emp.Show();
                            this.Hide();
                       }
                       else
                       {
                            MessageBox.Show("If You are Admin, Enter The Correct Id and Password");
                       }
                    }
                    else
                    {
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from EmployeeTbl where EmpName='"+UnameTb.Text+ "'and EmpPass='" + PasswordTb.Text + "'",con);

                    }
                }
           }
           
        }
    }
}
