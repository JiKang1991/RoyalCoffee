using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyalCoffee.ucPanel
{
    public partial class ucMain : UserControl
    {
        ucOrder userControlOrder = new ucOrder();
        public ucMain()
        {
            InitializeComponent();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            FormMain.formMain.panelMain.Controls.Add(userControlOrder);
            this.Hide();
        }
    }
}
