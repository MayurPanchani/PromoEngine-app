using System.Threading.Tasks;
using CodeTest.Interfaces;

namespace CodeTest.Services
{  
    public class PromotionService : IPromotionService
    {
        public Task<int> ApplyPromotion()
        {
            return Task.Run(() =>
            {
                return 1;
            });
        }
    }
}
