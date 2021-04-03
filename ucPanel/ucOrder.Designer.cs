
namespace RoyalCoffee.ucPanel
{
    partial class UcOrder
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnOrder = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTotalPrice = new System.Windows.Forms.Panel();
            this.tabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.tabPage1);
            this.tabPage.Controls.Add(this.tabPage2);
            this.tabPage.Controls.Add(this.tabPage3);
            this.tabPage.Font = new System.Drawing.Font("Nanum Pen", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabPage.ItemSize = new System.Drawing.Size(100, 50);
            this.tabPage.Location = new System.Drawing.Point(25, 25);
            this.tabPage.Multiline = true;
            this.tabPage.Name = "tabPage";
            this.tabPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabPage.SelectedIndex = 0;
            this.tabPage.Size = new System.Drawing.Size(718, 718);
            this.tabPage.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabPage.TabIndex = 2;
            this.tabPage.SelectedIndexChanged += new System.EventHandler(this.tabPage_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Font = new System.Drawing.Font("Nanum Pen", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabPage1.Location = new System.Drawing.Point(4, 54);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage1.Size = new System.Drawing.Size(710, 660);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Coffee";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Font = new System.Drawing.Font("Nanum Pen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabPage2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tabPage2.Location = new System.Drawing.Point(4, 54);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage2.Size = new System.Drawing.Size(710, 660);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Beverage";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Location = new System.Drawing.Point(4, 54);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage3.Size = new System.Drawing.Size(710, 660);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dessert";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.White;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Nanum Pen", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrder.Location = new System.Drawing.Point(609, 765);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(134, 229);
            this.btnOrder.TabIndex = 0;
            this.btnOrder.Text = "결제하기";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(25, 765);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(574, 171);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panelTotalPrice
            // 
            this.panelTotalPrice.BackColor = System.Drawing.Color.White;
            this.panelTotalPrice.Location = new System.Drawing.Point(25, 942);
            this.panelTotalPrice.Name = "panelTotalPrice";
            this.panelTotalPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelTotalPrice.Size = new System.Drawing.Size(574, 52);
            this.panelTotalPrice.TabIndex = 3;
            // 
            // UcOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.panelTotalPrice);
            this.Controls.Add(this.tabPage);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UcOrder";
            this.Size = new System.Drawing.Size(768, 1024);
            this.tabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelTotalPrice;
    }
}
