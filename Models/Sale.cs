using System;
using System.ComponentModel.DataAnnotations;

namespace Coffee_Shop.Models
{
    public class Sale
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }
        public DateTime SoldAt { get; set; }

        public Sale(int productId, int qty, decimal total, DateTime soldAt)
        {
            ProductId = productId;
            Qty = qty;
            Total = total;
            SoldAt = soldAt;
        }
    }
}