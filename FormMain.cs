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
    public partial class FormMain : Form
    {
        public static FormMain formMain;
        ucPanel.UcMain userControlMain = new ucPanel.UcMain();
        
        public FormMain()
        {
            InitializeComponent();
            formMain = this;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelMain.Visible = true;
            panelMain.Controls.Add(userControlMain);
        }
    }
}
