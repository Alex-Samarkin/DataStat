using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataColumnLibrary;

namespace DataStat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region SBPlus
            StringBuilderPlus sbp = new StringBuilderPlus();
            sbp.Width = 100;
            sbp.AddPattern();
            foreach (int i in Enumerable.Range(0,sbp.PatternList.Count))
            {
                Console.WriteLine(sbp.Hr(i));
            }

            Console.WriteLine(sbp.PrintAtPos(50,10.2));
            Console.WriteLine(sbp.LJust(5));
            Console.WriteLine(sbp.RJust(5));
            Console.WriteLine(sbp.CenterJust(11.52 / 17.0));

            Console.WriteLine(sbp.PrintAtPos(50,"=> ", 10.2));
            Console.WriteLine(sbp.LJust(5," --> "));
            Console.WriteLine(sbp.RJust(5,"Это по правой стороне "));
            Console.WriteLine(sbp.CenterJust(11.52 / 17.0, "Центр "));

            Console.WriteLine(sbp.Tab(new List<double>(){0,1.0/3,2,3,15.0/17}));

            Console.WriteLine(sbp.Positive(50));
            Console.WriteLine(sbp.Positive(100));
            Console.WriteLine(sbp.Positive(5));
            Console.WriteLine(sbp.Positive(25));
            Console.WriteLine(sbp.Positive(0));

            Console.WriteLine(sbp.Hr());
            for (int i = -75; i < 75; i++)
            {
                Console.WriteLine(sbp.FromTo(i));
            }


            #endregion

            #region Head
            Head h = new Head();
            Console.WriteLine(h);
            h.Description = "Простой заголовок";
            Console.WriteLine(h.ToFormatString());
            #endregion

            Console.ReadLine();
        }
    }
}
