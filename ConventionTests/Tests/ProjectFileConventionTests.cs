using ApprovalTests.Reporters;
using ConventionTests.Conventions;
using ConventionTests.Infrastructure;
using ConventionTestsDemo.Models;
using NUnit.Framework;
using TestStack.ConventionTests;

namespace ConventionTests.Tests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class ProjectFileConventionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProjFileSomething()
        {
            Convention.IsWithApprovedExeptions(new NotHavePreOrPostBuildActionsConvention(),
                new ProjectFileBuildActions(typeof(BadModelView).Assembly, new DemoProjectProvider()));
        }
    }
}