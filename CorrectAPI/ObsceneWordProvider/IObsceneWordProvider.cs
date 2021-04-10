using System.Collections.Generic;

namespace CorrectAPI.ObsceneWordProvider
{
	public interface IObsceneWordProvider
	{
		public bool IsObsceneWord(string word);
	}
}