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

        /// <summary>
        /// Calculate 
        /// </summary>
        /// <param name="cartList"></param>
        public override void ApplyPromotion(Cart cartList)
        {
            bool flag = false;
            do
            {
                var result = cartList.CartItems.Where(c => c.PendingForProcessQuantity > 0).FirstOrDefault(c => c.ProductItem.SKU == PromotionTermsCondition.ProductSKU
                      && c.PendingForProcessQuantity >= PromotionTermsCondition.Quantity);
                if (result != null)
                {
                    result.GrossAmount += PromotionTermsCondition.PromotionalPrice;
                    result.ProcessedQuantity += PromotionTermsCondition.Quantity;
                    result.PendingForProcessQuantity -= PromotionTermsCondition.Quantity;

                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            while (flag);
        }
    }
}
