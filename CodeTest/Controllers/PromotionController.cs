using System.Threading.Tasks;
using CodeTest.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        [Route("ApplyPromotion")]
        public async Task<int> ApplyPromotion()
        {
           return await _promotionService.ApplyPromotion();           
        }
    }
}