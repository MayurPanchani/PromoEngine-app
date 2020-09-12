using CodeTest.Services;
using PromotionEngine.Entities;
using PromotionEngine.Repository;
using System.Linq;
using Xunit;

namespace CodeTest.API.Test
{
    public class PromotionServiceTest
    {
        private readonly PromotionService _sut;

        public PromotionServiceTest()
        {
            _sut = new PromotionService();

        }

        [Fact]
        public async void GetCartPriceWithPromotion_Individual_response()
        {
            //Arrange
            ProductRepository productContext = new ProductRepository();
            var products = productContext.Products;

            PromotionRepository promotionDB = new PromotionRepository();
            var activePromotionList = promotionDB.GetActivePromotions();

            Cart objCart = new Cart();
            objCart.AddProduct(products.First(p => p.SKU == "A"), 3);
            objCart.AddProduct(products.First(p => p.SKU == "B"), 5);
            objCart.AddProduct(products.First(p => p.SKU == "C"), 1);            
            objCart.LoadPromotions(activePromotionList);


            //Act
            var result = await _sut.GetCartPriceWithPromotion(objCart);

            //Assert
            Assert.NotEqual(0, result);
            Assert.Equal(270, result);
        }

        [Fact]
        public async void GetCartPriceWithPromotion_IndividualAndCombined_response()
        {
            //Arrange
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
           
            //Act
            var result = await _sut.GetCartPriceWithPromotion(objCart);

            //Assert
            Assert.NotEqual(0, result);
            Assert.Equal(285, result);
        }

        [Fact]
        public async void GetCartPriceWithPromotion_Combined_response()
        {
            //Arrange
            ProductRepository productContext = new ProductRepository();
            var products = productContext.Products;

            PromotionRepository promotionDB = new PromotionRepository();
            var activePromotionList = promotionDB.GetActivePromotions();

            Cart objCart = new Cart();
            
            objCart.AddProduct(products.First(p => p.SKU == "C"), 5);
            objCart.AddProduct(products.First(p => p.SKU == "D"), 5);
            objCart.LoadPromotions(activePromotionList);


            //Act
            var result = await _sut.GetCartPriceWithPromotion(objCart);

            //Assert
            Assert.NotEqual(0, result);
            Assert.Equal(170, result);
        }

    }
}
