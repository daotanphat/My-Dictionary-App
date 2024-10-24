using BusinessObject;
using Microsoft.EntityFrameworkCore;
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
						.FirstOrDefault(w =>
								w.TypeName.ToLower().Equals(wordType.TypeName.ToLower())
								);
					if (wordType1 != null)
					{
						throw new Exception($"{wordType.TypeName} is aleady exist!");
					}
					myDB.WordTypes.Add(wordType);
					myDB.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void deleteWordType(int wordTypeId)
		{
			try
			{
				using (var myDB = new MyDictionaryContext())
				{
					WordType wordType = myDB.WordTypes
						.FirstOrDefault(w => w.Id == wordTypeId);
					if (wordType == null)
					{
						throw new Exception($"{wordType.TypeName} is not exist!");
					}
					myDB.WordTypes.Remove(wordType);
					myDB.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void updateWordType(int wordTypeId, WordType wordType)
		{
			try
			{
				using (var myDB = new MyDictionaryContext())
				{
					WordType wordType1 = myDB.WordTypes
						.FirstOrDefault(w => w.Id == wordTypeId);
					if (wordType1 == null)
					{
						throw new Exception($"Word Type is not exist!");
					}

					WordType wordType2 = myDB.WordTypes
						.FirstOrDefault(w => w.TypeName.Equals(wordType.TypeName));
					if (wordType2 != null)
					{
						throw new Exception($"{wordType.TypeName} is already exist!");
					}

					myDB.Entry<WordType>(wordType).State = EntityState.Modified;
					myDB.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public WordType getWordTypeById(int wordTypeId)
		{
			try
			{
				WordType wordType;
				using (var myDB = new MyDictionaryContext())
				{
					wordType = myDB.WordTypes
						.FirstOrDefault(w => w.Id == wordTypeId);
					if (wordType == null)
					{
						throw new Exception($"Word Type is not exist!");
					}
					return wordType;
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
