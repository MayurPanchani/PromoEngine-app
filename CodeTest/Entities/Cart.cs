
namespace PromotionEngine.Entities
{
    using PromotionEngine.Interfaces;    
    using System.Collections.Generic;
    public class Cart : ICart
    {
        public Cart()
        {
            Promotions = new List<Promotion>();
            CartAmount = 0;
        }

        public List<Promotion> Promotions { get; set; }

        public decimal CartAmount { get; set; }
    }
}
