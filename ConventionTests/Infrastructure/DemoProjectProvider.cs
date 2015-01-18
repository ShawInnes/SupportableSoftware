using System.Xml.Linq;
using TestStack.ConventionTests.Internal;

namespace ConventionTests.Infrastructure
{
    public class DemoProjectProvider : IProjectProvider
    {
        public XDocument LoadProjectDocument(string resolveProjectFilePath)
        {
            return XDocument.Load(@"..\..\..\ConventionTestsDemo\ConventionTestsDemo.csproj");
        }
    }
}