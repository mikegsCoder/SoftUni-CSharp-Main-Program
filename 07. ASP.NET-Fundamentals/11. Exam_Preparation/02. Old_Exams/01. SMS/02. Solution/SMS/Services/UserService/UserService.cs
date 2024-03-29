﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using SMS.Data.Common;
using SMS.Services.ValidationService;
using SMS.Data.Models;
using SMS.ViewModels.UserViewModels;

namespace SMS.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        private readonly IValidationService validator;

        public UserService(
            IRepository _repository,
            IValidationService _validationService)
        {
            repository = _repository;
            validator = _validationService;
        }

        private ICollection<string> ValidateRegistration(RegisterViewModel model)
        {
            return validator.ValidateModel(model);
        }

        public ICollection<string> Register(RegisterViewModel model)
        {
            var errors = this.ValidateRegistration(model);

            if (this.repository.All<User>().Any(u => u.Username == model.Username))
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
                    Username = model.Username,
                    Email = model.Email,
                    Password = this.Hash(model.Password),
                    Cart = new Cart()
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

        public string GetUsername(string userId)
        {
            return repository.All<User>()
                .Where(u => u.Id == userId)
                .FirstOrDefault()
                .Username;
        }
    }
}
