using System;
using Humanizer;

namespace PackageManagementDemo
{
    class Program
    {
        // https://github.com/MehdiK/Humanizer

        static void Main(string[] args)
        {
            int someNumber = 1234;
            Console.WriteLine(someNumber.ToWords());
            Console.WriteLine();

            DateTime now = DateTime.Now;
            DateTime nowish = now.AddSeconds(-4);

            Console.WriteLine(now.Humanize(false));
            Console.WriteLine(nowish.Humanize(false));
            Console.WriteLine();

            string elephant = "Elephant";
            Console.WriteLine(elephant.Pluralize());
            Console.WriteLine();

            string errorText = "errors";

            Console.WriteLine(errorText.ToQuantity(0));
            Console.WriteLine(errorText.ToQuantity(1));
            Console.WriteLine(errorText.ToQuantity(2));

            Console.WriteLine(errorText.ToQuantity(3, ShowQuantityAs.Words));


            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
