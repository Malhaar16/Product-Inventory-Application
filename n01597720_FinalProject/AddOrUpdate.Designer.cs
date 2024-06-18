namespace n01597720_FinalProject
{
    partial class AddOrUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tbProductIDs = new TextBox();
            tbProductNames = new TextBox();
            tbProductPrices = new TextBox();
            tbProductQuantitys = new TextBox();
            btnSumit = new Button();
            btnGetData = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 56);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 0;
            label1.Text = "Product ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 125);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 1;
            label2.Text = "Product Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 191);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 2;
            label3.Text = "Product Price";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 259);
            label4.Name = "label4";
            label4.Size = new Size(120, 20);
            label4.TabIndex = 3;
            label4.Text = "Product Quantity";
            // 
            // tbProductIDs
            // 
            tbProductIDs.Location = new Point(147, 53);
            tbProductIDs.Name = "tbProductIDs";
            tbProductIDs.Size = new Size(203, 27);
            tbProductIDs.TabIndex = 4;
            // 
            // tbProductNames
            // 
            tbProductNames.Location = new Point(147, 122);
            tbProductNames.Name = "tbProductNames";
            tbProductNames.Size = new Size(203, 27);
            tbProductNames.TabIndex = 5;
            // 
            // tbProductPrices
            // 
            tbProductPrices.Location = new Point(147, 184);
            tbProductPrices.Name = "tbProductPrices";
            tbProductPrices.Size = new Size(203, 27);
            tbProductPrices.TabIndex = 6;
            // 
            // tbProductQuantitys
            // 
            tbProductQuantitys.Location = new Point(147, 256);
            tbProductQuantitys.Name = "tbProductQuantitys";
            tbProductQuantitys.Size = new Size(203, 27);
            tbProductQuantitys.TabIndex = 7;
            // 
            // btnSumit
            // 
            btnSumit.Location = new Point(379, 122);
            btnSumit.Name = "btnSumit";
            btnSumit.Size = new Size(120, 27);
            btnSumit.TabIndex = 8;
            btnSumit.Text = "Submit";
            btnSumit.UseVisualStyleBackColor = true;
            btnSumit.Click += btnSumit_Click;
            // 
            // btnGetData
            // 
            btnGetData.Location = new Point(379, 53);
            btnGetData.Name = "btnGetData";
            btnGetData.Size = new Size(120, 27);
            btnGetData.TabIndex = 9;
            btnGetData.Text = "Get Data";
            btnGetData.UseVisualStyleBackColor = true;
            btnGetData.Click += btnGetData_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(379, 184);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(120, 29);
            btnExit.TabIndex = 10;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // AddOrUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 308);
            Controls.Add(btnExit);
            Controls.Add(btnGetData);
            Controls.Add(btnSumit);
            Controls.Add(tbProductQuantitys);
            Controls.Add(tbProductPrices);
            Controls.Add(tbProductNames);
            Controls.Add(tbProductIDs);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddOrUpdate";
            Text = "`";
            Load += AddOrUpdate_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbProductIDs;
        private TextBox tbProductNames;
        private TextBox tbProductPrices;
        private TextBox tbProductQuantitys;
        private Button btnSumit;
        private Button btnGetData;
        private Button btnExit;
    }
}