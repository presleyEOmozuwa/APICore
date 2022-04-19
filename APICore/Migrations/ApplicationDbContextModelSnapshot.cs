﻿// <auto-generated />
using System;
using APICore.DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APICore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("APICore.DataModelService.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DateCreated")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("APICore.DataModelService.Course", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CourseName")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("PriceId")
                        .HasColumnType("longtext");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = "prod_Kw0dCjRAGwConU",
                            CourseName = "MySql Server Full Course from Beginner to Advanced",
                            Description = "MySQL is the most popular Open Source Relational SQL database management system. It is one of the best RDBMS being used for developing web-based software applications.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfbW92V1pCZzBOSE5aYWJGMUJUck9VN1Zv00n0tiQHJn",
                            Price = 25.0,
                            PriceId = "price_1KG8cJBchTQlHe2g2dMOiJsM"
                        },
                        new
                        {
                            CourseId = "prod_Kw0ahvGX32KTzw",
                            CourseName = "TypeScript Full Course from Beginner to Advanced",
                            Description = "TypeScript is a strongly typed programming language that builds on JavaScript, giving you better tooling at any scale.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfOEowVDdLVVp4V2owRFR5ejFlMGU2UERV00GgMT9Apx",
                            Price = 15.0,
                            PriceId = "price_1KG8Z8BchTQlHe2gsjktNYnu"
                        },
                        new
                        {
                            CourseId = "prod_KvSs46e5WiV7Vt",
                            CourseName = "Object Oriented Programming with C# from Beginner to Advanced",
                            Description = "Object-oriented programming (OOP) is a computer programming model that organizes software design around data, or objects, rather than functions and logic. An object can be defined as a data field that has unique attributes and behavior.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfdTI4bUN4aTRDRFVVN0dva0VwTUR6dTMy00vgxinV5p",
                            Price = 25.0,
                            PriceId = "price_1KFbxDBchTQlHe2gPOJ5lp7C"
                        },
                        new
                        {
                            CourseId = "prod_KvSnOQ8ZohmxV5",
                            CourseName = "C# Full Course from Beginner to Advanced",
                            Description = "C# (pronounced See Sharp) is a modern, object-oriented, and type-safe programming language. C# enables developers to build many types of secure and robust applications that run in .NET. C# has its roots in the C family of languages.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfVUFGck1pZGlMY3ZpNGp6SUc3SXYydE1U00eCDlpcIg",
                            Price = 15.0,
                            PriceId = "price_1KFbrbBchTQlHe2gXmNml4ne"
                        },
                        new
                        {
                            CourseId = "prod_KvS2ytA2Sl2G7Y",
                            CourseName = "Understanding Angular from Scratch",
                            Description = "Angular is a platform and framework for building single-page client applications using HTML and TypeScript. Angular is written in TypeScript. It implements core and optional functionality as a set of TypeScript libraries that you import in your app.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfV1B1cjdUWEdIeUJCMTJ4dGNJUktuN2Vv00VyRoXzRI",
                            Price = 15.0,
                            PriceId = "price_1KFb8IBchTQlHe2glhiYKsb9"
                        },
                        new
                        {
                            CourseId = "prod_KvRuNv5am0kfP8",
                            CourseName = "Functional Programming with JavaScript",
                            Description = "Functional programming (also called FP) is a way of thinking about software construction by creating pure functions. It avoid concepts of shared state, mutable data observed in Object Oriented Programming.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3Rfd3o5cHJzbVFzSXp4cUFmajNzdjhGbGtL00gh1jUIoq",
                            Price = 15.0,
                            PriceId = "price_1KFb0QBchTQlHe2g50saHHWd"
                        },
                        new
                        {
                            CourseId = "prod_KvRpTD0k4Fwpem",
                            CourseName = "JavaScript Full Course from Beginner to Advanced",
                            Description = "JavaScript is a lightweight, interpreted programming language. It is designed for creating network-centric applications. It is complimentary to and integrated with Java. JavaScript is very easy to implement because it is integrated with HTML.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfcTNRWTZEcWE4WmR3RHNFek91c1lHNElH00PsJasLTs",
                            Price = 15.0,
                            PriceId = "price_1KFawEBchTQlHe2geXbAsMzf"
                        },
                        new
                        {
                            CourseId = "prod_KXdodczAkwNX89",
                            CourseName = "Asp.NetCore Tutorials for All Levels",
                            Description = "ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern, cloud-enabled, Internet-connected apps. With ASP.NET Core, you can: Build web apps and services, Internet of Things (IoT) apps, and mobile backends.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfRlhTNURxeDVkRGVFODVvUkdZQkIyTHcx00HcPWlVI2",
                            Price = 10.0,
                            PriceId = "price_1JsYWZBchTQlHe2gipKlxt2V"
                        },
                        new
                        {
                            CourseId = "prod_L7n0aY2Lrd6R3V",
                            CourseName = "Entity FrameWork Core Object Relational Mapper",
                            Description = "Entity Framework Core (EF Core) is the latest version of the Entity Framework from Microsoft. It has been designed to be lightweight, extensible and to support cross platform development as part of Microsoft's .NET Core framework.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfV2JWRTRIVU9BRllFeThhNGVWME5FbjNr00A7GvaNRy",
                            Price = 15.0,
                            PriceId = "price_1KRXQNBchTQlHe2gZ55HwLjP"
                        },
                        new
                        {
                            CourseId = "prod_L7mdNzzROLSDvf",
                            CourseName = "Understanding Data structures & Algorithms",
                            Description = "Data Structures are a specialized means of organizing and storing data in computers in such a way that we can perform operations on the stored data more efficiently.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfVjZBck5pMEEwWlZFU2JwSmU1QVp5M29p00RiBoq9KE",
                            Price = 25.0,
                            PriceId = "price_1KRX4UBchTQlHe2g6SdNl8v6"
                        },
                        new
                        {
                            CourseId = "prod_L7mXFmPUlfIPFn",
                            CourseName = "State Management With Redux and Angular",
                            Description = "Redux is a predictable state container designed to help you write JavaScript apps that behave consistently across client, server, and native environments and are easy to test.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfM0k5QXZObjQ3ZElMc0w0akQ4THZTaXh400HKD4bwNp",
                            Price = 25.0,
                            PriceId = "price_1KRWyaBchTQlHe2gbCIUhhlw"
                        },
                        new
                        {
                            CourseId = "prod_L7mPoD48bvuFNi",
                            CourseName = "MongoDb Non- Relational Database",
                            Description = "MongoDB is a source-available cross-platform document-oriented database program. Classified as a NoSQL database program, MongoDB uses JSON-like documents with optional schemas.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfRmlLR0FnSEI1UFNiZnUxazRtT1JMRmpV00wBiUgEr9",
                            Price = 25.0,
                            PriceId = "price_1KRWqqBchTQlHe2gbtWESce2"
                        },
                        new
                        {
                            CourseId = "prod_L7lgTrYDUaxCWm",
                            CourseName = "Understanding BootStrap Responsive Design",
                            Description = "Bootstrap is a powerful toolkit - a collection of HTML, CSS, and JavaScript tools for creating and building web pages and web applications.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3Rfa0prZ21PQm80UENZVVpXcnVrYmxlQkJ200mlvWfEKk",
                            Price = 15.0,
                            PriceId = "price_1KRW9QBchTQlHe2gM0Ovh1il"
                        },
                        new
                        {
                            CourseId = "prod_L7lc6t4gqysAPd",
                            CourseName = "Understanding CSS and CSS3 Concepts",
                            Description = "Cascading Style Sheets (CSS) is a simple mechanism for adding style (e.g., fonts, colors, spacing) to Web documents.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfNFNLbkhzUWdBc3c1dWFzRGFzdlpST3RZ000dBRGXSu",
                            Price = 15.0,
                            PriceId = "price_1KRW5DBchTQlHe2gY4A6sDUz"
                        },
                        new
                        {
                            CourseId = "prod_L7lYnySmGTQ9QW",
                            CourseName = "Fundamentals Of HTML Concepts",
                            Description = "HTML is the language in which most websites are written. HTML is used to create pages and make them functional.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfamJxaDZ6eWtLUEhNOUtRZFEzMjY5TVB300PHVbdMRZ",
                            Price = 10.0,
                            PriceId = "price_1KRW1CBchTQlHe2gOiDXqDjg"
                        },
                        new
                        {
                            CourseId = "prod_L7lJ6R4CvhoTDi",
                            CourseName = "Node js Runtime Environment",
                            Description = "Node.js is a free, open-sourced, cross-platform JavaScript run-time environment that lets developers write command line tools and server-side scripts outside of a browser.",
                            Image = "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfRU5YYWJNY2ZFa0tUYUdZM1pOYzRHWFRh00yjfhRDIx",
                            Price = 15.0,
                            PriceId = "price_1KRVmjBchTQlHe2gnWy0wtwK"
                        });
                });

            modelBuilder.Entity("APICore.DataModelService.CourseCart", b =>
                {
                    b.Property<string>("CourseCartId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("CourseId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("CourseCartId");

                    b.HasIndex("CartId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseCarts");
                });

            modelBuilder.Entity("APICore.DataModelService.Subscriber", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CurrentPeriodEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("APICore.ModelService.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerId")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("APICore.DataModelService.Cart", b =>
                {
                    b.HasOne("APICore.ModelService.ApplicationUser", null)
                        .WithOne("Cart")
                        .HasForeignKey("APICore.DataModelService.Cart", "ApplicationUserId");
                });

            modelBuilder.Entity("APICore.DataModelService.CourseCart", b =>
                {
                    b.HasOne("APICore.DataModelService.Cart", "Cart")
                        .WithMany("CourseCarts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APICore.DataModelService.Course", "Course")
                        .WithMany("CourseCarts")
                        .HasForeignKey("CourseId");

                    b.Navigation("Cart");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("APICore.ModelService.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("APICore.ModelService.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APICore.ModelService.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("APICore.ModelService.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APICore.DataModelService.Cart", b =>
                {
                    b.Navigation("CourseCarts");
                });

            modelBuilder.Entity("APICore.DataModelService.Course", b =>
                {
                    b.Navigation("CourseCarts");
                });

            modelBuilder.Entity("APICore.ModelService.ApplicationUser", b =>
                {
                    b.Navigation("Cart");
                });
#pragma warning restore 612, 618
        }
    }
}
