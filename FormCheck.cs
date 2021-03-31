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

            this.Load += printCheckList_Load;
        }

        private void printCheckList_Load(object sender, EventArgs e)
        {
            printCheckList();
        }

        private void printCheckList()
        {
            string[] arrCheckImgs = ucPanel.UcOrder.ucOrder.menuImages.Trim().Split(' '); 
            string[] arrCheckNames = ucPanel.UcOrder.ucOrder.menuNames.Trim().Split(' ');
            string[] arrCheckCounts = ucPanel.UcOrder.ucOrder.productCount.Trim().Split(' ');

            Control[] arrImgControls = new Control[arrCheckImgs.Length];
            Control[] arrNameControls = new Control[arrCheckNames.Length];
            Control[] arrCountControls = new Control[arrCheckCounts.Length];

            for(int i = 0; i < arrCheckNames.Length; i++)
            {
                arrImgControls[i] = new PictureBox();
                arrNameControls[i] = new Label();
                arrCountControls[i] = new Label();

                arrImgControls[i].BackgroundImage = Properties.Resources.crown;
                arrImgControls[i].BackgroundImageLayout = ImageLayout.Zoom;

                arrNameControls[i].Text = arrCheckNames[i];
                arrCountControls[i].Text = "x" + arrCheckCounts[i];

                arrNameControls[i].Font = new Font("Nanum Pen", 18);
                arrCountControls[i].Font = new Font("Nanum Pen", 18);

                arrNameControls[i].Size = new Size(140, 50);

                flowLayoutPanel1.Controls.Add(arrImgControls[i]);
                flowLayoutPanel1.Controls.Add(arrNameControls[i]);
                flowLayoutPanel1.Controls.Add(arrCountControls[i]);

                Label lbTotalPrice = new Label();
                lbTotalPrice.Text = "Total Price : " + ucPanel.UcOrder.ucOrder.totalPrice + "$";
                lbTotalPrice.Parent = panelTotalPrice;
                lbTotalPrice.Font = new Font("Nanum Pen", 18);
                lbTotalPrice.AutoSize = true;
                panelTotalPrice.Controls.Add(lbTotalPrice);
            }
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
