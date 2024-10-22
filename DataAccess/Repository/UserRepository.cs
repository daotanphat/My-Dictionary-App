using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public class UserRepository : IUserRepository
	{
		public void AddUser(User user)
		{
			UserDAO.Instance.addUser(user);
		}

		public void DeleteUser(int userId)
		{
			UserDAO.Instance.deleteUser(userId);
		}

		public User GetUserById(int userId)
		{
			return UserDAO.Instance.getUserById(userId);
		}

		public void UpdateUser(int userId, User user)
		{
			UserDAO.Instance.updateUser(userId, user);
		}

		public User VerifyUser(User user)
		{
			return UserDAO.Instance.verifyUser(user);
		}
	}
}
