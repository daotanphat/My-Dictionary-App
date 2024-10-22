using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class WordDAO
	{
		private static WordDAO instance = null;
		private static readonly object instanceLock = new object();

		private WordDAO() { }
		public static WordDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new WordDAO();
					}
					return instance;
				}
			}
		}

		public IEnumerable<Dictionary> GetWord(bool approved)
		{
			List<Dictionary> dictionaries = new List<Dictionary>();
			try
			{
				using (var myDB = new MyDictionaryContext())
				{
					dictionaries = myDB.Dictionaries.ToList();
					if (approved)
					{
						dictionaries = dictionaries.Where(d => d.IsApproved).ToList();
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return dictionaries;
		}

		public void AddWord(Dictionary word)
		{
			try
			{
				using (var myDB = new MyDictionaryContext())
				{
					Dictionary word1 = myDB.Dictionaries
						.Include(d => d.WordTypeNavigation)
						.FirstOrDefault(d => d.Word.Equals(word.Word) && d.WordType == word.WordType);
					if (word1 != null)
					{
						throw new Exception($"{word.Word} - {word1.WordTypeNavigation.TypeName} is already exist!");
					}
					else
					{
						myDB.Dictionaries.Add(word);
						myDB.SaveChanges();
					}

				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
