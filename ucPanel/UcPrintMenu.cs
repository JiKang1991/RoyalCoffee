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
        private ArrayList arrChoicedProductDTOs = new ArrayList();

        public UcPrintMenu(SqlConnection sqlConnection, SqlCommand sqlCommand, TabPage callTabPage)
        {
            InitializeComponent();
            
            this.callTabPage = callTabPage;
            this.sqlConnection = sqlConnection;
            this.sqlCommand = sqlCommand;
        }

        private ArrayList getProductListByCategoryNumToDB()
        {
            ArrayList arrProductDTOs = new ArrayList();
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
                arrProductDTOs.Add(productDTO);
            }
            return arrProductDTOs;
        }

        private void addBtnControl(ArrayList arrProductList)
        {
            Button[] arrButtons = new Button[arrProductList.Count];
            Size btnSize = new Size(140, 170);
            Point btnLocation = new Point(30, 90);
            for(int i = 0; i < arrProductList.Count; i++)
            {
                ProductDTO productDTO = (ProductDTO)arrProductList[i];
                arrButtons[i].Name = $"{productDTO.number} {productDTO.name} {productDTO.price}";
                arrButtons[i].Size = btnSize;
                arrButtons[i].Location = btnLocation;
                arrButtons[i].BackgroundImage = Properties.Resources.crown;
                arrButtons[i].BackgroundImageLayout = ImageLayout.Center;
                arrButtons[i].Click += new EventHandler(productImgClick);

                if ((i + 1) % 4 == 0)
                {
                    btnLocation.X = 30;
                    btnLocation.Y += 275;
                }
                else
                {
                    btnLocation.X += (160 * (i + 1));
                }
            }          
        }
        private void addNameControl(ArrayList arrProductList)
        {
            Label[] arrNames = new Label[arrProductList.Count];
            Size nameSize = new Size(140, 30);
            Point nameLocation = new Point(30, 263);
            for(int i = 0; i < arrProductList.Count; i++)
            {
                ProductDTO productDTO = (ProductDTO)arrProductList[i];
                arrNames[i].Text = $"{productDTO.name}";
                arrNames[i].Size = nameSize;
                arrNames[i].Location = nameLocation;
                arrNames[i].Font = new Font("Nanum Pen", 18);
               
                if ((i + 1) % 4 == 0)
                {
                    nameLocation.X = 30;
                    nameLocation.Y += 275;
                }
                else
                {
                    nameLocation.X += (160 * (i + 1));
                }
            }          
        }
        private void addControl(string usage, Control[] arrControls, ArrayList arrProductList, Control control, Size size, Point location)
        {
            //Control[] arrControls = new Control[arrProductList.Count];
            
            for(int i = 0; i < arrProductList.Count; i++)
            {
                arrControls[i] = control;
                ProductDTO productDTO = (ProductDTO)arrProductList[i];
                arrControls[i].Size = size;
                arrControls[i].Location = location;
                arrControls[i].Font = new Font("Nanum Pen", 18);
               
                if(usage.ToLower().Trim() == "button")
                {
                    arrControls[i].Name = $"{productDTO.number} {productDTO.name} {productDTO.price}";
                    arrControls[i].BackgroundImage = Properties.Resources.crown;
                    arrControls[i].BackgroundImageLayout = ImageLayout.Center;
                    arrControls[i].Click += new EventHandler(productImgClick);
                }
                else if(usage.ToLower().Trim() == "name")
                {
                    arrControls[i].Text = $"{productDTO.name}";                    
                }
                else if(usage.ToLower().Trim() == "price")
                {
                    arrControls[i].Text = $"{productDTO.price}￦";
                }
                                
                if ((i + 1) % 4 == 0)
                {
                    location.X = 30;
                    location.Y += 275;
                }
                else
                {
                    location.X += (160 * (i + 1));
                }

                this.Controls.Add(arrControls[i]);
            }          
        }

        private void ucPrintMenu_Load(object sender, EventArgs e)
        {           
            ArrayList arrProductDTOs = getProductListByCategoryNumToDB();

            Control[] arrControls = new Control[arrProductDTOs.Count];

            addControl("button", arrControls, arrProductDTOs, new Button(), new Size(140, 170), new Point(30, 90));
            addControl("name", arrControls, arrProductDTOs, new Label(), new Size(140, 30), new Point(30, 263));
            addControl("price", arrControls, arrProductDTOs, new Label(), new Size(140, 30), new Point(30, 301));
                        
            sqlConnection.Close();
            //btnOrder.Enabled = false;
        }

        private void productImgClick(object sender, EventArgs e)
        {
            ProductDTO productDTO = new ProductDTO();
            // 메소드를 호출한 버튼의 객체를 변수에 대입합니다.
            Button btn = sender as Button;
            string[] numberNamePrice = btn.Name.Split(' ');
            string menuName = numberNamePrice[1];
            string menuPrice = numberNamePrice[2];
            string menuImage = btn.BackgroundImage + " ";
            
            productDTO.number = int.Parse(numberNamePrice[0]);
            productDTO.name = numberNamePrice[1];
            productDTO.price = int.Parse(numberNamePrice[2]);
            productDTO.image = btn.BackgroundImage.ToString();
            arrChoicedProductDTOs.Add(productDTO);

            FormCount formCount = new FormCount();
            DialogResult dialogResult = formCount.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            productCounts += FormCount.formCount.productCount + " ";

            printSelectedMenu();


        }
    }
}
