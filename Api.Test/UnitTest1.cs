using Api.Application.Services;
using Api.Controllers;

namespace Api.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetWeatherFromManchester_ShouldReturnTemperature()
        {
            var controller = new OrderController(new OrderService());

            var result = controller.GetAllProducts() as List<Product>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }
    }
}