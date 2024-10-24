using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyDictionaryApp
{
	/// <summary>
	/// Interaction logic for ApprovedWord.xaml
	/// </summary>
	public partial class ApprovedWord : UserControl
	{
		private IWordRepository wordRepository;
		private WordTypeRepository wordTypeRepository;
		public ApprovedWord()
		{
			InitializeComponent();
			wordRepository = new WordRepository();
			wordTypeRepository = new WordTypeRepository();
			LoadApprovedWords();
			LoadWordTypes();
		}

		private void btnDeleteWord_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var selectedItems = lvApprovedWord.SelectedItems;
				if (selectedItems.Count > 0)
				{
					List<int> wordIds = new List<int>();
					foreach (var item in selectedItems)
					{
						var selectedItem = item as Dictionary;
						if (selectedItem != null)
						{
							wordIds.Add(selectedItem.Id);
						}
					}
					wordRepository.DeleteWord(wordIds);
					LoadApprovedWords();
					MessageBox.Show("Reject word successfully!");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Approved word");
			}
		}

		private void lvApprovedWord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (lvApprovedWord.SelectedItem is Dictionary selectedWord)
			{
				WordDetail wordDetail = new WordDetail("ApprovedDetail", selectedWord.Id, true);
				wordDetail.ShowDialog();
				lvApprovedWord.SelectedItem = null;
			}

		}

		private void btnApproved_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Button button = sender as Button;
				int wordId = (int)button.CommandParameter;
				wordRepository.ApprovedWord(wordId, true);
				MessageBox.Show($"You have already approved add new word!");
				LoadApprovedWords();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Approved Word");
			}
		}

		private void LoadApprovedWords()
		{
			try
			{
				lvApprovedWord.ItemsSource = wordRepository.GetWords(false);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Load Approved Word");
			}
		}

		public void LoadWordTypes()
		{
			try
			{
				List<String> wordTypes = new List<string> { "All" };
				var wordTypesDB = wordTypeRepository.getAlls().ToList();
				wordTypes.AddRange(wordTypesDB.Select(w => w.TypeName).ToList());
				cbType.ItemsSource = wordTypes;
				cbType.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Load Word Types");
			}
		}

		private void btnFilter_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(txtSearch.Text) || cbType.SelectedIndex != -1)
			{
				string search = txtSearch.Text;
				string wordType = cbType.SelectedValue.ToString();
				var dictionaries = wordRepository.GetWordsByFilter(false, search, wordType);
				lvApprovedWord.ItemsSource = dictionaries;
			}
		}
	}
}
