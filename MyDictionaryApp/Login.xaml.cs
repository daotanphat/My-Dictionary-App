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
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		private IUserRepository userRepository;
		public Login()
		{
			InitializeComponent();
			userRepository = new UserRepository();
		}

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				User user = new User
				{
					Username = txtUsername.Text,
					Password = txtPassword.Password
				};
				User verifyUser = userRepository.VerifyUser(user);
				if (verifyUser != null)
				{
					Application.Current.Resources["username"] = verifyUser.Username;
					Application.Current.Resources["role"] = verifyUser.RoleNavigation.RoleName;
					MainWindow main = new MainWindow();
					main.Show();
					this.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Login Failed");
			}
		}
	}
}
