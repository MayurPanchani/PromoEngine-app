using PromotionEngine.Entities;
using PromotionEngine.Repository;
using System;
using System.Linq;

namespace PromotionEngineConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from Promotion Engine Console !");
            CalculatePromotions();
        }


        public static void CalculatePromotions()
        {
            ProductRepository productContext = new ProductRepository();
            var products = productContext.Products;         

            PromotionRepository promotionDB = new PromotionRepository();
            var activePromotionList = promotionDB.GetActivePromotions();

            Cart objCart = new Cart();

            objCart.AddProduct(products.First(p => p.SKU == "A"), 3);
            objCart.AddProduct(products.First(p => p.SKU == "B"), 5);
            objCart.AddProduct(products.First(p => p.SKU == "C"), 1);
            objCart.AddProduct(products.First(p => p.SKU == "D"), 1);


            objCart.LoadPromotions(activePromotionList);

            var result = objCart.CalculatePromotionOnCardValue();

            

            Console.WriteLine(string.Format("Total:{0}", result));

        }
    }
}
