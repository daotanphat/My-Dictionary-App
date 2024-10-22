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
		}

		private void btnFilter_Click(object sender, RoutedEventArgs e)
		{

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
				cbType.ItemsSource = wordTypeRepository.getAlls().Select(w => w.TypeName);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Load Dictionary");
			}
		}

		private void btnAddWord_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
