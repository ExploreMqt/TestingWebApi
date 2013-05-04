using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using TestingWebApi.Controllers;
using Xunit;
using Peiro;

namespace Tests
{
	public class GadgetControllerTests
	{
		[Fact]
		public void Get_AnyValue_StatusCodeOK()
		{
			var sut = new GadgetController();

			HttpResponseMessage result = sut.Get(5);

			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
		}
		#region Manual
		[Fact]
		public void Get_Manual_StatusCodeOK()
		{
			var sut = new GadgetController();
			var config = new HttpConfiguration();
			var request = new HttpRequestMessage(HttpMethod.Post, "http://www.sample.com/api/Widget");
			KeyValuePair<string, string>[] routes = new[] { new KeyValuePair<string, string>("DefaultApi", "{controller}/{id}") };
			IHttpRoute lastRoute = null;
			Array.ForEach(routes, r => lastRoute = config.Routes.MapHttpRoute(r.Key, r.Value));
			var routeData = new HttpRouteData(lastRoute, new HttpRouteValueDictionary { { "controller", "widget" } });
			sut.ControllerContext = new HttpControllerContext(config, routeData, request);
			sut.Request = sut.ControllerContext.Request;
			sut.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = sut.ControllerContext.Configuration;
			sut.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = sut.ControllerContext.RouteData;

			HttpResponseMessage result = sut.Get(5);

			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
		}
		#endregion
		#region Library
		[Fact]
		public void Get_Library_StatusCodeOK()
		{
			var sut = new GadgetController();
			sut.FakeRequest();

			HttpResponseMessage result = sut.Get(5);

			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
		}
		#endregion
	}
}
