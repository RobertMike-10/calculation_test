using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation_Tests
{
    public static class TestDataShared
    {

        private const String pathFile = "C:\\Users\\miguel.garcia\\source\\repos\\Calculation\\Calculation_Tests\\";
        public static IEnumerable<object[]> IsOddOrEvenData
        {
            get
            {
                yield return new Object[] { 1, true };
                yield return new Object[] { 2, false };
                yield return new Object[] { 3, true };
            }
        }

        public static IEnumerable<object[]> IsOddOrEvenExternalData
        {
            get
            {
                var allLines = System.IO.File.ReadAllLines(pathFile +"IsOddOrEvenTestData.txt");
                return allLines.Select(x =>
                {
                    var lineSplit = x.Split(",");
                    return new Object[] { int.Parse(lineSplit[0]), bool.Parse(lineSplit[1]) };
                });
            }
        }
    }
}
