using n01597720_FinalProject.Models.DataLayer;
using n01597720_FinalProject.Models.DataLayer.Database_Access;
using System.Data;

namespace n01597720_FinalProject
{
    public partial class Form1 : Form
    {

        //Creating instance of Product Database and Product class
        ProductDatabase database = new ProductDatabase();
        Product product1 = new Product();

        public Form1()
        {
            InitializeComponent();
        }

//Add Button Event Handler
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            //Creating Instance of AddOrUpdate from
            var add = new AddOrUpdate();

            //Gets the reuslt of AddOrUpdate form operation here 
            DialogResult dialogResult = add.ShowDialog();

            //if the result value is OK then if block will executes
            if (dialogResult == DialogResult.OK)
            {
                //clearing Total product textbox
                tbTotalProduct.Text = string.Empty;

                //Getting product details from Product instance located in AddOrUpdate form
                product1 = add.ProductDetail;

                try
                {
                    //Calling AddProductDetails() method located in database class and passing product1 as an argument
                    database.AddProductDetails(product1);

                    //As soon as product is added to database GetAllProduct() method will show all product from the databse into data gridview
                    dataGridView1.DataSource = database.GetAllProduct();

                    //This method call gives us total number of product available in the database
                    DisplayTotalProductsCount();


                }
                catch (Exception ex) //Handling Exception occurs in database
                {

                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

//Display All Product Button
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            //clearing Total product textbox
            tbTotalProduct.Text = string.Empty;
            try
            {
                //Calling GetAllProduct() method located in database class, which will show all product from the databse into data gridview
                dataGridView1.DataSource = database.GetAllProduct();

                //This method call gives us total number of product available in the database
                DisplayTotalProductsCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

//Delete Button 
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            tbTotalProduct.Text = string.Empty;

            //Basic validation to check if Poduct id is added or not
            if (tbProductID.Text.Length > 0)
            {
                product1.ProductID = int.Parse(tbProductID.Text);

                //Calling fetchProductName() method located in database class, which will fetch the product name with that product id provided
                string name = database.fetchProductName(product1);

                //asking confirmation from the user by using product  name fetch from the database
                DialogResult result = MessageBox.Show($"Are you sure, you want to delete {name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if user presses yes if block will executes
                if (result == DialogResult.Yes)
                {
                    //Calling RemoveProduct() method located in database class, which will delete the product with that product id provided
                    database.RemoveProduct(product1);

                    tbProductID.BackColor = Color.Black;

                    dataGridView1.DataSource = database.GetAllProduct();
                    DisplayTotalProductsCount();

                }
            }
            else
            {
                //if product id is empty it will turns textbox to red
                tbProductID.BackColor = Color.Red;
                MessageBox.Show("Please add Product ID which you want to delete","Error on Deletion",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

//Exit Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


//Update Button
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            tbTotalProduct.Text = string.Empty;

            //Creating Instance of AddOrUpdate from
            var update = new AddOrUpdate();

            //Gets the reuslt of AddOrUpdate form operation here 
            DialogResult dialogResult = update.ShowDialog();

            //if the result value is OK then if block will executes
            if (dialogResult == DialogResult.OK)
            {
                //Getting updated product details from Product instance located in AddOrUpdate form
                product1 = update.ProductDetail;
                try
                {
                    //Calling updateProduct() method located in database class and passing product1 as an argument
                    database.updateProduct(product1);
                    displayOnGridView();
                    DisplayTotalProductsCount();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

//Getting Product by ID
        private void btnGetProduct_Click(object sender, EventArgs e)
        {
            tbTotalProduct.Text = string.Empty;
            tbProductID.BackColor= Color.White;

            if (tbProductID.Text.Length > 0)
            {
                try
                {
                    //Fetching id fom the textbox
                    int id = int.Parse(tbProductID.Text);

                    product1 = database.getProductById(id);

                    if (product1 != null)
                    {
                        
                        displayOnGridView();
                        tbProductID.Text = "";
                        tbProductID.BackColor = Color.Green;

                    }
                    else
                    {   

                        tbProductID.BackColor = Color.Red;
                        MessageBox.Show("No product available in the database with id given", "Get Product By ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please add Product ID which you want to data for!!!", "Get Product By ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


//DisplayOnGridView Method
        private void displayOnGridView()
        {
            //Creating instance of DataTable
            DataTable dataTable = new DataTable();

            //Adding column to the datatable and also providing datatype to that column value
            dataTable.Columns.Add("ProductID", typeof(int));
            dataTable.Columns.Add("ProductName", typeof(string));
            dataTable.Columns.Add("Price", typeof(decimal));
            dataTable.Columns.Add("ProductQty", typeof(int));

            // Add the retrieved product information to the DataTable
            dataTable.Rows.Add(product1.ProductID, product1.ProductName, product1.Price, product1.ProductQty);

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dataTable;
            DisplayTotalProductsCount();
        }

//Get Product By Name
        private void btnGetProductByName_Click(object sender, EventArgs e)
        {
            tbTotalProduct.Text = string.Empty;

            try
            {
                //Calling GetProductByName() method located in database class
                dataGridView1.DataSource = database.GetProductByName();
                DisplayTotalProductsCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

//Data Grid View Cell Formatting
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Index of the quantity column in the data grid view
            const int quantityColumnIndex = 3;


            //Appling color to quantityColumnIndex that is the index of the column
            if (e.ColumnIndex == quantityColumnIndex && e.Value != null)
            {
                int quantity = Convert.ToInt32(e.Value);

                if (quantity < 10)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (quantity >= 10 && quantity < 20)
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                    e.CellStyle.ForeColor = Color.White;

                }
                else if (quantity >= 20 && quantity < 30)
                {
                    e.CellStyle.BackColor = Color.Orange;
                    e.CellStyle.ForeColor = Color.White;

                }
                else if (quantity >= 30 && quantity < 50)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }


//Display Total numbe of product in the database
        private void DisplayTotalProductsCount()
        {
            //Calling GetTotalProductsCount() method located in database class to get total product in the database
            int totalProducts = database.GetTotalProductsCount();

            if (totalProducts >= 0)
            {
                //Printing it to the textbox
               tbTotalProduct.Text = totalProducts.ToString();
            }
            else
            {
                MessageBox.Show("Error retrieving total products count.", "Total Number of product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}