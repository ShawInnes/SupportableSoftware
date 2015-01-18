using Enforcer.Core.Rules;

namespace ConventionTests.Violations
{
    public class TypeNameViolation : Violation
    {
        private readonly string methodName;
        private readonly string typeName;

        public TypeNameViolation(string methodName, string typeName)
        {
            this.methodName = methodName;
            this.typeName = typeName;
        }

        public override string Message
        {
            get { return string.Format("Illegal use of Type {0} in {1}", typeName, methodName); }
        }
    }
}