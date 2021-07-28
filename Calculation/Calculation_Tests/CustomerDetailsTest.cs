using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Calculation;

namespace Calculation_Tests
{
    [Collection("Customer")]
    public class CustomerDetailsTest
    {
        private readonly CustomerFixture _customerFixture;

        public CustomerDetailsTest(CustomerFixture c)
        {
            _customerFixture = c;
        }

        [Fact]
        public void GetFullName_GivenFirstAndLastName_ReturnsFullName()
        {
            var customer = _customerFixture.cust;
            Assert.Equal("Miguel García", customer.GetFullName("Miguel", "García"));
        }
    }
}
