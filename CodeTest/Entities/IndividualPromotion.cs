using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Entities
{
    /// <summary>
    /// This class is responsible for  Individual SKU promotion
    /// </summary>
    public class IndividualPromotion : Promotion
    {
        //This Property will have terms and condition for Individual SKU promotion 
        public PromotionTerms PromotionTermsCondition { get; set; }

        public override void ApplyPromotion(Cart cartList)
        {

        }
    }
}
