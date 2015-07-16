using System.Web.Http;
using WebApi.Data;

namespace WebApi.Controllers
{
	[Authorize]
	public class ProfileController : ApiController
	{
		[HttpGet]
		public IHttpActionResult GetProfile()
		{
			return Ok(new Profile
			{
				FullName = "TBD",
				Age = 19,
				ImageUrl = "http://api.randomuser.me/portraits/women/39.jpg"
			});
		}
	}
}