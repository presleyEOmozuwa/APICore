using System;
using System.Collections.Generic;
using APICore.DataModelService;

namespace APICore.UnitTests.Fixtures
{
    public static class AppUserFixture
    {
        public static List<ApplicationUser> GetUsers()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = "1",
                    FirstName = "Alexis",
                    LastName = "Omozuwa",
                    Email = "alexisomozuwa@gmail.com",
                    UserName = "Lexy82"
                },
                new ApplicationUser()
                {
                    Id = "2",
                    FirstName = "Wesley",
                    LastName = "Omozuwa",
                    Email = "wesleyomozuwa@gmail.com",
                    UserName = "WesleyPongo"
                },
                new ApplicationUser()
                {
                    Id = "3",
                    FirstName = "Hensley",
                    LastName = "Omozuwa",
                    Email = "hensleyomozuwa@gmail.com",
                    UserName = "Hensley85"
                },
                new ApplicationUser()
                {
                    Id = "4",
                    FirstName = "Taylor",
                    LastName = "Swift",
                    Email = "taylorswift@gmail.com",
                    UserName = "Taylor87"
                },
                new ApplicationUser()
                {
                    Id = "5",
                    FirstName = "Bagwells",
                    LastName = "Page",
                    Email = "bagwellspage@gmail.com",
                    UserName = "Bagwells88"
                }
            };
        }
    }
}
