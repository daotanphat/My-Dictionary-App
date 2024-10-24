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
	/// Interaction logic for WordTypeControl.xaml
	/// </summary>
	public partial class WordTypeControl : UserControl
	{
		private IWordTypeRepository wordTypeRepository;
		public WordTypeControl()
		{
			InitializeComponent();
			wordTypeRepository = new WordTypeRepository();
			LoadWordType();
		}

		private void btnAddType_Click(object sender, RoutedEventArgs e)
		{
			WordTypeDetail wordTypeDetail = new WordTypeDetail("Add", 0);
			wordTypeDetail.WordTypeLoad += WordTypeDetail_WordTypeLoad;
			wordTypeDetail.ShowDialog();
		}

		private void WordTypeDetail_WordTypeLoad(object? sender, EventArgs e)
		{
			LoadWordType();
		}

		private void lvWordType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (lvWordType.SelectedItem is WordType selectedType)
			{
				WordTypeDetail wordTypeDetail = new WordTypeDetail("Detail", selectedType.Id);
				wordTypeDetail.WordTypeLoad += WordTypeDetail_WordTypeLoad;
				wordTypeDetail.ShowDialog();
				lvWordType.SelectedItem = null;
			}
		}

		public void LoadWordType()
		{
			try
			{
				List<WordType> wordTypes = (List<WordType>)wordTypeRepository.getAlls();
				lvWordType.ItemsSource = wordTypes;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Load Word Type");
			}
		}

		private void btnDeleteType_Click(object sender, RoutedEventArgs e)
		{
			try
			{

				if (lvWordType.SelectedItem is WordType selectedType)
				{
					wordTypeRepository.deleteWordType(selectedType.Id);
					LoadWordType();
					MessageBox.Show("Delete word type successfully!");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Delete word");
			}
		}
	}
}
