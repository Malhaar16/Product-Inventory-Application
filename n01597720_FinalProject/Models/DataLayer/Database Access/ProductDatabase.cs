using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace n01597720_FinalProject.Models.DataLayer.Database_Access
{
    public class ProductDatabase
    {
        //Fetches the connection string named FinalProject from the app.config file
        private string ConnectionString =>
        ConfigurationManager.ConnectionStrings["FinalProject"].ConnectionString;

        //Inizialinzing instance of Product class
        Product product = null!;


//Add product method which have product1 as parameter
        public void AddProductDetails(Product product1)
        {
            try
            {
                //This if condition will check avaliablity of productID in the database by calling IsProductIdExist method
                //by passing ProductID as an parameter
                if (IsProductIdExists(product1.ProductID))
                {
                    MessageBox.Show("Product ID already exists in the database.");
                    return;
                }

                //Query to add data in the database
                string addquery = "INSERT INTO ProductInventory (ProductID, ProductName, ProductPrice, ProductQuantity)" +
                                  "VALUES (@ID, @NAME, @PRICES, @QTY)";

                using SqlConnection connection = new(ConnectionString);
                using SqlCommand command = new(addquery, connection);

                command.Parameters.AddWithValue("@ID", product1.ProductID);
                command.Parameters.AddWithValue("@NAME", product1.ProductName);
                command.Parameters.AddWithValue("@PRICES", product1.Price);
                command.Parameters.AddWithValue("@QTY", product1.ProductQty);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery(); //Executing the query

                //if data is added in the database if block will executes or else block will executes
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data inserted successfully.","Add Product",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No rows affected. Insertion failed.", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred: {ex.Message}", "Exception Add Product", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        //Check the product id in the database
        private bool IsProductIdExists(int productID)
        {
            try
            {
                //Query to check the ID
                string checkQuery = "SELECT COUNT(*) FROM ProductInventory WHERE ProductID = @ID";

                using SqlConnection connection = new SqlConnection(ConnectionString);
                using SqlCommand command = new SqlCommand(checkQuery, connection);

                command.Parameters.AddWithValue("@ID", productID);

                connection.Open();
                int count = (int)command.ExecuteScalar(); //Executing the command and get in return single value of int

                if (count > 0)
                {
                    return true;
                }
                else
                { 
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while checking product ID: {ex.Message}", "Exception Product ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Return true to avoid adding data in case of an error
            }
        }

//Display product on datagrid view of type DataTable
        public DataTable GetAllProduct()
        {
            try
            {
                //Creating instance of DataTable
                DataTable dataTable = new DataTable();

                //Query to fetch all data from the database
                string allDataQuery = "SELECT * FROM ProductInventory";

                using SqlConnection connection = new SqlConnection(ConnectionString);
                using SqlCommand command = new SqlCommand(allDataQuery, connection);

                connection.Open();

                //As soon as ExecuteReader() fetches all the data it will assigned to reader instance of SqlDataeader class
                //which will be used to read row fecthed from the database
                SqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);// This will populates the datatable with the data assigned to reader class 

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Exception Product Fetching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }
        }

//Remove Product
        public void RemoveProduct(Product product1)
        {
            try
            {
                //Query to remove product
                string removequery = "DELETE FROM ProductInventory where ProductID = @ID ";

                using SqlConnection connection = new(ConnectionString);
                using SqlCommand command = new(removequery, connection);

                command.Parameters.AddWithValue("@ID", product1.ProductID);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                //If product is deleted if block will be executed
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data deleted successfully.", "Delete Product ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No rows affected. Insertion failed.", "Error Delete Product ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred: {ex.Message}", "Exception Product Deletion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }

//Fetching product name from databse by giving the product id as an parameter
        public string fetchProductName(Product product1)
        {
            try
            {
                if (product1 != null)
                {
                    string fetchQuery = "SELECT ProductName FROM ProductInventory WHERE ProductID = @ID";

                    using SqlConnection connection = new(ConnectionString);
                    using SqlCommand command = new(fetchQuery, connection);

                    command.Parameters.AddWithValue("@ID", product1.ProductID);

                    connection.Open();

                    object result = command.ExecuteScalar(); //Executing ExecuteScalar() bcoz to get single value

                    if (result != null)
                    {
                        return result.ToString()!;
                    }
                    else
                    {
                        return null!;
                    }
                }
                else
                {
                    return null!;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Exception Product Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }

        }

        internal void updateProduct(Product product1)
        {
            try
            {
                //Query to update data in the database
                string updateQuery = "UPDATE ProductInventory SET ProductName = @ProductName, ProductPrice = @ProductPrice, ProductQuantity = @ProductQuantity where ProductID = @ProductID";
              
                SqlConnection connection = new(ConnectionString);
                SqlCommand command = new(updateQuery, connection);
                command.Parameters.AddWithValue("@ProductID", product1.ProductID);
                command.Parameters.AddWithValue("@ProductName", product1.ProductName);
                command.Parameters.AddWithValue("@ProductPrice", product1.Price);
                command.Parameters.AddWithValue("@ProductQuantity", product1.ProductQty);

                connection.Open();
                int count = command.ExecuteNonQuery();


                MessageBox.Show("Product Updated", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred11: {ex.Message}", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

//Getting poduct by id method
        public Product getProductById(int id)
        {
            try
            {
                
                if (id > 0)
                {
                    //Query to fetch data from the database by providing id paramenter as an where condition
                    string fetchQuery = "SELECT * FROM ProductInventory WHERE ProductID = @ID";

                    SqlConnection connection = new(ConnectionString);
                    SqlCommand command = new(fetchQuery, connection);

                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();

                    //Fetch the single row from the database and closes the connection
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow & CommandBehavior.CloseConnection);

                    //it will read the data fom the reader column wise
                    if (reader.Read())
                    {
                        //creating instance of product class
                        product = new()
                        {
                            ProductID = (int)reader["ProductID"],
                            ProductName = reader["ProductName"].ToString()!,
                            Price = (decimal)reader["ProductPrice"]!,
                            ProductQty = (int)reader["ProductQuantity"]!,

                        };
                    }

                    return product!;

                }
                else
                {
                    MessageBox.Show("Problem in fetching data", "Get Poduct By ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null!;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Exception Get Poduct By ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }
        }

//GetProductByName Method
        internal object GetProductByName()
        {
            try
            {
                
                DataTable dataTable = new DataTable();

                //Query to fetch data from the databse in asending order
                string query = "SELECT * FROM ProductInventory ORDER BY ProductName ASC";

                SqlConnection connection = new SqlConnection(ConnectionString)!;
                SqlCommand command = new SqlCommand(query, connection)!;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);//Populating the datatable by reading the row from the reader

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Exception Get Poduct By Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }

        }

//Total Product count
        public int GetTotalProductsCount()
        {
            try
            {
                SqlConnection connection = new(ConnectionString);

                //Query to count total product in the database by using Count keyword
                string countQuery = "SELECT COUNT(*) FROM ProductInventory";

                SqlCommand command = new(countQuery, connection);

                connection.Open();
                int totalCount = (int)command.ExecuteScalar(); //Getting the total count

                return totalCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Total Count", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Or any value that signifies an error in counting
            }
        }

    }
}
