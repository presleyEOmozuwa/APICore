using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APICore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PriceId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    CourseName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentPeriodEnd = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreated = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseCarts",
                columns: table => new
                {
                    CourseCartId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCarts", x => x.CourseCartId);
                    table.ForeignKey(
                        name: "FK_CourseCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCarts_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Description", "Image", "Price", "PriceId" },
                values: new object[,]
                {
                    { "prod_Kw0dCjRAGwConU", "MySql Server Full Course from Beginner to Advanced", "MySQL is the most popular Open Source Relational SQL database management system. It is one of the best RDBMS being used for developing web-based software applications.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfbW92V1pCZzBOSE5aYWJGMUJUck9VN1Zv00n0tiQHJn", 25.0, "price_1KG8cJBchTQlHe2g2dMOiJsM" },
                    { "prod_Kw0ahvGX32KTzw", "TypeScript Full Course from Beginner to Advanced", "TypeScript is a strongly typed programming language that builds on JavaScript, giving you better tooling at any scale.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfOEowVDdLVVp4V2owRFR5ejFlMGU2UERV00GgMT9Apx", 15.0, "price_1KG8Z8BchTQlHe2gsjktNYnu" },
                    { "prod_KvSs46e5WiV7Vt", "Object Oriented Programming with C# from Beginner to Advanced", "Object-oriented programming (OOP) is a computer programming model that organizes software design around data, or objects, rather than functions and logic. An object can be defined as a data field that has unique attributes and behavior.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfdTI4bUN4aTRDRFVVN0dva0VwTUR6dTMy00vgxinV5p", 25.0, "price_1KFbxDBchTQlHe2gPOJ5lp7C" },
                    { "prod_KvSnOQ8ZohmxV5", "C# Full Course from Beginner to Advanced", "C# (pronounced See Sharp) is a modern, object-oriented, and type-safe programming language. C# enables developers to build many types of secure and robust applications that run in .NET. C# has its roots in the C family of languages.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfVUFGck1pZGlMY3ZpNGp6SUc3SXYydE1U00eCDlpcIg", 15.0, "price_1KFbrbBchTQlHe2gXmNml4ne" },
                    { "prod_KvS2ytA2Sl2G7Y", "Understanding Angular from Scratch", "Angular is a platform and framework for building single-page client applications using HTML and TypeScript. Angular is written in TypeScript. It implements core and optional functionality as a set of TypeScript libraries that you import in your app.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfV1B1cjdUWEdIeUJCMTJ4dGNJUktuN2Vv00VyRoXzRI", 15.0, "price_1KFb8IBchTQlHe2glhiYKsb9" },
                    { "prod_KvRuNv5am0kfP8", "Functional Programming with JavaScript", "Functional programming (also called FP) is a way of thinking about software construction by creating pure functions. It avoid concepts of shared state, mutable data observed in Object Oriented Programming.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3Rfd3o5cHJzbVFzSXp4cUFmajNzdjhGbGtL00gh1jUIoq", 15.0, "price_1KFb0QBchTQlHe2g50saHHWd" },
                    { "prod_KvRpTD0k4Fwpem", "JavaScript Full Course from Beginner to Advanced", "JavaScript is a lightweight, interpreted programming language. It is designed for creating network-centric applications. It is complimentary to and integrated with Java. JavaScript is very easy to implement because it is integrated with HTML.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfcTNRWTZEcWE4WmR3RHNFek91c1lHNElH00PsJasLTs", 15.0, "price_1KFawEBchTQlHe2geXbAsMzf" },
                    { "prod_KXdodczAkwNX89", "Asp.NetCore Tutorials for All Levels", "ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern, cloud-enabled, Internet-connected apps. With ASP.NET Core, you can: Build web apps and services, Internet of Things (IoT) apps, and mobile backends.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfRlhTNURxeDVkRGVFODVvUkdZQkIyTHcx00HcPWlVI2", 10.0, "price_1JsYWZBchTQlHe2gipKlxt2V" },
                    { "prod_L7n0aY2Lrd6R3V", "Entity FrameWork Core Object Relational Mapper", "Entity Framework Core (EF Core) is the latest version of the Entity Framework from Microsoft. It has been designed to be lightweight, extensible and to support cross platform development as part of Microsoft's .NET Core framework.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfV2JWRTRIVU9BRllFeThhNGVWME5FbjNr00A7GvaNRy", 15.0, "price_1KRXQNBchTQlHe2gZ55HwLjP" },
                    { "prod_L7mdNzzROLSDvf", "Understanding Data structures & Algorithms", "Data Structures are a specialized means of organizing and storing data in computers in such a way that we can perform operations on the stored data more efficiently.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfVjZBck5pMEEwWlZFU2JwSmU1QVp5M29p00RiBoq9KE", 25.0, "price_1KRX4UBchTQlHe2g6SdNl8v6" },
                    { "prod_L7mXFmPUlfIPFn", "State Management With Redux and Angular", "Redux is a predictable state container designed to help you write JavaScript apps that behave consistently across client, server, and native environments and are easy to test.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfM0k5QXZObjQ3ZElMc0w0akQ4THZTaXh400HKD4bwNp", 25.0, "price_1KRWyaBchTQlHe2gbCIUhhlw" },
                    { "prod_L7mPoD48bvuFNi", "MongoDb Non- Relational Database", "MongoDB is a source-available cross-platform document-oriented database program. Classified as a NoSQL database program, MongoDB uses JSON-like documents with optional schemas.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfRmlLR0FnSEI1UFNiZnUxazRtT1JMRmpV00wBiUgEr9", 25.0, "price_1KRWqqBchTQlHe2gbtWESce2" },
                    { "prod_L7lgTrYDUaxCWm", "Understanding BootStrap Responsive Design", "Bootstrap is a powerful toolkit - a collection of HTML, CSS, and JavaScript tools for creating and building web pages and web applications.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3Rfa0prZ21PQm80UENZVVpXcnVrYmxlQkJ200mlvWfEKk", 15.0, "price_1KRW9QBchTQlHe2gM0Ovh1il" },
                    { "prod_L7lc6t4gqysAPd", "Understanding CSS and CSS3 Concepts", "Cascading Style Sheets (CSS) is a simple mechanism for adding style (e.g., fonts, colors, spacing) to Web documents.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfNFNLbkhzUWdBc3c1dWFzRGFzdlpST3RZ000dBRGXSu", 15.0, "price_1KRW5DBchTQlHe2gY4A6sDUz" },
                    { "prod_L7lYnySmGTQ9QW", "Fundamentals Of HTML Concepts", "HTML is the language in which most websites are written. HTML is used to create pages and make them functional.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfamJxaDZ6eWtLUEhNOUtRZFEzMjY5TVB300PHVbdMRZ", 10.0, "price_1KRW1CBchTQlHe2gOiDXqDjg" },
                    { "prod_L7lJ6R4CvhoTDi", "Node js Runtime Environment", "Node.js is a free, open-sourced, cross-platform JavaScript run-time environment that lets developers write command line tools and server-side scripts outside of a browser.", "https://files.stripe.com/links/MDB8YWNjdF8xSnJ5SzBCY2hUUWxIZTJnfGZsX3Rlc3RfRU5YYWJNY2ZFa0tUYUdZM1pOYzRHWFRh00yjfhRDIx", 15.0, "price_1KRVmjBchTQlHe2gnWy0wtwK" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseCarts_CartId",
                table: "CourseCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCarts_CourseId",
                table: "CourseCarts",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CourseCarts");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
