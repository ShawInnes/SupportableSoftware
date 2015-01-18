using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using TestStack.ConventionTests.ConventionData;
using TestStack.ConventionTests.Internal;

namespace ConventionTests.Infrastructure
{
    public class ProjectFileBuildActions : AbstractProjectData
    {
        public ProjectFileBuildActions(Assembly assembly, IProjectProvider projectProvider = null, IProjectLocator projectLocator = null)
            : base(assembly, projectProvider, projectLocator)
        {
        }

        public ProjectFileBuildAction[] Items
        {
            get
            {
                var project = GetProject();
                const string msbuild = "http://schemas.microsoft.com/developer/msbuild/2003";

                var elements = project
                    .Element(XName.Get("Project", msbuild))
                    .Elements(XName.Get("PropertyGroup", msbuild))
                    .Elements(XName.Get("PostBuildEvent", msbuild));

                return elements.Select(refElem =>
                    new ProjectFileBuildAction
                    {
                        BuildActionType = refElem.Name.LocalName,
                        Content = refElem.Value
                    })
                    .ToArray();
            }
        }
    }
}