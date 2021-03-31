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
    public partial class FormFinish : Form
    {
        public FormFinish()
        {
            InitializeComponent();

            this.Load += insertOrderData;
        }

        public void insertOrderData(object sender, EventArgs e)
        {
            ucPanel.UcOrder.ucOrder.connectDB();

            string sql = $"INSERT INTO OrderDetail VALUES";
            sqlCommand.CommandText = sql;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        }
    }
}
