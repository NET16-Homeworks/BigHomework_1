using BigHomework_1.Exceptions;
using BigHomework_1.Helpers;

namespace BigHomework_1.Services
{
    public sealed class UserService
    {
        private static List<User> _users = new List<User>();

        public void CreateUser()
        {
            (string firstName, string lastName, string email, int age) userInfo
                = ConsoleHelper.ReadUserInfo();

            if (IsUsersEmpty())
            {
                _users.Add(new User
                {
                    FirstName = userInfo.firstName,
                    LastName = userInfo.lastName,
                    Email = userInfo.email,
                    Age = userInfo.age
                });
            }
            else
            {
                var isUserExists = UserExists(userInfo.email);
                if (isUserExists)
                {
                    throw new ObjectExistsException(userInfo.email);
                }

                _users.Add(new User
                {
                    FirstName = userInfo.firstName,
                    LastName = userInfo.lastName,
                    Email = userInfo.email,
                    Age = userInfo.age
                });
            }
        }

        public void DeleteUser(string email)
        {
            var user = GetUserByEmail(email);
            _users.Remove(user);
        }

        public void WriteUserInfo(string email)
        {
            var user = GetUserByEmail(email);
            Console.WriteLine(user);
        }
      
        public bool UserExists(string email)
        {
            if (IsUsersEmpty())
            {
                throw new ObjectNotFoundException(email);
            }

            return _users.Exists(x => x.Email == email);
        }

        private User GetUserByEmail(string email)
        {
            User? user = _users.Find(x => x.Email == email);
            if (user == null)
            {
                throw new ObjectNotFoundException(email);
            }

            return user;
        }

        private bool IsUsersEmpty()
        {
            return _users.Count == 0;
        }
    }
}
