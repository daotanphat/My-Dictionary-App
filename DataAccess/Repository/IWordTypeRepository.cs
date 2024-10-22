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
		void addWordType(WordType wordType);
	}
}
