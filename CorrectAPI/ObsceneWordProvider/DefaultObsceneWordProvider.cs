using System.Collections.Generic;
using System.Linq;
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
			new Regex(@"^.*shit.*$", RegexOptions.IgnoreCase),
			new Regex(@"^.*bitch.*$", RegexOptions.IgnoreCase),
			new Regex(@"^.*ass.*$", RegexOptions.IgnoreCase),
		};

		public Task<bool> IsObsceneWord(string word)
		{
			return Task.FromResult(IsObscene(word));
		}

		public Task<string> GetCensorString(string text, string censorCharacter)
		{
			var words = text.Split(' ');
			var wasObsceneWord = false;
			for (var i = 0; i < words.Length; ++i)
			{
				if (!IsObscene(words[i])) continue;

				words[i] = GetCensoredWord(words[i], censorCharacter);
				wasObsceneWord = true;
			}

			return !wasObsceneWord ? Task.FromResult(text) : Task.FromResult(string.Join(' ', words));
		}

		private string GetCensoredWord(string word, string censorCharacter)
		{
			return string.Concat(Enumerable.Repeat(censorCharacter, word.Length));
		}

		private bool IsObscene(string word)
		{
			foreach (var pattern in _obsceneWordRegexList)
			{
				var match = pattern.Match(word);
				if (match.Success)
				{
					return true;
				}
			}

			return false;
		}
	}
}