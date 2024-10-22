using BusinessObject;
using DataAccess.Repository;
using System;
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
	/// Interaction logic for DictionaryControl.xaml
	/// </summary>
	public partial class DictionaryControl : UserControl
	{
		private IWordRepository wordRepository;
		private IWordTypeRepository wordTypeRepository;
		private bool isAdmin;
		public DictionaryControl(bool isAdmin)
		{
			InitializeComponent();
			wordRepository = new WordRepository();
			wordTypeRepository = new WordTypeRepository();
			this.isAdmin = isAdmin;
			LoadDictionary();
			LoadWordTypes();
		}

		private void btnFilter_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(txtSearch.Text) || cbType.SelectedIndex != -1)
			{
				string search = txtSearch.Text;
				string wordType = cbType.SelectedValue.ToString();
				var dictionaries = wordRepository.GetWordsByFilter(true, search, wordType);
				lvDictionary.ItemsSource = dictionaries;
			}
		}

		public void LoadDictionary()
		{
			try
			{
				if (!isAdmin)
				{
					lvDictionary.ItemsSource = wordRepository.GetWords(true);
				}
				else
				{
					lvDictionary.ItemsSource = wordRepository.GetWords(false);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Load Dictionary");
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

		private void btnAddWord_Click(object sender, RoutedEventArgs e)
		{
			WordDetail wordDetail = new WordDetail("Add", 0);
			wordDetail.WordLoad += WordDetail_WordLoad1;
			wordDetail.Show();
		}

		private void WordDetail_WordLoad1(object? sender, EventArgs e)
		{
			LoadDictionary();
		}

		private void btnDetail_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			int wordId = (int)button.CommandParameter;
			WordDetail wordDetail = new WordDetail("Detail", wordId);
			wordDetail.ShowDialog();
		}

		private void lvDictionary_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (lvDictionary.SelectedItem is Dictionary selectedWord)
			{
				WordDetail wordDetail = new WordDetail("Detail", selectedWord.Id);
				wordDetail.ShowDialog();
				lvDictionary.SelectedItem = null;
			}
		}
	}
}
