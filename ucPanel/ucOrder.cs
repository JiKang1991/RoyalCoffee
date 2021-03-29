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

namespace RoyalCoffee.ucPanel
{
    public partial class ucOrder : UserControl
    {
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();
        public int width = 30;
        public int height = 90;

        public ucOrder()
        {
            InitializeComponent();

            this.Load += dynamicPB_Load;

        }

        public void dynamicPB_Load(object sender, EventArgs e)
        {
            dynamicPB();
        }

        public void dynamicPB()
        {
            
            try
            {
                //sqlConnection.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\jikang\OneDrive\문서\RoyalCoffee.mdf; Integrated Security = True; Connect Timeout = 30";
                //sqlConnection.Open();
                //sqlCommand.Connection = sqlConnection;

                //DataTable dataTable = sqlConnection.GetSchema("Tables");

                Control[] pbControlArr = new Control[8];
                FlowLayoutPanel flp = new FlowLayoutPanel();

                for (int i = 0; i < 8; i++)
                {
                    pbControlArr[i] = new PictureBox();
                    pbControlArr[i].Name = width.ToString();
                    pbControlArr[i].Parent = this;
                    pbControlArr[i].Location = new Point(width, height);
                    pbControlArr[i].Size = new Size(140, 170);
                    int x = i + 1;
                    pbControlArr[i].Text = "RoyalCoffee..." + x.ToString();
                    pbControlArr[i].BackColor = Color.AliceBlue;

                    width += 10;
                    height += 10;

                    flp.Controls.Add(pbControlArr[i]);
                }

                tabPage1.Controls.Add(flp);
                flp.Dock = DockStyle.Fill;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }
             

    }
}
