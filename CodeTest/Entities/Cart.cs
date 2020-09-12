
namespace PromotionEngine.Entities
{
    using PromotionEngine.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Cart : ICart
    {
        private Dictionary<string, CartItem> _cartItems = new Dictionary<string, CartItem>();
        private List<CartItem> cartItemsList = new List<CartItem>();

        public Cart()
        {
            Promotions = new List<Promotion>();
            CartAmount = 0;
        }

        public List<Promotion> Promotions { get; set; }

        public decimal CartAmount { get; set; }

        public List<CartItem> CartItems
        {
            get { return _cartItems.Values.ToList(); }
        }

        public void LoadPromotions(List<Promotion> promotionList)
        {
            Promotions = promotionList;
        }


        public void AddProduct(Product productItem, int quantity)
        {
            if (!_cartItems.ContainsKey(productItem.SKU))
            {
                _cartItems.Add(productItem.SKU, new CartItem() { ProductItem = productItem, OrderedQuantity = quantity, ProcessedQuantity = 0, PendingForProcessQuantity = quantity });
            }
            else
                throw new System.Exception("Product with same SKU already added in to cart");
        }

        public decimal CalculatePromotionOnCardValue()
        {
            CalculatePromotionsAmount();
            return CalculateCartAmount();
        }

        /// <summary>
        /// Calculate Promotions Amount based on promotions type and add non promotional amount
        /// </summary>
        private void CalculatePromotionsAmount()
        {
            foreach (var promotion in Promotions)
            {
                promotion.ApplyPromotion(this);
            }

            foreach (var cartItem in CartItems.Where(p => p.PendingForProcessQuantity > 0))
            {
                cartItem.GrossAmount += (cartItem.PendingForProcessQuantity * cartItem.ProductItem.UnitPrice);
                cartItem.ProcessedQuantity += cartItem.PendingForProcessQuantity;
                cartItem.PendingForProcessQuantity -= cartItem.PendingForProcessQuantity;
            }
        }

        private decimal CalculateCartAmount()
        {
            this.CartAmount = this.CartItems.Sum(s => s.GrossAmount);
            return this.CartAmount;
        }

        

    }
}
