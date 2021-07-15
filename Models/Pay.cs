using System;
using System.ComponentModel.DataAnnotations;

namespace Coffee_Shop.Models
{
    public class Pay
    {
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public decimal SalesTotal { get; set; }
        public DateTime  Date { get; set; }

        public Pay(int saleId, Sale sale, decimal salesTotal, DateTime date)
        {
            SaleId = saleId;
            Sale = sale;
            SalesTotal = salesTotal;
            Date = date;
        }
    }
}