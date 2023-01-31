using SharedTrip.Data.Models;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedTrip.Data.Common;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;


        public UserService(IRepository _repository)
        {
            repository = _repository;
        }

        public string Login(LoginViewModel model)
        {
            var hashedPassword = this.Hash(model.Password);

            var userId = this.repository
                .All<User>()
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }

        private string Hash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

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
