using System;
using System.Globalization;
using Humanizer;

namespace PackageManagementDemo
{
    class Program
    {
        // https://github.com/MehdiK/Humanizer

        static void Main(string[] args)
        {
            int someNumber = 1234;
            Console.WriteLine("ToWords");
            Console.WriteLine("-------");
            Console.WriteLine(someNumber.ToWords());
            Console.WriteLine();

            int ordinal = 1;
            Console.WriteLine("ToOrdinalWords");
            Console.WriteLine("--------------");
            Console.WriteLine(ordinal.ToOrdinalWords());
            Console.WriteLine((ordinal + 1).ToOrdinalWords());
            Console.WriteLine((ordinal + 9).ToOrdinalWords());
            Console.WriteLine();

            DateTime now = DateTime.Now;
            DateTime nowish = now.AddSeconds(-4);
            DateTime awhileback = now.AddSeconds(-84);
            DateTime agesago = now.AddMinutes(-150);
            Console.WriteLine("Humanize");
            Console.WriteLine("--------");
            Console.WriteLine(now.Humanize(false));
            Console.WriteLine(nowish.Humanize(false));
            Console.WriteLine(awhileback.Humanize(false));
            Console.WriteLine(agesago.Humanize(false));
            Console.WriteLine();

            string single = "Elephant";
            string plural = single.Pluralize();
            Console.WriteLine("Pluralize");
            Console.WriteLine("---------");
            Console.WriteLine(single);
            Console.WriteLine(plural);
            Console.WriteLine();

            string errorText = "errors";
            Console.WriteLine("ToQuantity");
            Console.WriteLine("----------");
            Console.WriteLine(errorText.ToQuantity(0));
            Console.WriteLine(errorText.ToQuantity(1));
            Console.WriteLine(errorText.ToQuantity(2));
            Console.WriteLine();

            Console.WriteLine("ToQuantity(As Words)");
            Console.WriteLine("--------------------");
            Console.WriteLine(errorText.ToQuantity(3, ShowQuantityAs.Words));
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
