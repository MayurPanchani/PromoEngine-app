using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Entities
{
    /// <summary>
    /// This abstract class will be implemented by different kind of promotions (for now considered two - Individual & Combined)
    /// </summary>
    public abstract class Promotion
    {
        public int PromotionID { get; set; }

        public string PromotionName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public abstract void ApplyPromotion(Cart cart);
    }
}
