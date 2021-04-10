using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CorrectAPI.ObsceneWordProvider
{
	public class DefaultObsceneWordProvider : IObsceneWordProvider
	{
		private readonly IReadOnlyList<Regex> _obsceneWordRegexList = new List<Regex>
		{
			new Regex(@"^.*fuck.*$", RegexOptions.IgnoreCase),
			new Regex(@"^.*nigg.*$", RegexOptions.IgnoreCase),
			new Regex(@"^.*fuck.*$", RegexOptions.IgnoreCase),
			new Regex(@"^.*bitch.*$", RegexOptions.IgnoreCase),
			new Regex(@"^.*ass.*$", RegexOptions.IgnoreCase),
		};

		public Task<bool> IsObsceneWord(string word)
		{
			foreach (var pattern in _obsceneWordRegexList)
			{
				var match = pattern.Match(word);//  Regex.Match(word, pattern);
				if (match.Success)
				{
					return Task.FromResult(true);
				}
			}

			return Task.FromResult(false);
		}
	}
}