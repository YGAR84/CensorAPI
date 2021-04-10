using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CorrectAPI.ObsceneWordProvider
{
	public class DefaultObsceneWordProvider : IObsceneWordProvider
	{
		private readonly IReadOnlyList<string> _obsceneWordRegexList = new List<string>
		{
			"*fuck*",
			"*nigg*",
			"*bitch*",
			"*ass*",
		};

		public bool IsObsceneWord(string word)
		{
			foreach (var pattern in _obsceneWordRegexList)
			{
				var match = Regex.Match(word, pattern);
				if (match.Success)
				{
					return true;
				}
			}

			return false;
		}
	}
}