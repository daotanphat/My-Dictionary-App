using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class UserDAO
	{
		private static UserDAO instance = null;
		private static readonly object instanceLock = new object();
		private UserDAO() { }
		public static UserDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new UserDAO();
					}
					return instance;
				}
			}
		}

		public User verifyUser(User user)
		{
			User user2;
			try
			{
				var myDB = new MyDictionaryContext();
				user2 = myDB.Users
					.Include(u => u.RoleNavigation)
					.FirstOrDefault(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password));
				if (user2 == null)
				{
					throw new Exception("Username or password is not correct");
				}
				return user2;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void addUser(User user)
		{
			try
			{
				var myDB = new MyDictionaryContext();
				User user2 = myDB.Users.FirstOrDefault(u => u.Username.Equals(user.Username) || u.Email.Equals(user.Email));
				if (user2 != null)
				{
					throw new Exception("User with username or email is already exist");
				}
				myDB.Users.Add(user);
				myDB.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public User getUserById(int userId)
		{
			User user1 = new User();
			try
			{
				var myDB = new MyDictionaryContext();
				user1 = myDB.Users.FirstOrDefault(u => u.Id == userId);
				if (user1 == null)
				{
					throw new Exception("Not found User");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return user1;
		}

		public void deleteUser(int userId)
		{
			try
			{
				var myDB = new MyDictionaryContext();
				User user = getUserById(userId);
				if (user == null)
				{
					throw new Exception("Not found User");
				}
				myDB.Users.Remove(user);
				myDB.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void updateUser(int userId, User user)
		{
			try
			{
				var myDB = new MyDictionaryContext();
				User users = getUserById(userId);
				if (users == null)
				{
					throw new Exception("Not found User");
				}
				myDB.Entry<User>(user).State = EntityState.Modified;
				myDB.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}