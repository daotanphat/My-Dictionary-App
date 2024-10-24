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

		public bool ApprovedWord(int wordId, bool approved)
		{
			return WordDAO.Instance.ApprovedWord(wordId, approved);
		}

		public void DeleteWord(List<int> wordIds)
		{
			WordDAO.Instance.DeleteWords(wordIds);
		}

		public Dictionary GetWordById(int wordId)
		{
			return WordDAO.Instance.GetWordById(wordId);
		}

		public IEnumerable<Dictionary> GetWords(bool approved)
		{
			return WordDAO.Instance.GetWord(approved);
		}

		public IEnumerable<Dictionary> GetWordsByFilter(bool approved, string search, string type)
		{
			return WordDAO.Instance.GetWordsByFilter(approved, search, type);
		}

		public void UpdateWord(int wordId, Dictionary word)
		{
			WordDAO.Instance.UpdateWord(wordId, word);
		}
	}
}
