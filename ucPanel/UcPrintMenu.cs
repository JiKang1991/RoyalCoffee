using System;
using System.Collections;
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
    public partial class UcPrintMenu : UserControl
    {
        //private UserControl callUserControl;
        private TabPage callTabPage;
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public UcPrintMenu(SqlConnection sqlConnection, SqlCommand sqlCommand, TabPage callTabPage)
        {
            InitializeComponent();
            //this.callUserControl = callUserControl;
            this.callTabPage = callTabPage;
            this.sqlConnection = sqlConnection;
            this.sqlCommand = sqlCommand;
        }

        private ArrayList getProductListByCategoryNumToDB()
        {
            ArrayList arrProductList = new ArrayList();
            ProductDTO productDTO = new ProductDTO();
            int categoryNum = int.Parse(callTabPage.Name.Substring(7, 1));
            // product 테이블에서 카테고리넘버에 해당하는 제품들의 정보를 조회하는 sql문
            string sql = $"SELECT productnumber, productimage, productname, productprice FROM product WHERE categorynumber = {categoryNum}";
            sqlCommand.CommandText = sql;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            for (int i = 0; sqlDataReader.Read(); i++)
            {
                productDTO.number = sqlDataReader.GetInt32(0);
                productDTO.image = sqlDataReader.GetString(1);
                productDTO.name = sqlDataReader.GetString(2);
                productDTO.price = sqlDataReader.GetInt32(3);
                arrProductList.Add(productDTO);
            }
            return arrProductList;
        }

        private void addBtnControl(ArrayList arrProductList)
        {
            Button[] arrButtons = new Button[arrProductList.Count];
            for(int i = 0; i < arrProductList.Count; i++)
            {
                ProductDTO productDTO = (ProductDTO)arrProductList[i];
                arrButtons[i].Name = $"{productDTO.number} {productDTO.name} {productDTO.price}
            }
            
           
        }

        private void ucPrintMenu_Load(object sender, EventArgs e)
        {
            int width = 30;
            int picHeight = 90;
            int nameHeight = 263;
            int priceHeight = 301;

            ArrayList arrProductList = getProductListByCategoryNumToDB();
                        
            //Control[] arrControls = new Control[arrProductList.Count];

            addBtnControl(arrProductList);
            //addControl(new Button());
            
            Control[] arrImgControls = new Control[arrProductList.Length];
            Control[] arrNameControls = new Control[arrProductList.Length];
            Control[] arrPriceControls = new Control[arrProductList.Length];

            for (int i = 0; i < arrProductNames.Length; i++)
            {
                arrImgControls[i] = new Button();
                arrNameControls[i] = new Label();
                arrPriceControls[i] = new Label();

                arrImgControls[i].Name = arrProductNumbers[i] + " " + arrProductNames[i] + " " + arrProductPrices[i];
                arrNameControls[i].Name = "name" + arrProductNames[i];
                arrPriceControls[i].Name = "price" + arrProductNames[i];

                arrImgControls[i].Parent = this;
                arrNameControls[i].Parent = this;
                arrPriceControls[i].Parent = this;

                arrImgControls[i].Location = new Point(width, picHeight);
                arrNameControls[i].Location = new Point(width, nameHeight);
                arrPriceControls[i].Location = new Point(width, priceHeight);

                arrImgControls[i].Size = new Size(140, 170);
                arrNameControls[i].Size = new Size(140, 30);
                arrPriceControls[i].Size = new Size(140, 30);

                arrNameControls[i].Text = arrProductNames[i];
                arrPriceControls[i].Text = arrProductPrices[i] + "￦";

                arrNameControls[i].Font = new Font("Nanum Pen", 18);
                arrPriceControls[i].Font = new Font("Nanum Pen", 18);

                arrImgControls[i].BackgroundImage = Properties.Resources.crown;
                arrImgControls[i].BackgroundImageLayout = ImageLayout.Center;
                arrImgControls[i].Click += new EventHandler(menuClick);

                int index = i + 1;
                if (index % 4 == 0)
                {
                    width = 30;
                    picHeight += 275;
                    nameHeight += 275;
                    priceHeight += 275;
                }
                else
                {
                    width += 160;
                }

                if (categoryNum == 1)
                {
                    tabPage1.Controls.Add(arrImgControls[i]);
                    tabPage1.Controls.Add(arrNameControls[i]);
                    tabPage1.Controls.Add(arrPriceControls[i]);
                }
                else if (categoryNum == 2)
                {
                    tabPage2.Controls.Add(arrImgControls[i]);
                    tabPage2.Controls.Add(arrNameControls[i]);
                    tabPage2.Controls.Add(arrPriceControls[i]);
                }
                else if (categoryNum == 3)
                {
                    tabPage3.Controls.Add(arrImgControls[i]);
                    tabPage3.Controls.Add(arrNameControls[i]);
                    tabPage3.Controls.Add(arrPriceControls[i]);
                }
            }
            sqlConnection.Close();
            btnOrder.Enabled = false;
        }
    }
}
