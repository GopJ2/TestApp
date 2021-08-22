using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApp.Data.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestQuestion_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_TestQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "TestQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "Password" },
                values: new object[] { "ce40ea29-e665-4a37-858b-e7d2359cdd4f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestUser@gmail.com", "yP7xXNBu/Hny3XSz7QCNjOgkM7HOkPgVFiXTPr5dwTg=" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "Password" },
                values: new object[] { "a8a4828c-60f0-4f99-bbe6-229df1d098a2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestUser2@gmail.com", "yP7xXNBu/Hny3XSz7QCNjOgkM7HOkPgVFiXTPr5dwTg=" });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { "f14f0184-0b15-431f-b4e3-853224eed6dd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample C# Tests Description", "C# Test", "ce40ea29-e665-4a37-858b-e7d2359cdd4f" },
                    { "b5902bf9-bea2-4fac-96bc-52c0ed52e6c7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Node.js Tests", "Node.js Test", "ce40ea29-e665-4a37-858b-e7d2359cdd4f" },
                    { "91b1aa6d-bd4a-43e0-ad89-e672709e35fe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample LINQ Tests", "LINQ Test", "a8a4828c-60f0-4f99-bbe6-229df1d098a2" },
                    { "c23f9ea6-50a9-417c-89bb-15194cc2787b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Javascript Tests", "Vanilla JS Test", "a8a4828c-60f0-4f99-bbe6-229df1d098a2" }
                });

            migrationBuilder.InsertData(
                table: "TestQuestion",
                columns: new[] { "Id", "CreatedAt", "QuestionText", "TestId" },
                values: new object[,]
                {
                    { "3185b7d6-85b1-4866-8fe2-e287965b841f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the following methods is an entry point in the C# console program?", "f14f0184-0b15-431f-b4e3-853224eed6dd" },
                    { "b997c953-a860-4a0d-a403-ec689ff60d46", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript written under which of the following tag?", "c23f9ea6-50a9-417c-89bb-15194cc2787b" },
                    { "1834f0be-b24e-47cf-b609-d5c184cb6a02", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript is ECMAScript", "c23f9ea6-50a9-417c-89bb-15194cc2787b" },
                    { "127d9f22-064a-4470-8b03-d7c4b85948ef", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the following statement is TRUE?", "91b1aa6d-bd4a-43e0-ad89-e672709e35fe" },
                    { "698f456f-f913-4858-9be2-f5184bc5944a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the following supports LINQ queries?", "91b1aa6d-bd4a-43e0-ad89-e672709e35fe" },
                    { "59ecff8a-3952-48c0-870b-59db1f6b060a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LINQ supports ________ syntax.", "91b1aa6d-bd4a-43e0-ad89-e672709e35fe" },
                    { "5e56ae65-891b-4f87-a5b1-37a9798b2e53", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The full form of LINQ is _______.", "91b1aa6d-bd4a-43e0-ad89-e672709e35fe" },
                    { "6b119880-12e5-4510-aa14-83a51f94adb6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A variable in JavaScript declared with which of the following keyword?", "c23f9ea6-50a9-417c-89bb-15194cc2787b" },
                    { "0508062a-da04-4349-9832-113b1405cfff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Node.js terminal (REPL) is used for _________.", "b5902bf9-bea2-4fac-96bc-52c0ed52e6c7" },
                    { "cf8d123f-0a84-4961-f029-12h6x1756047", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Node.js is ________ by default.", "b5902bf9-bea2-4fac-96bc-52c0ed52e6c7" },
                    { "cf8d414b-0a84-4961-9049-52b6c1756047", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Node.js runs on __________", "b5902bf9-bea2-4fac-96bc-52c0ed52e6c7" },
                    { "5a51d21e-5a17-4dc1-b892-e1abf27f92c4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Struct is a _____.", "f14f0184-0b15-431f-b4e3-853224eed6dd" },
                    { "0ad888e5-3db1-422c-a5bf-d3fede49a6d4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "What is the nullable type in C#?", "f14f0184-0b15-431f-b4e3-853224eed6dd" },
                    { "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the following is a reference type in C#?", "f14f0184-0b15-431f-b4e3-853224eed6dd" },
                    { "27669b19-c256-4065-a7b5-432bb44da2c7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the followings are value types in C#?", "f14f0184-0b15-431f-b4e3-853224eed6dd" },
                    { "692235e8-1fb5-449e-9d43-b1a807cf3ca6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Node.js supports which of the following platform?", "b5902bf9-bea2-4fac-96bc-52c0ed52e6c7" },
                    { "73eddcbd-5964-4d2c-ab8d-85dd0d6ed6cd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the followings are primitive data types in JavaScript?", "c23f9ea6-50a9-417c-89bb-15194cc2787b" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerText", "CreatedAt", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { "00b6a320-3940-402a-9883-0d562f1c2f98", "public static void Program()", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "3185b7d6-85b1-4866-8fe2-e287965b841f" },
                    { "1c92d6b2-e0de-41a3-8000-38eeb6eb9b9b", "None of the above.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "0508062a-da04-4349-9832-113b1405cfff" },
                    { "c8b9035c-9bf0-43c3-81e0-0f514cc68c56", "Link-List Inner Query", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5e56ae65-891b-4f87-a5b1-37a9798b2e53" },
                    { "f2cc79d5-e09a-4fd1-a309-0ab76930080e", "Language-Integrated Query", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "5e56ae65-891b-4f87-a5b1-37a9798b2e53" },
                    { "9ec8eada-e1e6-4076-9703-e578e5508055", "Linked-Integrated Query", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5e56ae65-891b-4f87-a5b1-37a9798b2e53" },
                    { "22333f93-cc7b-4a33-8b8f-8e8c7249d118", "Lazy Integration Query", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5e56ae65-891b-4f87-a5b1-37a9798b2e53" },
                    { "22a92b49-45d8-4bd1-9fc8-f4237bf91e59", "C# and F#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "59ecff8a-3952-48c0-870b-59db1f6b060a" },
                    { "20a6505d-24b8-46f8-944a-9791a164e24b", "VB and F#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "59ecff8a-3952-48c0-870b-59db1f6b060a" },
                    { "c4163c84-f5e9-468a-92c5-0a50f35eb1e8", "C# and VB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "59ecff8a-3952-48c0-870b-59db1f6b060a" },
                    { "fa132b69-e740-433c-af31-7dfc9be1dbdc", "All the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "59ecff8a-3952-48c0-870b-59db1f6b060a" },
                    { "622fffc8-a8fa-4ab3-ab98-838072958bf7", "Object collection", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "698f456f-f913-4858-9be2-f5184bc5944a" },
                    { "7e44084e-fa5e-4be3-8f27-158d2b4cf1db", "Double", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "698f456f-f913-4858-9be2-f5184bc5944a" },
                    { "cb065ff5-63b4-4e07-8738-d8e8afb11cce", "Long", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "698f456f-f913-4858-9be2-f5184bc5944a" },
                    { "1ac42230-c05a-4e84-948a-3aa80ef3cd4e", "All the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "698f456f-f913-4858-9be2-f5184bc5944a" },
                    { "35223d3d-b9a9-4937-bb2e-17db43ba8c09", "LINQ API is a bunch of extension methods included in System.Linq.Enumerable and System.Linq.Queryable class.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "127d9f22-064a-4470-8b03-d7c4b85948ef" },
                    { "19fdf0b4-056e-47fe-8492-316083a5bb7d", "LINQ API is a bunch of abstract methods included in Enumerable and Queryable classes.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "127d9f22-064a-4470-8b03-d7c4b85948ef" },
                    { "a9dc1df5-1e10-4cd2-9320-0f9b29dad640", "LINQ API is bunch of queries written in C# and VB.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "127d9f22-064a-4470-8b03-d7c4b85948ef" },
                    { "9a93841c-ba29-41d2-bbc5-17509b775cfe", "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "127d9f22-064a-4470-8b03-d7c4b85948ef" },
                    { "fdb4f948-2c6e-4dd5-99fb-747601ea0186", "True", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "1834f0be-b24e-47cf-b609-d5c184cb6a02" },
                    { "a067d682-297f-4a0d-b6e2-fee28020934d", "False", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "1834f0be-b24e-47cf-b609-d5c184cb6a02" },
                    { "94da67c1-e633-4b4c-9008-abc7a4b34a9c", "<JavaScript></JavaScript>", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "b997c953-a860-4a0d-a403-ec689ff60d46" },
                    { "2f8a01ee-d417-49d3-b794-f2c8ac51574a", "<script></script>", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "b997c953-a860-4a0d-a403-ec689ff60d46" },
                    { "9bb0cf8f-13f2-4bae-bea7-725aeba678ba", "<code></code>", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "b997c953-a860-4a0d-a403-ec689ff60d46" },
                    { "7b2b255d-3490-40af-81b9-e8ee9375b322", "<head></head>", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "b997c953-a860-4a0d-a403-ec689ff60d46" },
                    { "6c727e7e-3bd7-4b73-86fa-c24bd5c6ea37", "new", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "6b119880-12e5-4510-aa14-83a51f94adb6" },
                    { "d862e0f3-c591-4b3b-ae0b-24b2435b350a", "int", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "6b119880-12e5-4510-aa14-83a51f94adb6" },
                    { "b3beb7cc-4908-4f0b-a779-80fc3809698c", "string", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "6b119880-12e5-4510-aa14-83a51f94adb6" },
                    { "b333657b-6dbc-4f35-ac9c-f65520ca78a4", "let/const", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "6b119880-12e5-4510-aa14-83a51f94adb6" },
                    { "d4e94fed-de96-443e-b7b7-850a62a0e170", "String", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "73eddcbd-5964-4d2c-ab8d-85dd0d6ed6cd" },
                    { "8eaef720-cb19-486f-b9a7-9661f28ceccb", "Number", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "73eddcbd-5964-4d2c-ab8d-85dd0d6ed6cd" },
                    { "ad0bca29-b669-4da2-ac09-adf8b2d8c1d7", "The preview of node.js application.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "0508062a-da04-4349-9832-113b1405cfff" },
                    { "8a51a2ee-a42e-49c2-bdd2-2c1fd3c0324c", "Executing browser’s JavaScript expressions.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "0508062a-da04-4349-9832-113b1405cfff" },
                    { "d7127099-8fe8-4c91-ba4f-547d7ee43c8a", "Testing node.js/JavaScript expressions", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "0508062a-da04-4349-9832-113b1405cfff" },
                    { "84395c79-3f8b-44b6-abe4-07a65dca7433", "All", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "692235e8-1fb5-449e-9d43-b1a807cf3ca6" },
                    { "ef3136cc-fcdf-4e7e-8444-e07d221e18c2", "public static void Main()", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "3185b7d6-85b1-4866-8fe2-e287965b841f" },
                    { "09e99bee-b2c4-4927-9c65-26bd62bb36fe", "public static void main()", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "3185b7d6-85b1-4866-8fe2-e287965b841f" },
                    { "bf7c693c-d6d1-406e-ae89-d243865c5a43", "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "3185b7d6-85b1-4866-8fe2-e287965b841f" },
                    { "c1cd5444-a65d-4e33-9050-208ec88c9805", "Int32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "27669b19-c256-4065-a7b5-432bb44da2c7" },
                    { "f8ff703c-1fd8-4f10-b662-30661cb3c870", "Double", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "27669b19-c256-4065-a7b5-432bb44da2c7" },
                    { "51e7a3b7-c90e-4a14-8f93-aefeb4174993", "Decimal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "27669b19-c256-4065-a7b5-432bb44da2c7" },
                    { "2e7e27fa-4369-4b24-ac9a-8e39ea073895", "All the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "27669b19-c256-4065-a7b5-432bb44da2c7" },
                    { "9162071d-768f-4563-8d74-1a1f6c0c05df", "String", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerText", "CreatedAt", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { "bfccf393-e4f8-41a5-9e22-cf1335aa472d", "Double", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05" },
                    { "3a371e83-3874-4f47-940d-9f40d11d3e3a", "Long", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05" },
                    { "dc051ff9-0deb-446a-ac78-d4907e43078f", "All the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05" },
                    { "4c08338b-e0f1-41a7-8988-a9d240b85d5b", "It allows assignment of null to reference type.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "0ad888e5-3db1-422c-a5bf-d3fede49a6d4" },
                    { "d864185d-97b3-417a-892b-7a29455b90e5", "It allows assignment of null to value type.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "0ad888e5-3db1-422c-a5bf-d3fede49a6d4" },
                    { "889ed162-b77a-4e7e-bd29-882486bbf168", "It allows assignment of null to static class.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "0ad888e5-3db1-422c-a5bf-d3fede49a6d4" },
                    { "301773f2-73b7-4d84-aec6-ecc80fbb97e9", "Boolean", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "73eddcbd-5964-4d2c-ab8d-85dd0d6ed6cd" },
                    { "7961ce25-8887-497e-9b11-25657902f057", "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "0ad888e5-3db1-422c-a5bf-d3fede49a6d4" },
                    { "6ad7dff2-12f8-44f9-91f7-29e701c49bbe", "Value type", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "5a51d21e-5a17-4dc1-b892-e1abf27f92c4" },
                    { "b9924313-5ec7-482f-bdd0-3b7f757c4b50", "Class type", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5a51d21e-5a17-4dc1-b892-e1abf27f92c4" },
                    { "88aff19b-1eb3-49cc-a531-2589875c5900", "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5a51d21e-5a17-4dc1-b892-e1abf27f92c4" },
                    { "9406536a-b102-4f99-b6e5-096a079e3bb0", "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "cf8d414b-0a84-4961-9049-52b6c1756047" },
                    { "0cb8e21f-468b-45a9-862c-d270cb781b34", "Server", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "cf8d414b-0a84-4961-9049-52b6c1756047" },
                    { "fb4ed8f5-bd3d-4a7e-ae96-bc7ea703334b", "Both, server and client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "cf8d414b-0a84-4961-9049-52b6c1756047" },
                    { "91361bde-fd1d-4dcb-8a42-62fa8ca924dd", "Browser", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "cf8d414b-0a84-4961-9049-52b6c1756047" },
                    { "fc5f46c4-769f-421c-b3f0-b8de6babcf63", "Synchronous", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "cf8d123f-0a84-4961-f029-12h6x1756047" },
                    { "4d7592d2-8f1d-405d-bef9-9f51e40f84ab", "Multi-threaded", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "cf8d123f-0a84-4961-f029-12h6x1756047" },
                    { "40a2d3f2-8bf8-4cd7-90c2-3f82843239b0", "Asynchronous", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "cf8d123f-0a84-4961-f029-12h6x1756047" },
                    { "25fc59e9-e0ad-4f7e-8641-9c29cf5a9131", "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "cf8d123f-0a84-4961-f029-12h6x1756047" },
                    { "e5230b4c-3aee-4558-943d-5801ab60b5e7", "Windows", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "692235e8-1fb5-449e-9d43-b1a807cf3ca6" },
                    { "fdcc795f-0ff8-43c5-9008-9847d78f556c", "Mac", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "692235e8-1fb5-449e-9d43-b1a807cf3ca6" },
                    { "b6e193de-e731-4790-af11-fcf08d3bcd1c", "Unix/Linux", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "692235e8-1fb5-449e-9d43-b1a807cf3ca6" },
                    { "10533958-cf56-4868-8103-785791835046", "Reference type", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5a51d21e-5a17-4dc1-b892-e1abf27f92c4" },
                    { "1351da42-0a07-4f08-8969-8fd3223de6cf", "All", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "73eddcbd-5964-4d2c-ab8d-85dd0d6ed6cd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestion_TestId",
                table: "TestQuestion",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_UserId",
                table: "Tests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "TestQuestion");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
