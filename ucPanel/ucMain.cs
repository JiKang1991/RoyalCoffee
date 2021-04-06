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
        private Panel callPanel;
        public static UcMain ucMain;
        public UcMain(Panel callPanel)
        {
            InitializeComponent();

            ucMain = this;

            this.callPanel = callPanel;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            UcOrder userControlOrder = new UcOrder(callPanel);
            callPanel.Controls.Add(userControlOrder);
            this.Hide();
        }
    }
}
