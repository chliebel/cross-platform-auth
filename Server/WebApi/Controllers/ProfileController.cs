using System.Security.Claims;
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
			var subject = ClaimsPrincipal.Current.FindFirst("sub").Value;
			var profile = GetProfileOrDefault(subject);

			if (profile == null)
			{
				return NotFound();
			}

			return Ok(profile);
		}

		private static Profile GetProfileOrDefault(string subject)
		{
			if (subject == "alice")
			{
				return new Profile
				{
					FullName = "Alice Secret",
					Age = 24,
					ImageUrl = "http://api.randomuser.me/portraits/women/39.jpg"
				};
			}

			return null;
		}
	}
}