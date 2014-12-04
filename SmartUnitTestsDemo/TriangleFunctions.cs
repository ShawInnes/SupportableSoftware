using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartUnitTestsDemo
{
    public class TriangleFunctions
    {
        public TriangleType GetTriangleType(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return TriangleType.Illegal;
            }

            if (!(a + b > c && a + c > b && b + c > a))
            {
                return TriangleType.Illegal;
            }

            if (a == b && b == c)
            {
                return TriangleType.Equilateral;
            }

            if (a == b || b == c || a == c)
            {
                return TriangleType.Isosceles;
            }

            return TriangleType.Scalene;
        }
    }
}
