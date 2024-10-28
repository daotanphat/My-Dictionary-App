using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
				if (checkInput())
				{
					User user = new User
					{
						Username = txtUsername.Text,
						Password = txtPassword.Password
					};
					try
					{
						User verifyUser = userRepository.VerifyUser(user);
						if (verifyUser != null)
						{
							Application.Current.Resources["userId"] = verifyUser.Id;
							Application.Current.Resources["username"] = verifyUser.Username;
							Application.Current.Resources["role"] = verifyUser.RoleNavigation.RoleName;
							MainWindow main = new MainWindow();
							main.Show();
							this.Close();
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Login");
					}

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Login Failed");
			}
		}

		private void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
			Register register = new Register();
			this.Close();
			register.ShowDialog();
		}
		private bool checkInput()
		{
			bool valid = true;
			string msg = "";
			if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
			{
				msg += "User name can not be empty\n";
			}
			if (string.IsNullOrEmpty(txtPassword.Password.Trim()))
			{
				msg += "Password can not be empty\n";
			}
			if (msg.Length > 0)
			{
				MessageBox.Show(msg, "Error Message");
				valid = false;
			}
			return valid;
		}

	}
}
