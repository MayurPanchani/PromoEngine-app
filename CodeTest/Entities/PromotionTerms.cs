using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Entities
{
    /// <summary>
    /// This class used to define promotion terms and conditions
    /// </summary>
    public class PromotionTerms
    {
        public string ProductSKU { get; set; }
        public int Quantity { get; set; }        
        public int PromotionalPrice { get; set; }
    }
}
