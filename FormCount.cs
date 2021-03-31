using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyalCoffee
{
    public partial class FormCount : Form
    {
        public static FormCount formCount;
        public int productCount;
        public string productName;

        public FormCount()
        {
            InitializeComponent();
            formCount = this;
        }

        private void FormCount_Load(object sender, EventArgs e)
        {
            lbMenuName.Text = ucPanel.UcOrder.ucOrder.menuName;
            productName = ucPanel.UcOrder.ucOrder.menuName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productCount = (int)numericUpDown1.Value;
        }
    }
}
