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

		public IEnumerable<WordType> getAlls()
		{
			return WordTypeDAO.Instance.GetWordTypes();
		}
	}
}
