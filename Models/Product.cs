using System;
using System.ComponentModel.DataAnnotations;

namespace Coffee_Shop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string CoffeeType { get; set; }
        public decimal CoffeePrice { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedOn { get; set; }

        public Product(string coffeeType, decimal coffeePrice, int quantity, DateTime addedOn)
        {
            CoffeeType = coffeeType;
            CoffeePrice = coffeePrice;
            Quantity = quantity;
            AddedOn = addedOn;
        }
    }
}