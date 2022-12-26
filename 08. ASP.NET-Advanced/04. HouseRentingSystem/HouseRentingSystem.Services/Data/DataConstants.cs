﻿namespace HouseRentingSystem.Services.Data
{
    public class DataConstants
    {
        public class Category
        {
            //Name
            public const int NameMaxLength = 50;
        }

        public class User
        {
            //First name
            public const int UserFirstNameMaxLength = 12;
            public const int UserFirstNameMinLength = 1;

            //Last name
            public const int UserLastNameMaxLength = 15;
            public const int UserLastNameMinLength = 3;
        }
    }
}