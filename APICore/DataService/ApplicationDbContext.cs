using System;
using APICore.DataModelService;
using APICore.ModelService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APICore.DataService
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCart> CourseCarts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().HasData(
             new Course()
             {

                 CourseId = "prod_Kw0dCjRAGwConU",
                 PriceId = "price_1KG8cJBchTQlHe2g2dMOiJsM",
                 CourseName = "MySql Server Full Course from Beginner to Advanced",
                 Description = "MySQL is the most popular Open Source Relational SQL database management system. It is one of the best RDBMS being used for developing web-based software applications.",
                 Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfbW92V1pCZzBOSE5aYWJGMUJUck9VN1Zv00n0tiQHJn",
                 Price = 25.00
             },

              new Course()
              {
                  CourseId = "prod_Kw0ahvGX32KTzw",
                  PriceId = "price_1KG8Z8BchTQlHe2gsjktNYnu",
                  CourseName = "TypeScript Full Course from Beginner to Advanced",
                  Description = "TypeScript is a strongly typed programming language that builds on JavaScript, giving you better tooling at any scale.",
                  Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfOEowVDdLVVp4V2owRFR5ejFlMGU2UERV00GgMT9Apx",
                  Price = 15.00
              },

               new Course()
               {
                   CourseId = "prod_KvSs46e5WiV7Vt",
                   PriceId = "price_1KFbxDBchTQlHe2gPOJ5lp7C",
                   CourseName = "Object Oriented Programming with C# from Beginner to Advanced",
                   Description = "Object-oriented programming (OOP) is a computer programming model that organizes software design around data, or objects, rather than functions and logic. An object can be defined as a data field that has unique attributes and behavior.",
                   Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfdTI4bUN4aTRDRFVVN0dva0VwTUR6dTMy00vgxinV5p",
                   Price = 25.00
               },

                 new Course()
                 {
                     CourseId = "prod_KvSnOQ8ZohmxV5",
                     PriceId = "price_1KFbrbBchTQlHe2gXmNml4ne",
                     CourseName = "C# Full Course from Beginner to Advanced",
                     Description = "C# (pronounced See Sharp) is a modern, object-oriented, and type-safe programming language. C# enables developers to build many types of secure and robust applications that run in .NET. C# has its roots in the C family of languages.",
                     Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfVUFGck1pZGlMY3ZpNGp6SUc3SXYydE1U00eCDlpcIg",
                     Price = 15.00
                 },

                  new Course()
                  {
                      CourseId = "prod_KvS2ytA2Sl2G7Y",
                      PriceId = "price_1KFb8IBchTQlHe2glhiYKsb9",
                      CourseName = "Understanding Angular from Scratch",
                      Description = "Angular is a platform and framework for building single-page client applications using HTML and TypeScript. Angular is written in TypeScript. It implements core and optional functionality as a set of TypeScript libraries that you import in your app.",
                      Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfV1B1cjdUWEdIeUJCMTJ4dGNJUktuN2Vv00VyRoXzRI",
                      Price = 15.00
                  },

                    new Course()
                    {
                        CourseId = "prod_KvRuNv5am0kfP8",
                        PriceId = "price_1KFb0QBchTQlHe2g50saHHWd",
                        CourseName = "Functional Programming with JavaScript",
                        Description = "Functional programming (also called FP) is a way of thinking about software construction by creating pure functions. It avoid concepts of shared state, mutable data observed in Object Oriented Programming.",
                        Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3Rfd3o5cHJzbVFzSXp4cUFmajNzdjhGbGtL00gh1jUIoq",
                        Price = 15.00
                    },

                    new Course()
                    {
                        CourseId = "prod_KvRpTD0k4Fwpem",
                        PriceId = "price_1KFawEBchTQlHe2geXbAsMzf",
                        CourseName = "JavaScript Full Course from Beginner to Advanced",
                        Description = "JavaScript is a lightweight, interpreted programming language. It is designed for creating network-centric applications. It is complimentary to and integrated with Java. JavaScript is very easy to implement because it is integrated with HTML.",
                        Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfcTNRWTZEcWE4WmR3RHNFek91c1lHNElH00PsJasLTs",
                        Price = 15.00
                    },

                     new Course()
                     {
                         CourseId = "prod_KXdodczAkwNX89",
                         PriceId = "price_1JsYWZBchTQlHe2gipKlxt2V",
                         CourseName = "Asp.NetCore Tutorials for All Levels",
                         Description = "ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern, cloud-enabled, Internet-connected apps. With ASP.NET Core, you can: Build web apps and services, Internet of Things (IoT) apps, and mobile backends.",
                         Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfRlhTNURxeDVkRGVFODVvUkdZQkIyTHcx00HcPWlVI2",
                         Price = 10.00
                     },

                      new Course()
                      {
                          CourseId = "prod_L7n0aY2Lrd6R3V",
                          PriceId = "price_1KRXQNBchTQlHe2gZ55HwLjP",
                          CourseName = "Entity FrameWork Core Object Relational Mapper",
                          Description = "Entity Framework Core (EF Core) is the latest version of the Entity Framework from Microsoft. It has been designed to be lightweight, extensible and to support cross platform development as part of Microsoft's .NET Core framework.",
                          Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfV2JWRTRIVU9BRllFeThhNGVWME5FbjNr00A7GvaNRy",
                          Price = 15.00
                      },

                     new Course()
                     {
                         CourseId = "prod_L7mdNzzROLSDvf",
                         PriceId = "price_1KRX4UBchTQlHe2g6SdNl8v6",
                         CourseName = "Understanding Data structures & Algorithms",
                         Description = "Data Structures are a specialized means of organizing and storing data in computers in such a way that we can perform operations on the stored data more efficiently.",
                         Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfVjZBck5pMEEwWlZFU2JwSmU1QVp5M29p00RiBoq9KE",
                         Price = 25.00
                     },

                    new Course()
                    {
                        CourseId = "prod_L7mXFmPUlfIPFn",
                        PriceId = "price_1KRWyaBchTQlHe2gbCIUhhlw",
                        CourseName = "State Management With Redux and Angular",
                        Description = "Redux is a predictable state container designed to help you write JavaScript apps that behave consistently across client, server, and native environments and are easy to test.",
                        Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfM0k5QXZObjQ3ZElMc0w0akQ4THZTaXh400HKD4bwNp",
                        Price = 25.00
                    },

                     new Course()
                     {
                         CourseId = "prod_L7mPoD48bvuFNi",
                         PriceId = "price_1KRWqqBchTQlHe2gbtWESce2",
                         CourseName = "MongoDb Non- Relational Database",
                         Description = "MongoDB is a source-available cross-platform document-oriented database program. Classified as a NoSQL database program, MongoDB uses JSON-like documents with optional schemas.",
                         Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfRmlLR0FnSEI1UFNiZnUxazRtT1JMRmpV00wBiUgEr9",
                         Price = 25.00
                     },

                     new Course()
                     {
                         CourseId = "prod_L7lgTrYDUaxCWm",
                         PriceId = "price_1KRW9QBchTQlHe2gM0Ovh1il",
                         CourseName = "Understanding BootStrap Responsive Design",
                         Description = "Bootstrap is a powerful toolkit - a collection of HTML, CSS, and JavaScript tools for creating and building web pages and web applications.",
                         Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3Rfa0prZ21PQm80UENZVVpXcnVrYmxlQkJ200mlvWfEKk",
                         Price = 15.00
                     },

                     new Course()
                     {
                         CourseId = "prod_L7lc6t4gqysAPd",
                         PriceId = "price_1KRW5DBchTQlHe2gY4A6sDUz",
                         CourseName = "Understanding CSS and CSS3 Concepts",
                         Description = "Cascading Style Sheets (CSS) is a simple mechanism for adding style (e.g., fonts, colors, spacing) to Web documents.",
                         Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfNFNLbkhzUWdBc3c1dWFzRGFzdlpST3RZ000dBRGXSu",
                         Price = 15.00
                     },

                     new Course()
                     {
                         CourseId = "prod_L7lYnySmGTQ9QW",
                         PriceId = "price_1KRW1CBchTQlHe2gOiDXqDjg",
                         CourseName = "Fundamentals Of HTML Concepts",
                         Description = "HTML is the language in which most websites are written. HTML is used to create pages and make them functional.",
                         Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfamJxaDZ6eWtLUEhNOUtRZFEzMjY5TVB300PHVbdMRZ",
                         Price = 10.00
                     },

                      new Course()
                      {
                          CourseId = "prod_L7lJ6R4CvhoTDi",
                          PriceId = "price_1KRVmjBchTQlHe2gnWy0wtwK",
                          CourseName = "Node js Runtime Environment",
                          Description = "Node.js is a free, open-sourced, cross-platform JavaScript run-time environment that lets developers write command line tools and server-side scripts outside of a browser.",
                          Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfRU5YYWJNY2ZFa0tUYUdZM1pOYzRHWFRh00yjfhRDIx",
                          Price = 15.00
                      }
           );
        }
    }
}
