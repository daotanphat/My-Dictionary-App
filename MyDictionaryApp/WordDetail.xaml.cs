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
	/// Interaction logic for WordDetail.xaml
	/// </summary>
	public partial class WordDetail : Window
	{
		public event EventHandler WordLoad;
		private IWordRepository wordRepository;
		private IWordTypeRepository wordTypeRepository;
		private bool isAdmin;
		public WordDetail(string action, int wordId, bool isAdmin)
		{
			InitializeComponent();
			wordRepository = new WordRepository();
			wordTypeRepository = new WordTypeRepository();
			this.isAdmin = isAdmin;
			cboWordType.ItemsSource = wordTypeRepository.getAlls();
			cboWordType.DisplayMemberPath = "TypeName";
			cboWordType.SelectedValuePath = "Id";
			if (isAdmin)
			{
				btnUpdate.Visibility = Visibility.Collapsed;
			}
			if (action.Equals("Detail"))
			{
				LoadWord(wordId);
				btnAdd.Visibility = Visibility.Collapsed;
			}
			else if (action.Equals("Add"))
			{
				lbWordId.Visibility = Visibility.Collapsed;
				txtWordId.Visibility = Visibility.Collapsed;
				btnUpdate.Visibility = Visibility.Collapsed;
			}
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (checkValidWord())
				{
					bool isApproved = isAdmin;
					int createBy = Convert.ToInt32(Application.Current.Resources["userId"]);
					Dictionary word = new Dictionary
					{
						Word = txtWord.Text,
						Vietnamese = txtVietnamese.Text,
						WordType = (int)cboWordType.SelectedValue,
						Meaning = txtDefinition.Text,
						IsApproved = isApproved,
						CreateBy = createBy
					};
					wordRepository.AddWord(word);
					if (isAdmin)
					{
						WordLoad?.Invoke(this, EventArgs.Empty);
						MessageBox.Show($"Add word {word.Word} successfully!", "Add Word");
					}
					else
					{
						MessageBox.Show($"Your request to add a new word '{txtWord.Text}' has been sent to the admin.", "Suggest Word");
					}

					this.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error Message");
			}

		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void LoadWord(int wordId)
		{
			Dictionary word = wordRepository.GetWordById(wordId);
			txtWordId.Text = wordId.ToString();
			txtWord.Text = word.Word.ToString();
			txtVietnamese.Text = word.Vietnamese.ToString();
			txtDefinition.Text = word.Meaning.ToString();
			cboWordType.SelectedItem = wordTypeRepository.getAlls()
							   .FirstOrDefault(wt => wt.Id == word.WordTypeNavigation.Id);

			txtWord.IsReadOnly = true;
			txtVietnamese.IsReadOnly = true;
			txtDefinition.IsReadOnly = true;
			cboWordType.IsReadOnly = true;
		}

		private bool checkValidWord()
		{
			bool valid = true;
			string msg = "";
			if (string.IsNullOrEmpty(txtWord.Text))
			{
				msg += "Word can not be empty!\n";
				valid = false;
			}
			if (string.IsNullOrEmpty(txtVietnamese.Text))
			{
				msg += "Meaning in Vietnamese can not be empty!\n";
				valid = false;
			}
			if (cboWordType.SelectedIndex == -1)
			{
				msg += "Word Type muse be choose!";
				valid = false;
			}
			if (msg.Length > 0)
			{
				MessageBox.Show(msg, "Error Message");
			}
			return valid;
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
