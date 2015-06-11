using System;
using Moq;
using NUnit.Framework;
using Shouldly;
using TestabilityDemo.Services;

namespace TestabilityTests
{
    [TestFixture]
    public class GoodBonusPizza
    {
        public class PriceCalculator
        {
            private readonly IClock _clock;

            public PriceCalculator(IClock clock)
            {
                _clock = clock;
            }

            public string GetPrice()
            {
                var day = _clock.UtcNow.DayOfWeek;

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
            var mock = new Mock<IClock>();
            // This is a Monday
            mock.Setup(foo => foo.UtcNow).Returns(new DateTimeOffset(new DateTime(2015, 06, 08)));
            mock.Object.UtcNow.DayOfWeek.ShouldBe(DayOfWeek.Monday);

            var calculator = new PriceCalculator(mock.Object);
            var price = calculator.GetPrice();
            price.ShouldBe("full price");
        }

        [Test]
        public void HalfPriceOnTuesdays()
        {
            var mock = new Mock<IClock>();
            // This is a Tuesday
            mock.Setup(foo => foo.UtcNow).Returns(new DateTimeOffset(new DateTime(2015, 06, 09)));
            mock.Object.UtcNow.DayOfWeek.ShouldBe(DayOfWeek.Tuesday);
            
            var calculator = new PriceCalculator(mock.Object);
            var price = calculator.GetPrice();

            price.ShouldBe("half price");
        }
    }
}