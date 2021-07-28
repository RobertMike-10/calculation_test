using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
namespace Calculation_Tests
{
    public class IsOddOrEvenDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {           
                yield return new Object[] { 1, true };
                yield return new Object[] { 2, false };
                yield return new Object[] { 3, true };
        
        }
    }
}
