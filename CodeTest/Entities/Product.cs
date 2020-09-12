namespace PromotionEngine.Entities
{
    using PromotionEngine.Interfaces;

    /// <summary>
    /// This class is responsible to uniquely identify the product by SKU(Primary Key)
    /// </summary>
    public class Product : IProduct
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
