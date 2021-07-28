using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Calculation;
using Xunit;

namespace Calculation_Tests
{
    [Collection("Customer")]
    public class CustomerTest
    {
        private readonly CustomerFixture _customerFixture;

        public CustomerTest(CustomerFixture c)
        {
            _customerFixture = c;
        }
        [Fact]
        public void CheckNameNotEmpty()
        {
            var customer = _customerFixture.cust;
            Assert.NotNull(customer.Name);
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        [Fact]
        public void CheckLegitimateAge()
        {
            var customer = _customerFixture.cust;
            Assert.InRange(customer.Age,25,40);
        }

        [Fact]
        public void GetOrdersByNameNotNull()
        {
            var customer = _customerFixture.cust;
            Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(null));
            var exception = Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(null));
            Assert.Equal("Error argument name is not provided",exception.Message);
        }

        [Fact]
        public void LoyalCustomerForOrdersG100()
        {
            var customer = CustomerFactory.CreateCustomerInstance(105);
            Assert.IsType(typeof(LoyalCustomer), customer);
            Assert.IsType<LoyalCustomer>(customer);
            var loyalCustomer = Assert.IsType<LoyalCustomer>(customer);
            Assert.Equal(10, loyalCustomer.Discount);
        }
    }
}
