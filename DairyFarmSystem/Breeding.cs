using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
