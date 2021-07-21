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
        public void Restock()
        {
            Console.WriteLine("Please Enter The New Stock Information here...");
            Console.WriteLine("CoffeeType..?");
            var CoffeeType = Console.ReadLine();

            Console.WriteLine("CoffeePrice..?");
            var CoffeePrice = Console.ReadLine();

            Console.WriteLine("Quantity..?");
            var Qty = Console.ReadLine();

            DateTime AddedOn = DateTime.UtcNow;

            products.Add(new Product(CoffeeType, decimal.Parse(CoffeePrice), Int32.Parse(Qty), AddedOn));

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
            Console.WriteLine("Stock Added To Database");
            sqlcon.Close();
        }



    }
}