using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using TestingWebApi.Models;

namespace TestingWebApi.Controllers
{
	public class WidgetController : ApiController
	{
		public HttpResponseMessage Get(int id)
		{
			if (id <= 0)
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Widget exist with an id of zero");
			return Request.CreateResponse(HttpStatusCode.OK, new Widget { Id = id, SerialNumber = "abc-123" });
		}
		public HttpResponseMessage Post(Widget value)
		{
			return Request.CreateResponse(HttpStatusCode.Created, value);
		}
	}
}
