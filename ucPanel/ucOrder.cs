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
    public partial class UcOrder : UserControl
    {
        public static UcOrder ucOrder;
        public SqlConnection sqlConnection = new SqlConnection();
        public SqlCommand sqlCommand = new SqlCommand();        
        public string menuName = "";            // 버튼을 눌러 선택한 메뉴의 이름을 저장하는 변수입니다.
        public string menuPrice = "";           // 버튼을 눌러 선택한 메뉴의 가격을 저장하는 변수입니다.
        public string menuImage = "";
        public string menuTotalPrices = "";     // 각 메뉴의 총 가격을 저장하는 변수입니다, 각 메뉴별 가격은 띄어쓰기로 구분됩니다.
        public int totalPrice = 0;
        public string menuNumbers = "";
        public string menuNames = "";            
        public string menuPrices = "";          
        public string menuImages = "";
        public string productCounts = "";



        public UcOrder()
        {
            InitializeComponent();

            this.Load += printProductList_Load;
            ucOrder = this;
        }
        // printProductList() 메소드를 호출하는 메소드
        public void printProductList_Load(object sender, EventArgs e)
        {            

            printProductList(1);
        }

        // RoyalCoffee.mdf 연결 메소드
        public void connectDB()
        {
            try
            {
                sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\kosta203\RoyalCoffee\RoyalCoffeeDB.mdf;Integrated Security=True;Connect Timeout=30";
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
                    
        public void printProductList(int categoryNum)
        {


            int width = 30;
            int picHeight = 90;
            int nameHeight = 263;
            int priceHeight = 301;

            connectDB();

            
            // product 테이블에서 카테고리넘버1(커피류)에 해당하는 제품들의 정보를 조회하는 sql문
            string sql = $"SELECT productnumber, productimage, productname, productprice FROM product WHERE categorynumber = {categoryNum}";
            sqlCommand.CommandText = sql;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            string productNumbers = "";
            string productImages = "";
            string productNames = "";
            string productPrices = "";
            for(int i = 0; sqlDataReader.Read(); i++)
            {
                productNumbers += sqlDataReader.GetInt32(0) + " ";
                productImages += sqlDataReader.GetString(1) + " ";
                productNames += sqlDataReader.GetString(2) + " ";
                productPrices += $"{sqlDataReader.GetInt32(3)} ";
            }

            string[] arrProductNumbers = productNumbers.Trim().Split(' ');
            string[] arrProductImages = productImages.Trim().Split(' '); 
            string[] arrProductNames = productNames.Trim().Split(' ');
            string[] arrProductPrices = productPrices.Trim().Split(' ');                        

            Control[] arrImgControls = new Control[arrProductImages.Length];
            Control[] arrNameControls = new Control[arrProductNames.Length];
            Control[] arrPriceControls = new Control[arrProductPrices.Length];

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

                arrNameControls[i].Text =  arrProductNames[i];
                arrPriceControls[i].Text = arrProductPrices[i]+ "￦";

                arrNameControls[i].Font = new Font("Nanum Pen", 18);
                arrPriceControls[i].Font = new Font("Nanum Pen", 18); 
                
                arrImgControls[i].BackgroundImage = Properties.Resources.crown;
                arrImgControls[i].BackgroundImageLayout = ImageLayout.Center;
                arrImgControls[i].Click += new EventHandler(menuClick);

                int index = i + 1;
                if(index % 4 == 0)
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
                else if(categoryNum == 2)
                {
                    tabPage2.Controls.Add(arrImgControls[i]);
                    tabPage2.Controls.Add(arrNameControls[i]);
                    tabPage2.Controls.Add(arrPriceControls[i]);
                }
                else if(categoryNum == 3)
                {
                    tabPage3.Controls.Add(arrImgControls[i]);
                    tabPage3.Controls.Add(arrNameControls[i]);
                    tabPage3.Controls.Add(arrPriceControls[i]);
                }
            }
            sqlConnection.Close();
            btnOrder.Enabled = false;
        }

        private void menuClick(object sender, EventArgs e)
        {
            // 메소드를 호출한 버튼의 객체를 변수에 대입합니다.
            Button btn = sender as Button;
            string[] numberNamePrice = btn.Name.Split(' ');
            menuName = numberNamePrice[1];
            menuPrice = numberNamePrice[2];
            menuImage = btn.BackgroundImage + " ";

            menuNumbers += numberNamePrice[0] + " ";
            menuNames += numberNamePrice[1] + " ";
            menuPrices += numberNamePrice[2] + " ";
            menuImages += btn.BackgroundImage + " ";

            FormCount formCount = new FormCount();
            DialogResult dialogResult = formCount.ShowDialog();

            if(dialogResult != DialogResult.OK)
            {
                return;
            }
            productCounts += FormCount.formCount.productCount + " ";
            
            printSelectedMenu();
            

        }

        private void printSelectedMenu(bool flag = true)
        {
            flowLayoutPanel1.Controls.Clear();
            if (flag == true)
            {
                int iMenuTotalPrice = int.Parse(menuPrice) * FormCount.formCount.productCount;
                menuTotalPrices += iMenuTotalPrice.ToString() + " ";
                totalPrice += iMenuTotalPrice;
            }
            if (menuImages.Equals(""))
            {
                panelTotalPrice.Controls.Clear();
                btnOrder.Enabled = false;
                return;
            }
            string[] arrSelectedMenuImages = menuImages.Trim().Split(' ');
            string[] arrSelectedMenuNames = menuNames.Trim().Split(' ');
            string[] arrSelectedMenuPrices = menuTotalPrices.Trim().Split(' ');
            string[] arrSelectedProductCounts = productCounts.Trim().Split(' ');

            Control[] selectedImage = new Control[arrSelectedMenuImages.Length]; 
            Control[] selectedName = new Control[arrSelectedMenuNames.Length];
            Control[] selectedCount = new Control[arrSelectedProductCounts.Length];
            Control[] selectedPrice = new Control[arrSelectedMenuPrices.Length];
            Control[] cencelBtn = new Control[arrSelectedMenuNames.Length];

            for (int i = 0; i < selectedName.Length; i++)
            {
                selectedImage[i] = new PictureBox();
                selectedName[i] = new Label();
                selectedCount[i] = new Label();
                selectedPrice[i] = new Label();
                cencelBtn[i] = new Button();

                selectedImage[i].BackgroundImage = Properties.Resources.crown;
                selectedImage[i].BackgroundImageLayout = ImageLayout.Zoom;

                selectedName[i].Text = arrSelectedMenuNames[i];
                selectedCount[i].Text = "x" + arrSelectedProductCounts[i];
                selectedPrice[i].Text = arrSelectedMenuPrices[i] + "￦";

                selectedName[i].Font = new Font("Nanum Pen", 18);
                selectedCount[i].Font = new Font("Nanum Pen", 18);
                selectedPrice[i].Font = new Font("Nanum Pen", 18);

                selectedName[i].Size = new Size(140, 50);

                cencelBtn[i].Name = i + " " + arrSelectedMenuPrices[i];
                cencelBtn[i].BackgroundImage = Properties.Resources.cancel;
                cencelBtn[i].BackgroundImageLayout = ImageLayout.Zoom;
                cencelBtn[i].Size = new Size(20, 20);
                cencelBtn[i].Click += new EventHandler(selectCancel);

                flowLayoutPanel1.Controls.Add(selectedImage[i]);
                flowLayoutPanel1.Controls.Add(selectedName[i]);
                flowLayoutPanel1.Controls.Add(selectedCount[i]);
                flowLayoutPanel1.Controls.Add(selectedPrice[i]);
                flowLayoutPanel1.Controls.Add(cencelBtn[i]);

                Label lbTotalPrice = new Label();
                lbTotalPrice.Text = "Total Price : " + totalPrice + "￦";
                lbTotalPrice.Parent = panelTotalPrice;
                lbTotalPrice.Font = new Font("Nanum Pen", 18);
                lbTotalPrice.AutoSize = true;
                panelTotalPrice.Controls.Clear();
                panelTotalPrice.Controls.Add(lbTotalPrice);
            }
            btnOrder.Enabled = true;
        }

        private void selectCancel(object sender, EventArgs e)
        {
            // 메소드를 호출한 버튼의 객체를 변수에 대입합니다.
            Button btn = sender as Button;
            string[] indexPrice = btn.Name.Split(' ');
            int index = int.Parse(indexPrice[0]);
            int price = int.Parse(indexPrice[1]);
            
            string[] arrSelectedMenuImages = menuImages.Trim().Split(' ');
            string[] arrSelectedMenuNames = menuNames.Trim().Split(' ');
            string[] arrSelectedMenuPrices = menuTotalPrices.Trim().Split(' ');
            string[] arrSelectedProductCounts = productCounts.Trim().Split(' ');

            menuImages = removeStr(arrSelectedMenuImages, index, menuImages);
            menuNames = removeStr(arrSelectedMenuNames, index, menuNames);
            menuTotalPrices = removeStr(arrSelectedMenuPrices, index, menuTotalPrices);
            productCounts = removeStr(arrSelectedProductCounts, index, productCounts);
            totalPrice -= price;
            printSelectedMenu(false);

        }

        private string removeStr(string[] source, int index, string target)
        {
            target = "";
            for(int i = 0; i < source.Length; i++)
            {
                if(i != index)
                {
                    
                    target += source[i] + " ";
                }
            }
            return target;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            FormCheck formCheck = new FormCheck();
            DialogResult dialogResult = formCheck.ShowDialog();
            if(dialogResult != DialogResult.OK)
            {
                return;
            }

            FormFinish formFinish = new FormFinish();
            dialogResult = formFinish.ShowDialog();

            if(dialogResult != DialogResult.OK)
            {
                return;
            }

            FormMain.formMain.panelMain.Controls.Remove(ucOrder);
            ucPanel.UcMain.ucMain.Show();
           

        }
        
        private void tabPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            printProductList(int.Parse(tabPage.SelectedTab.Name.Substring(7, 1)));
        }
    }
}
