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
        ucPanel.ucMain userControlMain = new ucPanel.ucMain();
        public FormMain()
        {
            InitializeComponent();
            formMain = this;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            panelMain.Controls.Add(userControlMain);
        }
    }
}
