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
    public partial class UcMain : UserControl
    {
        public static UcMain ucMain;
        UcOrder userControlOrder;
        public UcMain()
        {
            InitializeComponent();

            ucMain = this;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            userControlOrder = new UcOrder();
            FormMain.formMain.panelMain.Controls.Add(userControlOrder);
            this.Hide();
        }
    }
}
