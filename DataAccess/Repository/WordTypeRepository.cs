using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public class WordTypeRepository : IWordTypeRepository
	{
		public void addWordType(WordType wordType)
		{
			WordTypeDAO.Instance.AddWordType(wordType);
		}

		public void deleteWordType(int wordTypeId)
		{
			WordTypeDAO.Instance.deleteWordType(wordTypeId);
		}

		public void deleteWordTypes(List<int> wordTypeIds)
		{
			WordTypeDAO.Instance.DeleteWordTypes(wordTypeIds);
		}

		public IEnumerable<WordType> getAlls()
		{
			return WordTypeDAO.Instance.GetWordTypes();
		}

		public WordType getWordTypeById(int wordTypeId)
		{
			return WordTypeDAO.Instance.getWordTypeById(wordTypeId);
		}

		public void updateWordType(int wordTypeId, WordType wordType)
		{
			WordTypeDAO.Instance.updateWordType(wordTypeId, wordType);
		}
	}
}
