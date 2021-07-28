using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculation;
using Xunit;
using Xunit.Abstractions;

namespace Calculation_Tests
{
    public class CalculatorFixture: IDisposable
    {
        public Calculator calc => new Calculator();

        public void Dispose()
        {
            //clean
        }
    }
    public class CalculatorTest : IClassFixture<CalculatorFixture>, IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly CalculatorFixture _calculatorFixture;
        private MemoryStream memory;

        public CalculatorTest(ITestOutputHelper testOutputHelper, CalculatorFixture calculatorFixture)
        {
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("Constructor");
            _calculatorFixture = calculatorFixture;
            memory = new MemoryStream();
        }

        [Fact]
        public void IsOdd_GivenOddValue_ReturnsTrue()
        {
            var calc = _calculatorFixture.calc;
            var result = calc.IsOdd(1);
            Assert.True(result);
        }

        [Fact]
        public void IsOdd_GivenEvenValue_ReturnsFalse()
        {
            var calc = _calculatorFixture.calc;
            var result = calc.IsOdd(2);
            Assert.False(result);
        }

        [Theory]
        [InlineData(1,true)]
        [InlineData(2, false)]
        [InlineData(200, false)]
        public void IsOdd_TestOddAndEven(int value, bool expected)
        {
            var calc = _calculatorFixture.calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestDataShared.IsOddOrEvenData),MemberType =typeof(TestDataShared))]
        public void IsOdd_TestOddAndEvenMember(int value, bool expected)
        {
            var calc = _calculatorFixture.calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestDataShared.IsOddOrEvenExternalData), MemberType = typeof(TestDataShared))]
        public void IsOdd_TestOddAndEvenExternal(int value, bool expected)
        {
            var calc = _calculatorFixture.calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }


        [Theory]
        [IsOddOrEvenData]
        public void IsOdd_TestOddAndEvenAttribute(int value, bool expected)
        {
            var calc = _calculatorFixture.calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {  
            var calc = _calculatorFixture.calc;
            var result = calc.Add(2, 1);
            Assert.Equal(3, result);
        }
        [Fact]
        public void AddDouble_GivenTwoDoubleValues_ReturnsDouble()
        {
            var calc = _calculatorFixture.calc;
            var result = calc.AddDouble(2.2, 3.5);
            Assert.Equal(5.7, result);
            var result2 = calc.AddDouble(2.25, 3.52);
            Assert.Equal(5.8, result2,1);
            Assert.Equal(5.77, result2, 2);
        }

        [Fact]
        [Trait("Category","Fibonnaci")]
        public void FiboDoesNotIncludeZero()
        {
            _testOutputHelper.WriteLine("FiboDoesNotIncludeZero");
            var calc = _calculatorFixture.calc;
            Assert.All(calc.FiboNumbers, x =>Assert.NotEqual(0,x));
        }

        [Fact]
        [Trait("Category", "Fibonnaci")]
        public void FiboIncludes13()
        {
            _testOutputHelper.WriteLine("FiboIncludes13");
            var calc = _calculatorFixture.calc;
            Assert.Contains(13, calc.FiboNumbers);
        }
        [Fact]
        [Trait("Category", "Fibonnaci")]
        public void FiboDoesNotInclude4()
        {
            _testOutputHelper.WriteLine("FiboDoesNotInclude4");
            var calc = _calculatorFixture.calc;
            Assert.DoesNotContain(4, calc.FiboNumbers);
        }
        [Fact]
        [Trait("Category", "Fibonnaci")]
        public void checkCollection()
        {
            _testOutputHelper.WriteLine("Check Fibonacci numbers. Test start at {0}",DateTime.Now);
            var calc = _calculatorFixture.calc;
            var expectedCollection = new List<int> {1, 1, 2, 3, 5, 8, 13};
            Assert.Equal(expectedCollection, calc.FiboNumbers);
        }

        public void Dispose()
        {
            memory.Close();
        }
    }
}
