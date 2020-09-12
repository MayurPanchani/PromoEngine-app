namespace PromotionEngine.Interfaces
{
    using PromotionEngine.Entities;
    public interface ICart
    {
        decimal CartAmount { get; set; }
        decimal CalculatePromotionOnCardValue();
        void AddProduct(Product product, int quantity);
    }
}
