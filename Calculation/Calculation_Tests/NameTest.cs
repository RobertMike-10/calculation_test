using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculation;
using Xunit;
namespace Calculation_Tests
{
    public class NameTest
    {
        [Fact]
        public void MakeFullNameTest()
        {
            var names = new Names();
            var result = names.MakeFullName("Miguel", "García");
            Assert.Equal("Miguel García", result);
            var result2 = names.MakeFullName("miguel", "García");
            Assert.Equal("Miguel García", result2, ignoreCase: true);
            Assert.Contains("Miguel", result);
            Assert.Contains("miguel", result, StringComparison.InvariantCultureIgnoreCase);
            Assert.StartsWith("Miguel", result);
            Assert.EndsWith("García", result);
            Assert.EndsWith("garcía", result, StringComparison.InvariantCultureIgnoreCase);
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", result);
        }

        [Fact]
        public void NickName_MustBeNull()
        {
         var names= new Names();
         Assert.Null(names.NickName);
         names.NickName = "The Beauty";
         Assert.NotNull(names.NickName);
        }

        [Fact]
        public void MakeFullName_AlwaysReturnValue()
        {
            var names = new Names();
            var result = names.MakeFullName("Miguel", "García");
            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result));
            Assert.False(string.IsNullOrEmpty(result));
        }
    }
}
