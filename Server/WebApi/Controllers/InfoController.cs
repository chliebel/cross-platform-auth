using System.Web.Http;

namespace WebApi.Controllers
{
	[Authorize]
	public class InfoController : ApiController
	{
		[HttpGet]
		public IHttpActionResult User()
		{
			return Ok();
		}
	}
}