using CodeTest.Services;
using System;
using System.Collections.Generic;
using System.Text;
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
        public async void Get_ApplyPromotion_response()
        {
            //Arrange

            //Act
            var result = await _sut.ApplyPromotion();

            //Assert
            Assert.NotEqual(0, result);
            Assert.Equal(1, result);
        }
       
    }
}
