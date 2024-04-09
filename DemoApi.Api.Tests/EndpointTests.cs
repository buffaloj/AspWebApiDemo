using BufTools.AspNet.TestFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoApi.Api.Tests
{
    [TestClass]
    public class EndpointTests
    {
        private readonly Browser<Program> _browser;

        public EndpointTests() 
        {
            _browser = new Browser<Program>(c =>
            {
            });
        }

        [TestMethod]
        public async Task ExampleGet_WithValidRequest_ReturnsResponse()
        {
            // This is just an example of a test
            var response = await _browser.CreateRequest("/api/v1/example").GetAsync();

            Assert.IsNotNull(response);
        }
    }
}