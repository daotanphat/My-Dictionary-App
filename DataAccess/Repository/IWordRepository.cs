using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public interface IWordRepository
	{
		IEnumerable<Dictionary> GetWords(bool approved);
		void AddWord(Dictionary word);
		Dictionary GetWordById(int wordId);
		void UpdateWord(int wordId, Dictionary word);
		IEnumerable<Dictionary> GetWordsByFilter(bool approved, string search, string type);
		bool ApprovedWord(int wordId, bool approved);
		void DeleteWord(List<int> wordIds);
	}
}
