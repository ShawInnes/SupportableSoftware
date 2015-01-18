using System.Collections.Generic;
using System.Linq;
using Enforcer.Core.Rules;
using Enforcer.Core.Rules.Custom;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ConventionTests
{
    public class TypeNameRule : CustomRuleWithMonoCecil
    {
        private readonly string illegalTypeName;

        public TypeNameRule(string illegalTypeName)
        {
            this.illegalTypeName = illegalTypeName;
        }

        public override IEnumerable<Violation> PerformCustomValidation(MethodDefinition method)
        {
            var results = method.Body.Instructions.Where(i => i.OpCode.Code == Code.Call &&
                                                              ((MethodReference) i.Operand).DeclaringType.FullName
                                                                  .EndsWith(
                                                                      illegalTypeName));
            var list = new List<Violation>();

            foreach (var result in results)
            {
                list.Add(new TypeNameViolation(method.FullName, illegalTypeName));
            }

            return list;
        }
    }
}