using System.Collections.Generic;
using System.Linq;
using Enforcer.Core.Rules;
using Enforcer.Core.Rules.Custom;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ConventionTests
{
    public class MethodCallRule : CustomRuleWithMonoCecil
    {
        private readonly string illegalMethodName;

        public MethodCallRule(string illegalMethodName)
        {
            this.illegalMethodName = illegalMethodName;
        }

        public override IEnumerable<Violation> PerformCustomValidation(MethodDefinition method)
        {
            var debug = method.Body.Instructions.ToList();
            var results = method.Body.Instructions.Where(i => i.OpCode.Code == Code.Call &&
                                                              ((MethodReference) i.Operand).FullName.EndsWith(
                                                                  illegalMethodName));
            var list = new List<Violation>();

            foreach (var result in results)
            {
                list.Add(new MethodCallViolation(method.FullName, illegalMethodName));
            }

            return list;
        }
    }
}