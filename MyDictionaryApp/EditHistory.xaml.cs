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
using System.Windows.Shapes;

namespace MyDictionaryApp
{
	/// <summary>
	/// Interaction logic for EditHistory.xaml
	/// </summary>
	public partial class EditHistory : Window
	{
		private IWordRepository wordRepository;
		private int wordId;
		public EditHistory(int wordId)
		{
			InitializeComponent();
			wordRepository = new WordRepository();
			this.wordId = wordId;
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				lvHistory.ItemsSource = wordRepository.GetEditHistory(wordId);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Edit Histories");
			}
		}
	}
}
