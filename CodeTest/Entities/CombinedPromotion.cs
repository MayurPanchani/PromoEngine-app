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

        public override void ApplyPromotion(Cart cartList)
        {
            bool flag = false;
            bool isGroupMatch = false;
            do
            {
                // check if each filter has match  like we need C+D with a price but both should exist in Cart
                foreach (var promotionTerms in PromotionTermsConditionList)
                {
                    var r = cartList.CartItems.Where(c => c.PendingForProcessQuantity > 0)
                 .FirstOrDefault(c => c.ProductItem.SKU == promotionTerms.ProductSKU && c.PendingForProcessQuantity >= promotionTerms.Quantity);
                    if (r != null)
                        isGroupMatch = true;
                    else
                        isGroupMatch = false;

                }
                if (isGroupMatch == false)
                {
                    flag = false;
                }
                else
                {
                    foreach (var promotionTerms in PromotionTermsConditionList)
                    {
                        var r = cartList.CartItems.Where(c => c.PendingForProcessQuantity > 0)
                     .FirstOrDefault(c => c.ProductItem.SKU == promotionTerms.ProductSKU && c.PendingForProcessQuantity >= promotionTerms.Quantity);
                        if (r != null)
                        {
                            r.GrossAmount += promotionTerms.PromotionalPrice;
                            r.ProcessedQuantity += promotionTerms.Quantity;
                            r.PendingForProcessQuantity -= promotionTerms.Quantity;
                        }

                    }

                }
            }
            while (flag);
        }
    }
}
