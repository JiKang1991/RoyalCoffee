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
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();
        public string menuName = "";            // 버튼을 눌러 선택한 메뉴의 이름을 저장하는 변수입니다.
        public string menuPrice = "";           // 버튼을 눌러 선택한 메뉴의 가격을 저장하는 변수입니다.
        public string menuImage = "";
        public string menuTotalPrices = "";     // 각 메뉴의 총 가격을 저장하는 변수입니다, 각 메뉴별 가격은 띄어쓰기로 구분됩니다.
        public int totalPrice = 0;
        public string productCount = "";
        public string menuNames = "";            
        public string menuPrices = "";          
        public string menuImages = "";



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
                sqlConnection.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\jikang\OneDrive\문서\RoyalCoffee.mdf; Integrated Security = True; Connect Timeout = 30";
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        // 테이블명을 반환하는 메소드
        public void getTableName()
        {
            DataTable dataTable = sqlConnection.GetSchema("Tables");
        }  

       
        public void printProductList(int categoryNum)
        {


            int width = 30;
            int picHeight = 90;
            int nameHeight = 263;
            int priceHeight = 301;

            connectDB();

            
            // product 테이블에서 카테고리넘버1(커피류)에 해당하는 제품들의 정보를 조회하는 sql문
            string sql = $"SELECT productImage, productname, productprice FROM product WHERE categorynumber = {categoryNum}";
            sqlCommand.CommandText = sql;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            string productImage = "";
            string productNames = "";
            string productPrices = "";
            for(int i = 0; sqlDataReader.Read(); i++)
            {
                productImage += sqlDataReader.GetString(0) + " ";
                productNames += sqlDataReader.GetString(1) + " ";
                productPrices += $"{sqlDataReader.GetInt32(2)} ";
            }

            string[] arrProductImages = productImage.Trim().Split(' '); 
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

                arrImgControls[i].Name = arrProductNames[i] + " " + arrProductPrices[i]; ;
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
                arrPriceControls[i].Text = arrProductPrices[i]+"$";

                arrNameControls[i].Font = new Font("Nanum Pen", 18);
                arrPriceControls[i].Font = new Font("Nanum Pen", 18); 
                
                arrImgControls[i].BackgroundImage = Properties.Resources.crown;
                arrImgControls[i].BackgroundImageLayout = ImageLayout.Center;
                arrImgControls[i].Click += new EventHandler(menuClick);

                if(i == 3)
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
                tabPage1.Controls.Add(arrImgControls[i]);
                tabPage1.Controls.Add(arrNameControls[i]);
                tabPage1.Controls.Add(arrPriceControls[i]);
            }
            sqlConnection.Close();
        }

        private void menuClick(object sender, EventArgs e)
        {
            // 메소드를 호출한 버튼의 객체를 변수에 대입합니다.
            Button btn = sender as Button;
            string[] nameAndPrice = btn.Name.Split(' ');
            menuName = nameAndPrice[0];
            menuPrice = nameAndPrice[1];
            menuImage = btn.BackgroundImage + " ";

            menuNames += nameAndPrice[0] + " ";
            menuPrices += nameAndPrice[1] + " ";
            menuImages += btn.BackgroundImage + " ";

            FormCount formCount = new FormCount();
            DialogResult dialogResult = formCount.ShowDialog();

            if(dialogResult != DialogResult.OK)
            {
                return;
            }
            printSelectedMenu();
            

        }

        private void printSelectedMenu()
        {
            productCount += FormCount.formCount.productCount.ToString() + " ";
            int iMenuTotalPrice = int.Parse(menuPrice) * FormCount.formCount.productCount;
            menuTotalPrices += iMenuTotalPrice.ToString();
            totalPrice += iMenuTotalPrice;

            string[] arrSelectedMenuImages = menuImage.Trim().Split(' ');
            string[] arrSelectedMenuNames = menuName.Trim().Split(' ');
            string[] arrSelectedMenuPrice = menuPrice.Trim().Split(' ');
            string[] arrSelectedProductCount = productCount.Trim().Split(' ');

            Control[] selectedImage = new Control[arrSelectedMenuImages.Length]; 
            Control[] selectedName = new Control[arrSelectedMenuNames.Length];
            Control[] selectedCount = new Control[arrSelectedProductCount.Length];
            Control[] selectedPrice = new Control[arrSelectedMenuPrice.Length];
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

                selectedName[i].Text = FormCount.formCount.productName;
                selectedCount[i].Text = "x" + FormCount.formCount.productCount;
                selectedPrice[i].Text = iMenuTotalPrice.ToString() + "$";

                selectedName[i].Font = new Font("Nanum Pen", 18);
                selectedCount[i].Font = new Font("Nanum Pen", 18);
                selectedPrice[i].Font = new Font("Nanum Pen", 18);

                selectedName[i].Size = new Size(140, 50);

                flowLayoutPanel1.Controls.Add(selectedImage[i]);
                flowLayoutPanel1.Controls.Add(selectedName[i]);
                flowLayoutPanel1.Controls.Add(selectedCount[i]);
                flowLayoutPanel1.Controls.Add(selectedPrice[i]);
                flowLayoutPanel1.Controls.Add(cencelBtn[i]);

                Label lbTotalPrice = new Label();
                lbTotalPrice.Text = "Total Price : " + totalPrice + "$";
                lbTotalPrice.Parent = panelTotalPrice;
                lbTotalPrice.Font = new Font("Nanum Pen", 18);
                lbTotalPrice.AutoSize = true;
                panelTotalPrice.Controls.Clear();
                panelTotalPrice.Controls.Add(lbTotalPrice);
            }
            
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

        }
    }
}
