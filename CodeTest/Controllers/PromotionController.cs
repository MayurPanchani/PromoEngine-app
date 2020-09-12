using System.Threading.Tasks;
using CodeTest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Entities;
using PromotionEngine.Repository;
using System.Linq;

namespace CodeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService; 
        }

        [HttpPost]
        [Route("GetCartPriceWithPromotion")]
        public async Task<decimal> GetCartPriceWithPromotion(Cart objCart)
        {
            /* In case of api call we will get Cart object as input paramter
             * For testing purpose generating Cart Object manually to act as input parameter              
            */
            #region Generate Cart Object manually to act as ApplyPromotion controller input parameter
            ProductRepository productContext = new ProductRepository();
            var products = productContext.Products;
            
            objCart.AddProduct(products.First(p => p.SKU == "A"), 3);
            objCart.AddProduct(products.First(p => p.SKU == "B"), 5);
            objCart.AddProduct(products.First(p => p.SKU == "C"), 1);
            objCart.AddProduct(products.First(p => p.SKU == "D"), 1);

            #endregion

            return await _promotionService.GetCartPriceWithPromotion(objCart);           
        }
    }
}