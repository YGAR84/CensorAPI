using System;
using System.Linq;
using CorrectAPI.ObsceneWordProvider;

namespace CorrectAPI.StringChecker
{
	public class ObsceneStringChecker
	{
		private readonly IObsceneWordProvider _obsceneWordProvider;

		public ObsceneStringChecker(IObsceneWordProvider obsceneWordProvider)
		{
			_obsceneWordProvider = obsceneWordProvider;
		}

		public string GetCensoredString(string input)
		{
			var words = input.Split(' ');
			var wasObsceneWord = false;
			for (var i = 0; i < words.Length; ++i)
			{
				if (_obsceneWordProvider.IsObsceneWord(words[i]))
				{
					words[i] = GetCensoredWord(words[i]);
					wasObsceneWord = true;
				}
			}

			return !wasObsceneWord ? input : string.Join(' ', words);
		}


		private string GetCensoredWord(string word)
		{
			return new string('*', word.Length);
		}
	}
}