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
			var subject = ClaimsPrincipal.Current.FindFirst("sub");
			var name = ClaimsPrincipal.Current.FindFirst("name");
			var profile = GetProfileOrDefault(subject, name);

			if (profile == null)
			{
				return NotFound();
			}

			return Ok(profile);
		}

		private static Profile GetProfileOrDefault(Claim subject, Claim name)
		{
			if (subject != null && name != null && subject.Value == "alice")
			{
				return new Profile
				{
					FullName = name.Value,
					Age = 24,
					ImageUrl = "http://api.randomuser.me/portraits/women/39.jpg"
				};
			}

			return null;
		}
	}
}