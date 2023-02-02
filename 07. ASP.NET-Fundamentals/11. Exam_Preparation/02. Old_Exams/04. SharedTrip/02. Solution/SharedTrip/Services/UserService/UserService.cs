﻿using SharedTrip.Data.Models;
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

        public ICollection<string> Register(RegisterViewModel model)
        {
            var errors = this.ValidateRegistration(model);

            if (this.repository.All<User>().Any(u => u.Username == model.UserName))
            {
                errors.Add("Username is already taken.");
            }

            if (this.repository.All<User>().Any(u => u.Email == model.Email))
            {
                errors.Add("Email is already registered.");
            }

            if (errors.Any())
            {
                return errors;
            }

            try
            {
                repository.Add(new User()
                {
                    Username = model.UserName,
                    Email = model.Email,
                    Password = this.Hash(model.Password),
                });

                repository.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add("Something went wrong. Please try again later.");
            }

            return errors;
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