using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Entities
{
    /// <summary>
    /// Cart Item is collection of Items added in the cart 
    /// </summary>
    public class CartItem
    {
        public CartItem()
        {
            ProcessedQuantity = 0;
            PendingForProcessQuantity = OrderedQuantity;
            GrossAmount = 0;
        }

        public Product ProductItem { get; set; }

        public int OrderedQuantity { get; set; }

        /// <summary>
        /// this property keep the track of count to which promotion applied
        /// </summary>
        public int ProcessedQuantity { get; set; }

        /// <summary>
        /// this property keep the track of count to which promotion is pending
        /// </summary>
        public int PendingForProcessQuantity { get; set; }

        public decimal GrossAmount { get; set; }

    }
}
