using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Entity.Models;
using System.Linq;
using Moq;

namespace MVC.Entity.Models.Tests
{
    [TestClass]
    public class UnitTest2
    {
        private Product[] products = {
                                         new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                                         new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                                         new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                                         new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                                     };

        [TestMethod]

        public void Sum_Products_Correctly()
        {
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            //var discounter = new MinimumDiscountHelper();
            var target = new LinqValueCalculator(mock.Object);
            //var goalTotal = products.Sum(m => m.Price);
            var result = target.ValueProducts(products);
            Assert.AreEqual(products.Sum(e=>e.Price), result);
        }

        private Product[] createProduct(decimal value)
        {
            return new[] {new Product{Price=value}};
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Pass_Through_Varable_Discounts()
        {
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v <= 0))).Throws<ArgumentOutOfRangeException>();
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100))).Returns<decimal>(total => total * 0.9M);
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10M, 100M, Range.Inclusive))).Returns<decimal>(total => total - 5);
            var target = new LinqValueCalculator(mock.Object);
            decimal FiveDollarDiscount = target.ValueProducts(createProduct(5));
            decimal TenDollarDiscount = target.ValueProducts(createProduct(10));
            decimal FiftyDollarDiscount = target.ValueProducts(createProduct(50));
            decimal HundredDollarDiscount = target.ValueProducts(createProduct(100));
            decimal FiveHundredDollarDiscount = target.ValueProducts(createProduct(500));


            Assert.AreEqual(5, FiveDollarDiscount, "$5 Fail");
            Assert.AreEqual(5, TenDollarDiscount, "$10 Fail");
            Assert.AreEqual(45, FiftyDollarDiscount, "$50 Fail");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 Fail");
            Assert.AreEqual(450, FiveHundredDollarDiscount, "$500 Fail");
            target.ValueProducts(createProduct(-1));
            target.ValueProducts(createProduct(0));
        }

    }
}
