using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace TestingWebApi.Controllers
{
	public class GadgetController : ApiController
	{
		public HttpResponseMessage Get(int id)
		{
			return Request.CreateResponse(HttpStatusCode.OK, "value");
		}
	}
}
