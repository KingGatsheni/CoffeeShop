namespace Coffee_Shop.Models
{
    public class Reports
    {
        public int SalesId { get; set; }
        public string CoffeeType { get; set; }
        public decimal CoffeePrice { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }

        public Reports(int salesId, string coffeeType, decimal coffeePrice, int qty, decimal total)
        {
            SalesId = salesId;
            CoffeeType = coffeeType;
            CoffeePrice = coffeePrice;
            Qty = qty;
            Total = total;
        }
    }
} 