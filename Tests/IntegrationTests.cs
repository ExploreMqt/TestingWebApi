using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xunit;
using Peiro;
using TestingWebApi;
using System.Net.Http.Formatting;

namespace Tests
{
	public class IntegrationTests : IDisposable
	{
		public IntegrationTests()
		{
			var config = new HttpConfiguration();
			WebApiConfig.Register(config);
			config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
			config.MessageHandlers.Add(new PassThroughMessageHandler());
			inMemoryServer = new HttpServer(config);

			inMemoryServer = InMemoryServer.Create(WebApiConfig.Register);
		}
		[Fact]
		public void Post_Manual_Created()
		{
			var content = new Widget { Id = 1, SerialNumber = "xyz-001" };
			var client = new HttpClient(inMemoryServer);
			var request = new HttpRequestMessage(HttpMethod.Post, "http://www.sample.com/api/widget");
			request.Content = new ObjectContent<Widget>(content, new JsonMediaTypeFormatter());

			HttpResponseMessage response = client.SendAsync(request).Result;

			Assert.Equal(HttpStatusCode.Created, response.StatusCode);
		}
		[Fact]
		public void Post_Library_Created()
		{
			HttpResponseMessage response = inMemoryServer.Post(
				"http://www.sample.com/api/",
				"widget/",
				new Widget { Id = 1, SerialNumber = "xyz-001" });

			Assert.Equal(HttpStatusCode.Created, response.StatusCode);
		}
		public void Dispose()
		{
			if (inMemoryServer != null)
			{
				inMemoryServer.Dispose();
				inMemoryServer = null;
			}
		}
		private HttpServer inMemoryServer;
	}
}
