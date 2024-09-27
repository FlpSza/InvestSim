using Microsoft.AspNetCore.Mvc;

namespace InvestmentSimulator.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
