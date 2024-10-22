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
					dictionaries = myDB.Dictionaries
						.Include(w => w.WordTypeNavigation)
						.ToList();
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

		public IEnumerable<Dictionary> GetWordsByFilter(bool approved, string search, string type)
		{
			List<Dictionary> dictionaries = new List<Dictionary>();
			try
			{
				using (var myDB = new MyDictionaryContext())
				{
					if (type.Equals("All"))
					{
						dictionaries = myDB.Dictionaries
							.Include(w => w.WordTypeNavigation)
							.Where(w => (w.Word.ToLower().Contains(search.ToLower()) || w.Vietnamese.ToLower().Contains(search.ToLower()))
										&& w.IsApproved == approved)
							.ToList();
					}
					else
					{
						dictionaries = myDB.Dictionaries
							.Include(w => w.WordTypeNavigation)
							.Where(w => (w.Word.ToLower().Contains(search.ToLower()) || w.Vietnamese.ToLower().Contains(search.ToLower()))
										&& w.WordTypeNavigation.TypeName.ToLower().Contains(type.ToLower())
										&& w.IsApproved == approved)
							.ToList();
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return dictionaries;
		}

		public Dictionary GetWordById(int wordId)
		{
			try
			{
				using (var myDB = new MyDictionaryContext())
				{
					Dictionary dictionary = myDB.Dictionaries
						.Include(d => d.WordTypeNavigation)
						.FirstOrDefault(d => d.Id == wordId);
					if (dictionary == null)
					{
						throw new Exception($"{dictionary} is not exist!");
					}
					return dictionary;
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
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
					myDB.Dictionaries.Add(word);
					myDB.SaveChanges();
					EditHistory editHistory = new EditHistory
					{
						WordId = word.Id,
						OldWord = word.Word,
						OldVietnamese = word.Vietnamese,
						NewWord = word.Word,
						NewVietnamese = word.Vietnamese,
						EditBy = word.CreateBy
					};
					myDB.EditHistories.Add(editHistory);
					myDB.SaveChanges();

				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void UpdateWord(int wordId, Dictionary word)
		{
			try
			{
				using (var myDB = new MyDictionaryContext())
				{
					Dictionary dictionary = myDB.Dictionaries
						.Include(d => d.WordTypeNavigation)
						.FirstOrDefault(d => d.Id == wordId);
					if (dictionary == null)
					{
						throw new Exception($"{dictionary} is not exist!");
					}

					Dictionary word1 = myDB.Dictionaries
						.Include(d => d.WordTypeNavigation)
						.FirstOrDefault(d => d.Word.Equals(word.Word) && d.WordType == word.WordType);
					if (word1 != null)
					{
						throw new Exception($"{word.Word} - {word1.WordTypeNavigation.TypeName} is already exist!");
					}

					myDB.Entry<Dictionary>(word).State = EntityState.Modified;
					myDB.SaveChanges();

					EditHistory editHistory = new EditHistory
					{
						WordId = wordId,
						OldWord = dictionary.Word,
						OldVietnamese = dictionary.Vietnamese,
						NewWord = word.Word,
						NewVietnamese = dictionary.Vietnamese,
						EditBy = word.CreateBy
					};
					myDB.EditHistories.Add(editHistory);
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
