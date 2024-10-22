using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public interface IUserRepository
	{
		User VerifyUser(User user);
		User GetUserById(int userId);
		void AddUser(User user);
		void DeleteUser(int userId);
		void UpdateUser(int userId, User user);
	}
}
