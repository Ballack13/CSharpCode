using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Entity.Models;

namespace MVC.Entity.Models.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }
        [TestMethod]
        public void Discount_Above_100()
        {
            IDiscountHelper target = getTestObject();
            decimal total = 200M;

            var discountedTotal = target.ApplyDiscount(total);
            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_and_100()
        {
            IDiscountHelper target = getTestObject();
            decimal Ten_Total = 10M;
            decimal Fifty_Total = 50M;
            decimal OneHundred_Total = 100M;
            Assert.AreEqual(5M,target.ApplyDiscount(Ten_Total));
            Assert.AreEqual(95M, target.ApplyDiscount(OneHundred_Total));
            Assert.AreEqual(45M,target.ApplyDiscount(Fifty_Total));
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            IDiscountHelper target = getTestObject();
            decimal discount5 = 5M;
            decimal discount0 = 0M;

            Assert.AreEqual(5M, target.ApplyDiscount(discount5));
            Assert.AreEqual(0M, target.ApplyDiscount(discount0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Below_Zero()
        {
            IDiscountHelper target = getTestObject();
            decimal discount_negtive = -1M;
            target.ApplyDiscount(discount_negtive);
        }
    }
}
