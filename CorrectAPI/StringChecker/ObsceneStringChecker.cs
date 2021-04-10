using System;
using System.Linq;
using System.Threading.Tasks;
using CorrectAPI.ObsceneWordProvider;
using CorrectAPI.Requests;
using CorrectAPI.Responses;

namespace CorrectAPI.StringChecker
{
	public class ObsceneStringChecker
	{
		private readonly IObsceneWordProvider _obsceneWordProvider;

		public ObsceneStringChecker(IObsceneWordProvider obsceneWordProvider)
		{
			_obsceneWordProvider = obsceneWordProvider;
		}

		public async Task<CensorResponse> GetCensoredString(CensorRequest censorRequest)
		{
			if (censorRequest.Content is null || censorRequest.Content == string.Empty)
			{
				return new CensorResponse();
			}
			
			if (censorRequest.CensorCharacter is null || censorRequest.CensorCharacter == string.Empty)
			{
				censorRequest.CensorCharacter = "*";
			} 
			else if (await _obsceneWordProvider.IsObsceneWord(censorRequest.CensorCharacter))
			{
				censorRequest.CensorCharacter = "*";
			}

			var censoredString = await _obsceneWordProvider.GetCensorString(censorRequest.Content, censorRequest.CensorCharacter);

			return new CensorResponse {CensoredContent = censoredString};
		}

	}
}