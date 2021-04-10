using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorrectAPI.ObsceneWordProvider
{
	public interface IObsceneWordProvider
	{
		public Task<bool> IsObsceneWord(string word);
	}
}