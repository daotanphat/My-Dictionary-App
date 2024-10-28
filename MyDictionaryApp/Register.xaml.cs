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
	/// Interaction logic for Register.xaml
	/// </summary>
	public partial class Register : Window
	{
		private IUserRepository userRepository;
		public Register()
		{
			InitializeComponent();
			userRepository = new UserRepository();
		}

		private void btnRegister_Click(object sender, RoutedEventArgs e)
		{
			if (checkInput())
			{
				User user = new User
				{
					Username = txtUsername.Text,
					Email = txtEmail.Text,
					Password = txtPassword.Password,
					Status = true,
					Role = 2
				};
				try
				{
					userRepository.AddUser(user);
					MessageBox.Show("Register successfully!", "Register");
					Login login = new Login();
					this.Close();
					login.ShowDialog();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Register");
				}
			}
		}

		private void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
			Login login = new Login();
			this.Close();
			login.ShowDialog();
		}

		private bool checkInput()
		{
			bool valid = true;
			string msg = "";
			if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
			{
				msg += "User name can not be empty\n";
			}
			else
			{
				if (!Regex.IsMatch(txtUsername.Text, @"^[a-zA-Z0-9]{6,}$"))
				{
					msg += "Username must be at least 6 characters and not contain special character";
				}
			}
			if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
			{
				msg += "Email can not be empty\n";
			}
			if (string.IsNullOrEmpty(txtPassword.Password.Trim()))
			{
				msg += "Password can not be empty\n";
			}
			if (string.IsNullOrEmpty(txtConfirmPassword.Password.Trim()))
			{
				msg += "Confirm password can not be empty\n";
			}
			else
			{
				if (!txtConfirmPassword.Password.Equals(txtPassword.Password))
				{
					msg += "Confirm password does not match!\n";
				}
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
