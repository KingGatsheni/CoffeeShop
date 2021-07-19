using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Coffee_Shop.Configs;
using Coffee_Shop.Models;

namespace Coffee_Shop
{
    class Program
    {
        private static Dictionary<int, Product> QueryById = new Dictionary<int, Product>();
        private static decimal Total;
        private static decimal payA;
        private static decimal change;
        private static void Main(string[] args)
        {
            MenuItems();
            SearchbyId();
        }
        private static void SearchbyId()
        {
            Console.WriteLine("Select Item to purchase by Id");
            string _id = Console.ReadLine();
            Console.WriteLine("Enter ProductId: " + Int32.Parse(_id));
            var value1 = QueryById[Int32.Parse(_id)];
            string purValue = String.Format("{0,-10}|{1,-10}|{2,-10}|{3,-10}",value1.CoffeeType+ "\t",value1.CoffeePrice + "\t",value1.Quantity+"\t",value1.AddedOn);
            Console.WriteLine(purValue);
            Console.WriteLine("To Proceed with Sale of this item Enter Qty purchased");
            string qty = Console.ReadLine();
            Console.WriteLine("Enter Quantity Amount Here: " + Int32.Parse(qty));
         
            foreach (var kvp in QueryById)
            {
                if(Int32.Parse(_id) == kvp.Key){
                var ProductPrice = kvp.Value.CoffeePrice;
                Total = ProductPrice * Int32.Parse(qty);
                Console.WriteLine("Total Due: "+ Total);
                }
            }
            Console.WriteLine("Please Enter Payment Amount");
            string Payamount = Console.ReadLine();
            payA = decimal.Parse(Payamount);
            if(Total > payA)
            {
                Console.WriteLine("Insuffient Funds Please Pay the displayed value");
                Console.WriteLine("enter Total Here: ");
                string a = Console.ReadLine();
                payA = decimal.Parse(a);
            }
            else
            {
                var con = new DbConfig();
                SqlConnection sqlcon = new SqlConnection(con._Sqlconnection);
                string makeSale = "insert into TblSales values(@ProductId,@Qty,@SoldAt,@Total)";
                sqlcon.Open();
                var ProdId = Int32.Parse(_id);
                SqlCommand cmd = new SqlCommand(makeSale,sqlcon);
                cmd.Parameters.AddWithValue("@ProductId", ProdId);
                cmd.Parameters.AddWithValue("@Qty", Int32.Parse(qty));
                cmd.Parameters.AddWithValue("@SoldAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@Total", Total);
                cmd.ExecuteNonQuery();
                string updateProducts = "update TblProducts set Quantity = Quantity - '"+Int32.Parse(qty)+"' where ProductId = '"+Int32.Parse(_id)+"'";
                SqlCommand upD = new SqlCommand(updateProducts, sqlcon);
                upD.ExecuteScalar();
                string SId = "select top 1 SaleId from TblSales order by SaleId desc";
                SqlCommand Idcom = new SqlCommand(SId, sqlcon);
                var Refid = Idcom.ExecuteScalar();
                string pay = "insert into TblPays values(@SaleId,@Date,@SalesTotal)";
                SqlCommand cx = new SqlCommand(pay, sqlcon);
                cx.Parameters.AddWithValue("@SaleId", Refid);
                cx.Parameters.AddWithValue("@Date", DateTime.Now);
                cx.Parameters.AddWithValue("SalesTotal", Total);
                cx.ExecuteNonQuery();
                Console.WriteLine("Transcation Sucessful!");
                change = payA - Total;
                Console.WriteLine("Change: R"+change);
                sqlcon.Close();
            }
        }
        private static void MenuItems()
        {
            Console.WriteLine("Welcome to our Virtual Coffee Shop this is our menu List");
            var conStr = new DbConfig();
            SqlConnection con = new SqlConnection(conStr._Sqlconnection);
            string queryProducts = "select * from Tblproducts";
            con.Open();
            SqlCommand cm = new SqlCommand(queryProducts, con);
            SqlDataReader rw = cm.ExecuteReader();

            while (rw.Read())
            {
                string data = String.Format("{0,-10}|{1,-10}|{2,-10}|{3,-10}|{4,-5}",rw.GetInt32(0)+"\t",rw.GetString(1)+"\t",rw.GetDecimal(2)+"\t",rw.GetInt32(3)+"\t",rw.GetDateTime(4));
                QueryById.Add(rw.GetInt32(0),new Product(rw.GetString(1),rw.GetDecimal(2),rw.GetInt32(3),rw.GetDateTime(4)));
                Console.WriteLine(data);
            }
            con.Close();

        }
        
    }
}