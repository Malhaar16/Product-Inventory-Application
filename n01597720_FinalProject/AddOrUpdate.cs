using n01597720_FinalProject.Models.DataLayer;
using n01597720_FinalProject.Models.DataLayer.Database_Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace n01597720_FinalProject
{
    public partial class AddOrUpdate : Form
    {

        //Instance of Product class which in this context assigned value to the varibles in the product class
        public Product ProductDetail { get; set; } = null!;


        public AddOrUpdate()
        {
            InitializeComponent();
        }

        //As soon as AddOrUpdate from is loaded it will inializes the instance of product class if prodcutdetail is null
        private void AddOrUpdate_Load(object sender, EventArgs e)
        {
            if (ProductDetail == null)
            {

                ProductDetail = new Product();
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        //Exit Button 
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Get Data Button, here in this context this button is used to get data fo updation
        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (tbProductIDs.Text.Length > 0)
            {
                try
                {
                    //Creating instance of Product Database and Product class
                    ProductDatabase database = new ProductDatabase();
                    Product product1 = new Product();

                    //Getting the product id from the textbox
                    int id = int.Parse(tbProductIDs.Text);

                    product1 = database.getProductById(id);//Fetching the data from the database by giving the id as an argument

                    //product1 value is not null if block will executes
                    if (product1 != null)
                    {
                        //Assigning value to textboxes
                        tbProductIDs.Text = product1.ProductID.ToString();
                        tbProductNames.Text = product1.ProductName;
                        tbProductPrices.Text = product1.Price.ToString();
                        tbProductQuantitys.Text = product1.ProductQty.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No product available in the database", "Get Poduct By ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Submit Button
        private void btnSumit_Click(object sender, EventArgs e)
        {
            //if all the details is filled below code will executes or else part will executes
            if (tbProductIDs.Text.Length > 0 && tbProductNames.Text.Length > 0 && tbProductPrices.Text.Length > 0 && tbProductQuantitys.Text.Length > 0)
            {
                ProductDetail.ProductID = int.Parse(tbProductIDs.Text);
                ProductDetail.ProductName = tbProductNames.Text;
                ProductDetail.Price = decimal.Parse(tbProductPrices.Text);
                ProductDetail.ProductQty = int.Parse(tbProductQuantitys.Text);

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (tbProductIDs.Text.Length > 0 || tbProductNames.Text.Length > 0 || tbProductPrices.Text.Length > 0 || tbProductQuantitys.Text.Length > 0)
                {
                    //Using StringBuilder to print the error message
                    StringBuilder errorMessage = new StringBuilder("Please fill in the following field(s):\n");


                    if (string.IsNullOrWhiteSpace(tbProductIDs.Text))
                    {
                        errorMessage.AppendLine("- Product ID");
                        tbProductIDs.BackColor = Color.Red;
                    }

                    if (string.IsNullOrWhiteSpace(tbProductNames.Text))
                    {
                        errorMessage.AppendLine("- Product Name");
                        tbProductNames.BackColor = Color.Red;
                    }

                    if (string.IsNullOrWhiteSpace(tbProductPrices.Text))
                    {
                        errorMessage.AppendLine("- Product Price");
                        tbProductPrices.BackColor = Color.Red;
                    }

                    if (string.IsNullOrWhiteSpace(tbProductQuantitys.Text))
                    {
                        errorMessage.AppendLine("- Product Quantity");
                        tbProductQuantitys.BackColor = Color.Red;
                    }

                    MessageBox.Show(errorMessage.ToString(), "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }

            }
        }
    }
}
