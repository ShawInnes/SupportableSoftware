using System.Linq;
using ConventionTestsDemo.ViewModels;
using Enforcer.Core;
using Enforcer.Core.Rules;
using NUnit.Framework;
using Should;

namespace ConventionTests
{
    [TestFixture]
    public class DateTimeConventionTests
    {
        private ConventionEnforcer _enforcer;
        private Violation[] _violations;

        [SetUp]
        public void Setup()
        {
            // Arrange
            var dateTimeRule = new TypeNameRule("System.DateTime");
            var dateTimeNowRule = new MethodCallRule("System.DateTime::get_Now()");
            var dateTimeUtcNowRule = new MethodCallRule("System.DateTime::get_UtcNow()");
            var dateTimeOffsetNowRule = new MethodCallRule("System.DateTimeOffset::get_Now()");
            var dateTimeOffsetUtcNowRule = new MethodCallRule("System.DateTimeOffset::get_UtcNow()");

            _enforcer = new ConventionEnforcerBuilder()
                .WithTypeResolver(new MyTypeResolver())
                .AndTheseRules(dateTimeRule,
                    dateTimeNowRule,
                    dateTimeUtcNowRule,
                    dateTimeOffsetNowRule,
                    dateTimeOffsetUtcNowRule)
                .ToRunAgainstTheseProgramAssemblies(typeof (DemoViewModel).Assembly)
                .Build();

            // Act
            _violations = _enforcer.Enforce().ToArray();
        }

        [Test]
        public void ThereShouldBeNoDateTimeNow()
        {
            _violations.Any().ShouldBeFalse(_violations.CombinedErrorMessages());
        }
    }
}