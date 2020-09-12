using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Entities
{
    /// <summary>
    /// This class is responsible for group promotion of products
    /// </summary>
    public class CombinedPromotion : Promotion
    {
        //This Property will have terms and condition for combined promotion
        public List<PromotionTerms> PromotionTermsConditionList { get; set; }
    }
}
