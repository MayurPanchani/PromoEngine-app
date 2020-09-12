namespace PromotionEngine.Repository
{
    using PromotionEngine.Entities;
    using System.Collections.Generic;

    /// <summary>
    /// This class is responsible to laad products from DB, currently adding some product as per test case provided.
    /// </summary>
    public class ProductRepository
    {
        private List<Product> _products = new List<Product>();

        // Default constructor to load priducts        
        public ProductRepository()
        {
            LoadProducts();
        }

        // Load products from database - Pleae note : here adding dummy priducts 
        private void LoadProducts()
        {
            _products = new List<Product>()
            {
                new Product () { SKU ="A" , UnitPrice =50 } ,
                new Product () { SKU ="B" , UnitPrice =30 } ,
                new Product () { SKU ="C" , UnitPrice =20 } ,
                new Product () { SKU ="D" , UnitPrice =15 } ,
            };
        }
       
        /// Products Lists object        
        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

    }
}
