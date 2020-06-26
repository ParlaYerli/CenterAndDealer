using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private IUserDal _userDal;
        public AuthService(IUserDal _userDal)
        {
            this._userDal = _userDal;
        }
        public void CreateCallCenter(User user)
        {
            _userDal.CreateUser(user);
        }

        public List<User> GetAllCallCenterUser()
        {
            return _userDal.GetAll(x => x.RoleId == 1).ToList();
        }
        public List<User> GetAllDealerUser()
        {
            return _userDal.GetAll(x => x.RoleId == 2).ToList();
        }
        public User GetUserByDealerId(int dealerId)
        {
            return _userDal.GetUser(x => x.DealerId == dealerId);
        }

        public User GetUserById(int userId)
        {
            return _userDal.GetUser(x => x.Id == userId);
        }

        public User LoginCallCenter(int userId, string password)
        {
            var userToCheck = _userDal.GetUser(x => x.Id == userId &&  x.Password == PasswordHasher(password) && (x.RoleId == 1)) ;
            return userToCheck;
        }

        public User LoginDealer(int dealerId, string password)
        {
            return _userDal.GetUser(x => x.IsActive && x.DealerId == dealerId && x.Password == PasswordHasher(password) && (x.RoleId == 2));
        }

        public void UpdateUser(User user)
        {
            _userDal.UpdateUser(user);
        }

        public string RandomPassword(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        string serverKey = "demiroren";
        public string PasswordHasher(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {

                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData + serverKey));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
