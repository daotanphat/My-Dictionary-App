using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public class WordRepository : IWordRepository
	{
		public void AddWord(Dictionary word)
		{
			WordDAO.Instance.AddWord(word);
		}

		public IEnumerable<Dictionary> GetWords(bool approved)
		{
			return WordDAO.Instance.GetWord(approved);
		}
	}
}
