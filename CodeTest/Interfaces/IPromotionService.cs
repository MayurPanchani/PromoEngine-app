using System.Threading.Tasks;

namespace CodeTest.Interfaces
{
    public interface IPromotionService
    {
        public Task<int> ApplyPromotion();
    }
}
