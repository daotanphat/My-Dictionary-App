using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public interface IWordTypeRepository
	{
		IEnumerable<WordType> getAlls();
		WordType getWordTypeById(int wordTypeId);
		void addWordType(WordType wordType);
		void deleteWordType(int wordTypeId);
		void deleteWordTypes(List<int> wordTypeIds);
		void updateWordType(int wordTypeId, WordType wordType);
	}
}
