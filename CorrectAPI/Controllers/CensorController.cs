using System.IO;
using System.Text;
using System.Threading.Tasks;
using CorrectAPI.ObsceneWordProvider;
using CorrectAPI.Requests;
using CorrectAPI.Responses;
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
		public async Task<CensorResponse> GetCensoredString([FromBody] CensorRequest censorRequest)
		{
			return await _obsceneStringChecker.GetCensoredString(censorRequest);
		}

	}
}