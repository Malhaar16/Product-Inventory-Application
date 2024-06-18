namespace n01597720_FinalProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnAddProduct = new Button();
            btnDeleteProduct = new Button();
            btnUpdateProduct = new Button();
            btnDisplay = new Button();
            btnExit = new Button();
            btnGetProduct = new Button();
            tbProductID = new TextBox();
            dataGridView1 = new DataGridView();
            btnGetProductByName = new Button();
            label5 = new Label();
            tbTotalProduct = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 47);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 0;
            label1.Text = "Product ID";
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(12, 162);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(112, 29);
            btnAddProduct.TabIndex = 4;
            btnAddProduct.Text = "&Add Product";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Location = new Point(260, 162);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(129, 29);
            btnDeleteProduct.TabIndex = 5;
            btnDeleteProduct.Text = "&Delete Product";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // btnUpdateProduct
            // 
            btnUpdateProduct.Location = new Point(130, 162);
            btnUpdateProduct.Name = "btnUpdateProduct";
            btnUpdateProduct.Size = new Size(124, 29);
            btnUpdateProduct.TabIndex = 6;
            btnUpdateProduct.Text = "&Update Product";
            btnUpdateProduct.UseVisualStyleBackColor = true;
            btnUpdateProduct.Click += btnUpdateProduct_Click;
            // 
            // btnDisplay
            // 
            btnDisplay.Location = new Point(191, 211);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(198, 29);
            btnDisplay.TabIndex = 7;
            btnDisplay.Text = "&Display All Products";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(249, 260);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(112, 29);
            btnExit.TabIndex = 8;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnGetProduct
            // 
            btnGetProduct.Location = new Point(12, 211);
            btnGetProduct.Name = "btnGetProduct";
            btnGetProduct.Size = new Size(173, 29);
            btnGetProduct.TabIndex = 9;
            btnGetProduct.Text = "&Get Product By ID";
            btnGetProduct.UseVisualStyleBackColor = true;
            btnGetProduct.Click += btnGetProduct_Click;
            // 
            // tbProductID
            // 
            tbProductID.Location = new Point(168, 44);
            tbProductID.Name = "tbProductID";
            tbProductID.Size = new Size(184, 27);
            tbProductID.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(401, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(553, 297);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // btnGetProductByName
            // 
            btnGetProductByName.Location = new Point(12, 260);
            btnGetProductByName.Name = "btnGetProductByName";
            btnGetProductByName.Size = new Size(222, 29);
            btnGetProductByName.TabIndex = 15;
            btnGetProductByName.Text = "&Display All Product By Name";
            btnGetProductByName.UseVisualStyleBackColor = true;
            btnGetProductByName.Click += btnGetProductByName_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 100);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 16;
            label5.Text = "Total Product";
            // 
            // tbTotalProduct
            // 
            tbTotalProduct.Location = new Point(168, 97);
            tbTotalProduct.Name = "tbTotalProduct";
            tbTotalProduct.Size = new Size(184, 27);
            tbTotalProduct.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(972, 336);
            Controls.Add(tbTotalProduct);
            Controls.Add(label5);
            Controls.Add(btnGetProductByName);
            Controls.Add(dataGridView1);
            Controls.Add(tbProductID);
            Controls.Add(btnGetProduct);
            Controls.Add(btnExit);
            Controls.Add(btnDisplay);
            Controls.Add(btnUpdateProduct);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnAddProduct);
            Controls.Add(label1);
            Name = "Form1";
            Text = " Product Inventory Application";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAddProduct;
        private Button btnDeleteProduct;
        private Button btnUpdateProduct;
        private Button btnDisplay;
        private Button btnExit;
        private Button btnGetProduct;
        private TextBox tbProductID;
        private DataGridView dataGridView1;
        private Button btnGetProductByName;
        private Label label5;
        private TextBox tbTotalProduct;
    }
}