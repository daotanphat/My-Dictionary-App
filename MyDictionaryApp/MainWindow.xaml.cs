using System.Text;
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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private bool isAdmin = Application.Current.Resources["role"] as string == "ADMIN";
		public MainWindow()
		{
			InitializeComponent();
		}

		private void mnLogout_Click(object sender, RoutedEventArgs e)
		{

        }

		private void mnDictionary_Click(object sender, RoutedEventArgs e)
		{
			ContentArea.Content = new DictionaryControl(isAdmin);
		}

		private void mnType_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}