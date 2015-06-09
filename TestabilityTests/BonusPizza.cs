using System;
using NUnit.Framework;
using Shouldly;

namespace TestabilityTests
{
    [TestFixture]
    public class BonusPizza
    {
        public class PriceCalculator
        {
            public string GetPrice()
            {
                var day = DateTime.Now.DayOfWeek;

                if (day == DayOfWeek.Tuesday)
                {
                    return "half price";
                }

                return "full price";
            }
        }

        [Test]
        public void FullPrice()
        {
            var calculator = new PriceCalculator();
            var price = calculator.GetPrice();

            price.ShouldBe("full price");
        }

        [Test]
        public void HalfPriceOnTuesdays()
        {
            var calculator = new PriceCalculator();
            var price = calculator.GetPrice();

            price.ShouldBe("half price");
        }
    }
}