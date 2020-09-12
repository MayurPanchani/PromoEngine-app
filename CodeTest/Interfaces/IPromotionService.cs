using PromotionEngine.Entities;
using System.Threading.Tasks;

namespace CodeTest.Interfaces
{
    public interface IPromotionService
    {               
        public Task<decimal> GetCartPriceWithPromotion(Cart cartList);
    }
}
