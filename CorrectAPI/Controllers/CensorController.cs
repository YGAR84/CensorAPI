using CorrectAPI.ObsceneWordProvider;
using CorrectAPI.StringChecker;
using Microsoft.AspNetCore.Mvc;

namespace CorrectAPI.Controllers
{
	[ApiController]
	public class CensorController : ControllerBase
	{

		private readonly ObsceneStringChecker _obsceneStringChecker;

		public CensorController(ObsceneStringChecker obsceneStringChecker)
		{
			_obsceneStringChecker = obsceneStringChecker;
		}

		[HttpPost]
		[Route("censor")]
		public string CensorString([FromBody] string input)
		{
			return _obsceneStringChecker.GetCensoredString(input);
		}

	}
}