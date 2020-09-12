namespace PromotionEngine.Interfaces
{
    using PromotionEngine.Entities;
    public interface ICart
    {
        decimal CartAmount { get; set; }
        void ApplyPromotions();
        void AddProduct(Product product, int quantity);
    }
}
