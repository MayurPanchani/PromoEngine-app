﻿namespace PromotionEngine.Repository
{
    using PromotionEngine.Entities;
    using System.Collections.Generic;

    public class PromotionRepository
    {
        private List<Promotion> _promotions = new List<Promotion>();

        /// <summary>
        /// default constructor to get Promotions from database
        /// </summary>
        public PromotionRepository()
        {
            GetAllPromotions();
        }

        private void GetAllPromotions()
        {
            _promotions = new List<Promotion>()
            {
                new IndividualPromotion () {
                    PromotionID =1 , PromotionName ="3 Of A's" , Description = "3 Of A's for 130 " , IsActive =true ,
                    PromotionTermsCondition =   new PromotionTerms () { ProductSKU ="A" , Quantity =3 , PromotionalPrice =130}
                },
                new IndividualPromotion () {
                    PromotionID =2 , PromotionName ="2 Of B's" , Description = "2 Of B's for 45 " , IsActive =true  ,
                     PromotionTermsCondition =   new PromotionTerms () { ProductSKU ="B" , Quantity =2 , PromotionalPrice =45}
                },
                 new CombinedPromotion () {
                    PromotionID =3 , PromotionName =" C & D " , Description = "C & D for 30 " , IsActive =true ,
                     PromotionTermsConditionList = new List<PromotionTerms>()
                     {
                         new PromotionTerms () { ProductSKU ="C" , Quantity = 1  ,PromotionalPrice =0},
                         new PromotionTerms () { ProductSKU ="D" , Quantity = 1 , PromotionalPrice =  30 }
                     }
                 }
            };

        }

    }
}
