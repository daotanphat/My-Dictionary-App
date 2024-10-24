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
using System.Windows.Shapes;

namespace MyDictionaryApp
{
	/// <summary>
	/// Interaction logic for WordTypeDetail.xaml
	/// </summary>
	public partial class WordTypeDetail : Window
	{
		public EventHandler WordTypeLoad;
		private IWordTypeRepository wordTypeRepository;
		public WordTypeDetail(string action, int wordTypeId)
		{
			InitializeComponent();
			wordTypeRepository = new WordTypeRepository();
			if (action.Equals("Add"))
			{
				lbTypeId.Visibility = Visibility.Collapsed;
				txtTypeId.Visibility = Visibility.Collapsed;
				btnUpdate.Visibility = Visibility.Collapsed;
			}
			else if (action.Equals("Detail"))
			{
				btnAdd.Visibility = Visibility.Collapsed;
				LoadWordType(wordTypeId);
			}
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				WordType wordType = new WordType
				{
					TypeName = txtTypeName.Text,
				};
				wordTypeRepository.addWordType(wordType);
				WordTypeLoad?.Invoke(this, EventArgs.Empty);
				MessageBox.Show($"Add {wordType.TypeName} success!", "Add Word Type");
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error Message");
			}
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void LoadWordType(int typeId)
		{
			WordType wordType = wordTypeRepository.getWordTypeById(typeId);
			txtTypeId.Text = wordType.Id.ToString();
			txtTypeName.Text = wordType.TypeName.ToString();
		}
	}
}
