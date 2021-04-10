using System.IO;
using System.Text;
using System.Threading.Tasks;
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
		public async Task<string> CensorString()
		{
			using StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
			var body = await reader.ReadToEndAsync();
			return _obsceneStringChecker.GetCensoredString(body);
			//			return _obsceneStringChecker.GetCensoredString(input);
		}

	}
}