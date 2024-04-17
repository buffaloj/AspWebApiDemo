using BufTools.AspNet.EndpointReflection;
using BufTools.AspNet.TestFramework;
using BufTools.ObjectCreation.FromXmlComments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApi.ArchitectureTests
{
    [TestClass]
    public class ArchitectureTests
    {
        private readonly Browser<Program> _browser;
        private readonly ObjectMother _mother;

        public ArchitectureTests()
        {
            _mother = new ObjectMother();
            _mother.IgnorePropertiesWithAttribute<JsonIgnoreAttribute>();

            _browser = new Browser<Program>();
        }

        [TestMethod]
        public async Task AllEndpoints_WithXmlExampleValues_Returns200Ok()
        {
            var endpoints = typeof(Program).Assembly.GetEndpoints();
            var tasks = endpoints.Select(e => CallEndpointAsync(e));
            var results = await Task.WhenAll(tasks);

            Assert.IsFalse(results.Any(r => r.Value < HttpStatusCode.OK || r.Value >= HttpStatusCode.Ambiguous));
        }

        private async Task<KeyValuePair<string, HttpStatusCode>> CallEndpointAsync(HttpEndpoint endpoint, CancellationToken cancellationToken = default(CancellationToken))
        {               
            var payload = (endpoint.BodyPayloadType != null ) ? _mother.Birth(endpoint.BodyPayloadType) : null;

            var request = _browser.CreateRequest(endpoint.ExampleRoute);
            if (payload != null)
                request = request.WithJsonContent(JsonSerializer.Serialize(payload));

            HttpResponseMessage response = null;
            switch (endpoint.Verb)
            {
                case HttpEndpoint.Verbs.Get:
                    response = await request.GetAsync(cancellationToken);
                    break;
                case HttpEndpoint.Verbs.Post:
                    response = await request.PostAsync(cancellationToken);
                    break;
                case HttpEndpoint.Verbs.Put:
                    response = await request.PutAsync(cancellationToken);
                    break;
                case HttpEndpoint.Verbs.Delete:
                    response = await request.DeleteAsync(cancellationToken);
                    break;
            }

            return new KeyValuePair<string, HttpStatusCode>(endpoint.ExampleRoute, response.StatusCode);
        }
    }
}