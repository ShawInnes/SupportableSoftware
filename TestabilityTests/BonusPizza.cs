using System;
using NUnit.Framework;
using Shouldly;

namespace TestabilityTests
{
    [TestFixture]
    public class BonusPizza
    {
        [Test]
        public void FullPrice()
        {
            var price = string.Empty;

            var day = DateTime.Now.DayOfWeek;
            if (day == DayOfWeek.Tuesday)
            {
                price = "half price";
            }
            else if (day != DayOfWeek.Tuesday)
            {
                price = "full price";
            }

            price.ShouldBe("full price");
        }

        [Test]
        public void HalfPriceOnTuesdays()
        {
            var price = string.Empty;
         
            var day = DateTime.Now.DayOfWeek;
            if (day == DayOfWeek.Tuesday)
            {
                price = "half price";
            }
            else if (day != DayOfWeek.Tuesday)
            {
                price = "full price";
            }

            price.ShouldBe("half price");
        }
    }
}