using System;
using NUnit.Framework;
using Shouldly;

namespace TestabilityTests
{
    [TestFixture]
    public class SelfIncrementingTestableClockShould
    {
        [Test]
        public void AllowClockToBeSet()
        {
            var clock = new TestabilityDemo.Services.SelfIncrementingTestableClock();
            var setDate = new DateTimeOffset(2014, 12, 25, 11, 38, 00, TimeSpan.FromHours(10));

            clock.SetClock(setDate);
            clock.Now.ShouldBe(setDate.AddSeconds(1));
        }

        [Test]
        public void NotReturnSameValueForSubsequentCalls()
        {
            var clock = new TestabilityDemo.Services.SelfIncrementingTestableClock();
            var setDate = new DateTimeOffset(2014, 12, 25, 11, 38, 00, TimeSpan.FromHours(10));

            clock.SetClock(setDate);
            for (int i = 1; i <= 100; i++)
            {
                clock.Now.ShouldBe(setDate.AddSeconds(i));
            }
        }
    }
}