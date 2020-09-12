using System.Linq;
using System.Threading.Tasks;
using CodeTest.Interfaces;
using PromotionEngine.Entities;
using PromotionEngine.Repository;

namespace CodeTest.Services
{  
    public class PromotionService : IPromotionService
    {        

        public Task<decimal> GetCartPriceWithPromotion(Cart cartList)
        {
            return Task.Run(() =>
            {              
                //Get all active Promotions from the 
                PromotionRepository _promotionRepository = new PromotionRepository();
                var activePromotionsList = _promotionRepository.GetActivePromotions();                

                //Load active promotions
                cartList.LoadPromotions(activePromotionsList);
                return cartList.CalculatePromotionOnCardValue();
            });

        }
    }
}
