using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyalCoffee
{
    public partial class FormFinish : Form
    {
        SqlConnection sqlConnection = ucPanel.UcOrder.ucOrder.sqlConnection;
        SqlCommand sqlCommand = ucPanel.UcOrder.ucOrder.sqlCommand;
        public FormFinish()
        {
            InitializeComponent();

            this.Load += insertOrderData;
        }

        public void insertOrderData(object sender, EventArgs e)
        {
            try
            {
                ucPanel.UcOrder.ucOrder.connectDB();

                string sql = "SELECT MAX(dailynumber) AS dailynumber FROM orderlist";
                sqlCommand.CommandText = sql;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                int dailyNumber = 0;
                for(int i = 0; sqlDataReader.Read(); i++)
                {
                    dailyNumber = sqlDataReader.GetInt16(0) + 1;                    
                }
                sqlDataReader.Close();                

                sql = $"INSERT INTO orderList([dailynumber], [ordertime]) VALUES ({dailyNumber}, GETDATE())";
                sqlCommand.CommandText = sql;
                sqlCommand.ExecuteNonQuery();

                sql = "SELECT MAX(orderid) AS orderid FROM orderlist";
                sqlCommand.CommandText = sql;
                sqlDataReader = sqlCommand.ExecuteReader();
                int orderId = 0;
                for(int i = 0; sqlDataReader.Read(); i++)
                {
                    orderId = sqlDataReader.GetInt32(0);
                }
                sqlDataReader.Close();

                string[] arrCheckProductNum = ucPanel.UcOrder.ucOrder.menuNumbers.Trim().Split(' ');
                string[] arrCheckProductTotalPrice = ucPanel.UcOrder.ucOrder.menuTotalPrices.Trim().Split(' ');
                string[] arrCheckProductCount = ucPanel.UcOrder.ucOrder.productCounts.Trim().Split(' ');

                for(int i = 0; i < arrCheckProductNum.Length; i++)
                {
                    sql = $"INSERT INTO orderdetail([orderid], [productnumber], [producttotalprice], [productcount], [ischecked], [isfinished])" +
                    $"VALUES ({orderId}, {arrCheckProductNum[i]}, {arrCheckProductTotalPrice[i]}, {arrCheckProductCount[i]}, 0, 0)";
                    sqlCommand.CommandText = sql;
                    sqlCommand.ExecuteNonQuery();
                }

                lbOrderNum.Text = dailyNumber.ToString();

               
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
