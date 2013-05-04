using System;
using System.Collections.Generic;
using System.Linq;
using TestingWebApi.Controllers;
using Xunit;

namespace Tests
{
    public class ValuesControllerTests
    {
		[Fact]
		public void Get_AnyValue_ResultIsValue()
		{
			var sut = new ValuesController();

			string result = sut.Get(5);

			Assert.Equal("value", result);
		}
		[Fact]
		public void Get_AnyValue_StatusCodeOK()
		{
			var sut = new ValuesController();

			string result = sut.Get(5);

			//Assert.Equal(HttpStatusCode.OK, 
		}
    }
}
