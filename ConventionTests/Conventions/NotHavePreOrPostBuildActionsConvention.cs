using System.Linq;
using ConventionTests.Infrastructure;
using TestStack.ConventionTests;

namespace ConventionTests.Conventions
{
    public class NotHavePreOrPostBuildActionsConvention : IConvention<ProjectFileBuildActions>
    {
        public void Execute(ProjectFileBuildActions data, IConventionResultContext result)
        {
            result.Is(
                string.Format("Pre/Post Build Actions are bad"),
                data.Items.Where(p => !string.IsNullOrEmpty(p.Content)));
        }

        public string ConventionReason
        {
            get { return "this convention does something with project files"; }
        }
    }
}