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
    public partial class FormCheck : Form
    {
        public FormCheck()
        {
            InitializeComponent();
        }

        private void FormCheck_Load(object sender, EventArgs e)
        {
            this.Load += printCheckList_Load;
        }

        private void printCheckList_Load(object sender, EventArgs e)
        {
            printCheckList();
        }

        private void printCheckList()
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
