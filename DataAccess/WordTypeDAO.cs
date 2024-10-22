using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class WordTypeDAO
	{
		private static WordTypeDAO instance = null;
		private static readonly object instanceLock = new object();

		private WordTypeDAO() { }
		public static WordTypeDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new WordTypeDAO();
					}
					return instance;
				}
			}
		}

		public IEnumerable<WordType> GetWordTypes()
		{
			List<WordType> wordTypes = new List<WordType>();
			try
			{
				using (var myDB = new MyDictionaryContext())
				{
					wordTypes = myDB.WordTypes.ToList();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return wordTypes;
		}

		public void AddWordType(WordType wordType)
		{
			try
			{
				WordType wordType1;
				using (var myDB = new MyDictionaryContext())
				{
					wordType1 = myDB.WordTypes
						.FirstOrDefault(w => w.TypeName.Equals(wordType.TypeName));
					if (wordType1 != null)
					{
						throw new Exception($"{wordType.TypeName} is aleady exist!");
					}
					myDB.WordTypes.Add(wordType1);
					myDB.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
