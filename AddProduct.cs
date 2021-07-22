using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Coffee_Shop.Configs;
using Coffee_Shop.Models;

namespace Coffee_Shop
{
    public class AddProduct
    {
        private List<Product> products = new List<Product>();
        private DbConfig Db = new DbConfig();
        private bool isRunning = true;
        private DateTime AddedOn;
        public void Restock()
        {
            while (isRunning)
            {
                Console.WriteLine("Please Enter The New Product Information here...");
                Console.WriteLine("CoffeeType..?");
                var CoffeeType = Console.ReadLine();

                Console.WriteLine("CoffeePrice..?");
                var CoffeePrice = Console.ReadLine();

                Console.WriteLine("Quantity..?");
                var Qty = Console.ReadLine();

                AddedOn = DateTime.UtcNow;
                products.Add(new Product(CoffeeType, decimal.Parse(CoffeePrice), Int32.Parse(Qty), AddedOn));
                Console.WriteLine("Press 1 to continue  Adding Products and press 2 to exit Menu.");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    isRunning =true;
                    Console.Clear();
                }
                else if (input == "2")
                {
                    isRunning =false;
                }
            }
            Console.WriteLine("Adding Product info To DataStore.......");
            SqlConnection sqlcon = new SqlConnection(Db._Sqlconnection);
            sqlcon.Open();

            foreach (var product in products)
            {
                string AddProd = "insert into TblProducts values(@CoffeeType,@CoffeePrice,@Quantity,@AddedOn)";
                SqlCommand cmd = new SqlCommand(AddProd, sqlcon);
                cmd.Parameters.AddWithValue("@CoffeeType", product.CoffeeType);
                cmd.Parameters.AddWithValue("@CoffeePrice", product.CoffeePrice);
                cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@AddedOn", AddedOn);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Product Info Added successful To DataStore");
            sqlcon.Close();
        }



    }
}