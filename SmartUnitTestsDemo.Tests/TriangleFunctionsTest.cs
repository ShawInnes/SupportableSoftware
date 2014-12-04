// <copyright file="TriangleFunctionsTest.cs">Copyright ©  2014</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartUnitTestsDemo.Tests
{
    [TestClass]
    [PexClass(typeof(TriangleFunctions))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class TriangleFunctionsTest
    {
        [PexMethod]
        public TriangleType GetTriangleType(
            [PexAssumeUnderTest]TriangleFunctions target,
            int a,
            int b,
            int c
        )
        {
            TriangleType result = target.GetTriangleType(a, b, c);
            return result;
            // TODO: add assertions to method TriangleFunctionsTest.GetTriangleType(TriangleFunctions, Int32, Int32, Int32)
        }
    }
}
