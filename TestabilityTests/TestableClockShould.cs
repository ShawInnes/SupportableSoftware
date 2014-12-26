using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace TestabilityTests
{
    [TestFixture]
    public class TestableClockShould
    {
        [Test]
        public void AllowClockToBeSet()
        {
            var clock = new TestabilityDemo.Services.TestableClock();
            var setDate = new DateTimeOffset(2014, 12, 25, 11, 38, 00, TimeSpan.FromHours(10));

            clock.SetClock(setDate);
            clock.Now.ShouldBe(setDate);
        }

        [Test]
        public void ReturnSameValueForSubsequentCalls()
        {
            var clock = new TestabilityDemo.Services.TestableClock();
            var setDate = new DateTimeOffset(2014, 12, 25, 11, 38, 00, TimeSpan.FromHours(10));

            clock.SetClock(setDate);
            for (int i = 0; i < 100; i++)
            {
                clock.Now.ShouldBe(setDate);
            }
        }

        [Test]
        public void ReturnNewValueForSubsequentCallsWithTick()
        {
            var clock = new TestabilityDemo.Services.TestableClock();
            var setDate = new DateTimeOffset(2014, 12, 25, 11, 38, 00, TimeSpan.FromHours(10));

            clock.SetClock(setDate);
            clock.Now.ShouldBe(setDate);
            
            clock.Tick();
            clock.Now.ShouldBe(setDate.AddSeconds(1));

            clock.Tick();
            clock.Now.ShouldBe(setDate.AddSeconds(2));
        }
    }
}
