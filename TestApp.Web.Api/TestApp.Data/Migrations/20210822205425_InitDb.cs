using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApp.Data.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestQuestions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_TestQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "TestQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "Password" },
                values: new object[] { new Guid("ce40ea29-e665-4a37-858b-e7d2359cdd4f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestUser@gmail.com", "yP7xXNBu/Hny3XSz7QCNjOgkM7HOkPgVFiXTPr5dwTg=" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "Password" },
                values: new object[] { new Guid("a8a4828c-60f0-4f99-bbe6-229df1d098a2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestUser2@gmail.com", "yP7xXNBu/Hny3XSz7QCNjOgkM7HOkPgVFiXTPr5dwTg=" });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("f14f0184-0b15-431f-b4e3-853224eed6dd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample C# Tests Description", "C# Test", new Guid("ce40ea29-e665-4a37-858b-e7d2359cdd4f") },
                    { new Guid("b5902bf9-bea2-4fac-96bc-52c0ed52e6c7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Node.js Tests", "Node.js Test", new Guid("ce40ea29-e665-4a37-858b-e7d2359cdd4f") },
                    { new Guid("91b1aa6d-bd4a-43e0-ad89-e672709e35fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample LINQ Tests", "LINQ Test", new Guid("a8a4828c-60f0-4f99-bbe6-229df1d098a2") },
                    { new Guid("c23f9ea6-50a9-417c-89bb-15194cc2787b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Javascript Tests", "Vanilla JS Test", new Guid("a8a4828c-60f0-4f99-bbe6-229df1d098a2") }
                });

            migrationBuilder.InsertData(
                table: "TestQuestions",
                columns: new[] { "Id", "CreatedAt", "QuestionText", "TestId" },
                values: new object[,]
                {
                    { new Guid("c3c83d8d-2b6a-4aff-94b8-850c231155d3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the following methods is an entry point in the C# console program?", new Guid("f14f0184-0b15-431f-b4e3-853224eed6dd") },
                    { new Guid("480a2f8a-7a30-4b11-a77b-44da6991978f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript written under which of the following tag?", new Guid("c23f9ea6-50a9-417c-89bb-15194cc2787b") },
                    { new Guid("7735c87d-6eb9-444f-9101-7e19c67d0e4d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript is ECMAScript", new Guid("c23f9ea6-50a9-417c-89bb-15194cc2787b") },
                    { new Guid("61164f2d-70e1-410e-b03a-21d78e00d008"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the following statement is TRUE?", new Guid("91b1aa6d-bd4a-43e0-ad89-e672709e35fe") },
                    { new Guid("5c705c54-7454-4607-9c96-7b42a64fdc15"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the following supports LINQ queries?", new Guid("91b1aa6d-bd4a-43e0-ad89-e672709e35fe") },
                    { new Guid("85216c10-e07e-4737-95ce-6ecd3d31963c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LINQ supports ________ syntax.", new Guid("91b1aa6d-bd4a-43e0-ad89-e672709e35fe") },
                    { new Guid("673bd0c7-18fa-4bfc-a85d-e328f998985c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The full form of LINQ is _______.", new Guid("91b1aa6d-bd4a-43e0-ad89-e672709e35fe") },
                    { new Guid("f95b3f73-dd10-4210-b049-2f85f90f462e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A variable in JavaScript declared with which of the following keyword?", new Guid("c23f9ea6-50a9-417c-89bb-15194cc2787b") },
                    { new Guid("14a8c8b4-9771-4a65-8471-87d106bde29d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Node.js terminal (REPL) is used for _________.", new Guid("b5902bf9-bea2-4fac-96bc-52c0ed52e6c7") },
                    { new Guid("dc5d66d9-589d-4c85-b8dd-218c405eeef0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Node.js is ________ by default.", new Guid("b5902bf9-bea2-4fac-96bc-52c0ed52e6c7") },
                    { new Guid("b77d774d-f697-4b01-89c1-214f0ccd9fb1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Node.js runs on __________", new Guid("b5902bf9-bea2-4fac-96bc-52c0ed52e6c7") },
                    { new Guid("e264bfcd-71d2-4a66-9f29-0e04fe319b3d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Struct is a _____.", new Guid("f14f0184-0b15-431f-b4e3-853224eed6dd") },
                    { new Guid("8891f8a7-9bbc-4a47-a143-99721b2cdf9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "What is the nullable type in C#?", new Guid("f14f0184-0b15-431f-b4e3-853224eed6dd") },
                    { new Guid("92aeaa44-ac36-41b1-8c05-fedb3d4984e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the following is a reference type in C#?", new Guid("f14f0184-0b15-431f-b4e3-853224eed6dd") },
                    { new Guid("b3ce3b36-c636-47ee-a8f2-be1d6457590e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the followings are value types in C#?", new Guid("f14f0184-0b15-431f-b4e3-853224eed6dd") },
                    { new Guid("d277edea-70b3-4f61-bf10-1e0b4cd61b36"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Node.js supports which of the following platform?", new Guid("b5902bf9-bea2-4fac-96bc-52c0ed52e6c7") },
                    { new Guid("27d793c6-a03e-40f0-a998-f9f147009247"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the followings are primitive data types in JavaScript?", new Guid("c23f9ea6-50a9-417c-89bb-15194cc2787b") }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerText", "CreatedAt", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("6f7e1f35-c0e9-4896-a111-ec7408fbb141"), "public static void Program()", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("c3c83d8d-2b6a-4aff-94b8-850c231155d3") },
                    { new Guid("0e797347-cb11-4bad-9417-5571e746d968"), "None of the above.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("14a8c8b4-9771-4a65-8471-87d106bde29d") },
                    { new Guid("81878b28-547e-42a1-b051-f71cd7dd7308"), "Link-List Inner Query", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("673bd0c7-18fa-4bfc-a85d-e328f998985c") },
                    { new Guid("e8024eb7-541f-44f8-ac97-3de2bb0d088a"), "Language-Integrated Query", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("673bd0c7-18fa-4bfc-a85d-e328f998985c") },
                    { new Guid("eb0e62cf-cb80-4455-bff1-c743217e6173"), "Linked-Integrated Query", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("673bd0c7-18fa-4bfc-a85d-e328f998985c") },
                    { new Guid("e51d9f95-2614-4ac3-a429-28c90acbad5b"), "Lazy Integration Query", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("673bd0c7-18fa-4bfc-a85d-e328f998985c") },
                    { new Guid("eaf7838e-1003-4d24-8e64-e0f35451eec3"), "C# and F#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("85216c10-e07e-4737-95ce-6ecd3d31963c") },
                    { new Guid("7b3ea024-2cec-4579-a6bf-403e9b25b314"), "VB and F#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("85216c10-e07e-4737-95ce-6ecd3d31963c") },
                    { new Guid("23659ead-2549-4860-b5aa-2c4ec047f0ac"), "C# and VB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("85216c10-e07e-4737-95ce-6ecd3d31963c") },
                    { new Guid("8bded336-4090-4944-a8fc-1b3d60eeb816"), "All the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("85216c10-e07e-4737-95ce-6ecd3d31963c") },
                    { new Guid("1729f838-9e58-475e-8284-b6bac932e881"), "Object collection", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("5c705c54-7454-4607-9c96-7b42a64fdc15") },
                    { new Guid("ec8cb4c6-fdeb-4632-9967-203d0ef2e6bf"), "Double", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("5c705c54-7454-4607-9c96-7b42a64fdc15") },
                    { new Guid("f42a1798-00b9-4988-a0ff-0fed9b2c817a"), "Long", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("5c705c54-7454-4607-9c96-7b42a64fdc15") },
                    { new Guid("768cca7f-d429-4af6-9a83-81f42b9c4132"), "All the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("5c705c54-7454-4607-9c96-7b42a64fdc15") },
                    { new Guid("cad1c9ca-5810-44e5-a835-5afa4bf29a13"), "LINQ API is a bunch of extension methods included in System.Linq.Enumerable and System.Linq.Queryable class.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("61164f2d-70e1-410e-b03a-21d78e00d008") },
                    { new Guid("0593f03b-94d8-4ef0-a2cf-2294910b14d4"), "LINQ API is a bunch of abstract methods included in Enumerable and Queryable classes.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("61164f2d-70e1-410e-b03a-21d78e00d008") },
                    { new Guid("485f32e3-bc29-4a82-a1c6-5fa777bb0afa"), "LINQ API is bunch of queries written in C# and VB.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("61164f2d-70e1-410e-b03a-21d78e00d008") },
                    { new Guid("18525932-8182-4736-82bf-25836ee8fb7c"), "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("61164f2d-70e1-410e-b03a-21d78e00d008") },
                    { new Guid("6593e507-9573-4107-ab71-7c5da704e80e"), "True", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("7735c87d-6eb9-444f-9101-7e19c67d0e4d") },
                    { new Guid("739461ec-7ffd-435d-8fab-43948a14e1ad"), "False", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("7735c87d-6eb9-444f-9101-7e19c67d0e4d") },
                    { new Guid("120eb6cf-4946-421b-84c0-a8603ab7968e"), "<JavaScript></JavaScript>", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("480a2f8a-7a30-4b11-a77b-44da6991978f") },
                    { new Guid("be9e0328-77c6-4ca0-a614-6fcea686ae62"), "<script></script>", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("480a2f8a-7a30-4b11-a77b-44da6991978f") },
                    { new Guid("b008d0ff-d28c-4778-9e91-0c1f4ded39ea"), "<code></code>", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("480a2f8a-7a30-4b11-a77b-44da6991978f") },
                    { new Guid("0222f55c-e5a0-4bba-b7a8-d9ccae31fa1f"), "<head></head>", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("480a2f8a-7a30-4b11-a77b-44da6991978f") },
                    { new Guid("b7edaa47-ba2d-46f8-a3ab-d7b7d3a15526"), "new", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("f95b3f73-dd10-4210-b049-2f85f90f462e") },
                    { new Guid("0f7da0eb-a6e2-4c41-bbee-b50cc854c7e6"), "int", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("f95b3f73-dd10-4210-b049-2f85f90f462e") },
                    { new Guid("8654d78f-4617-4a26-ac3e-c7ae3d6451a4"), "string", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("f95b3f73-dd10-4210-b049-2f85f90f462e") },
                    { new Guid("5c9a08f9-fe22-4870-8c1c-df9006c8b445"), "let/const", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("f95b3f73-dd10-4210-b049-2f85f90f462e") },
                    { new Guid("830f49a6-b92b-4eeb-bcc0-6f68004e619c"), "String", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("27d793c6-a03e-40f0-a998-f9f147009247") },
                    { new Guid("108cc96f-07cc-446d-b290-257cc2b634d1"), "Number", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("27d793c6-a03e-40f0-a998-f9f147009247") },
                    { new Guid("b6833840-6beb-4826-8835-6a4a7d830b21"), "The preview of node.js application.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("14a8c8b4-9771-4a65-8471-87d106bde29d") },
                    { new Guid("03c95302-a79e-4944-9746-3c0a88d42bde"), "Executing browser’s JavaScript expressions.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("14a8c8b4-9771-4a65-8471-87d106bde29d") },
                    { new Guid("25aecff5-9104-4fa0-a8e2-6b84b07d502f"), "Testing node.js/JavaScript expressions", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("14a8c8b4-9771-4a65-8471-87d106bde29d") },
                    { new Guid("11ed72ff-c54d-4734-9957-75f16d146da0"), "All", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("d277edea-70b3-4f61-bf10-1e0b4cd61b36") },
                    { new Guid("a69c5de4-c7d1-4a8f-8ad1-63afffc92814"), "public static void Main()", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("c3c83d8d-2b6a-4aff-94b8-850c231155d3") },
                    { new Guid("df60b121-e699-4619-9121-29b13557c969"), "public static void main()", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("c3c83d8d-2b6a-4aff-94b8-850c231155d3") },
                    { new Guid("bab69880-3e3c-4d18-a5c3-da80ec91f424"), "None of the presented", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("c3c83d8d-2b6a-4aff-94b8-850c231155d3") },
                    { new Guid("822ba52d-ce43-4627-8686-2a5fd20f69ef"), "Int32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("b3ce3b36-c636-47ee-a8f2-be1d6457590e") },
                    { new Guid("0b6408e9-e232-4199-a937-199bd6d379de"), "Double", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("b3ce3b36-c636-47ee-a8f2-be1d6457590e") },
                    { new Guid("ae4c57eb-ac49-49e4-bb3d-7b6d75d0e35f"), "Decimal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("b3ce3b36-c636-47ee-a8f2-be1d6457590e") },
                    { new Guid("45cec12f-5f6a-4aa0-bb2d-99262febad94"), "All the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("b3ce3b36-c636-47ee-a8f2-be1d6457590e") },
                    { new Guid("8a2a75ed-3804-4ac7-bfc4-b6b1fb26fb1b"), "String", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("92aeaa44-ac36-41b1-8c05-fedb3d4984e1") }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerText", "CreatedAt", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("ece4d187-f377-422e-bbe4-073004ef2856"), "Double", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("92aeaa44-ac36-41b1-8c05-fedb3d4984e1") },
                    { new Guid("ec933088-246a-41c6-8d0f-9664e9ef77d5"), "Long", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("92aeaa44-ac36-41b1-8c05-fedb3d4984e1") },
                    { new Guid("3854cf18-2df2-4cea-950a-87f3bc0079bf"), "All the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("92aeaa44-ac36-41b1-8c05-fedb3d4984e1") },
                    { new Guid("44fb38dd-b2ea-48ab-863b-c785c0ce0e30"), "It allows assignment of null to reference type.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("8891f8a7-9bbc-4a47-a143-99721b2cdf9b") },
                    { new Guid("14c780ee-6d60-4536-a111-ac606871ad73"), "It allows assignment of null to value type.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("8891f8a7-9bbc-4a47-a143-99721b2cdf9b") },
                    { new Guid("4f375080-95ec-415d-b959-e2aad06f0666"), "It allows assignment of null to static class.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("8891f8a7-9bbc-4a47-a143-99721b2cdf9b") },
                    { new Guid("660d9ff9-d5de-461b-8e1b-198f99b3c915"), "Boolean", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("27d793c6-a03e-40f0-a998-f9f147009247") },
                    { new Guid("9d0376a8-c448-45a0-8a11-f79e524d083e"), "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("8891f8a7-9bbc-4a47-a143-99721b2cdf9b") },
                    { new Guid("f7cf511f-c7c0-4fcd-9f1e-3e34ce6ee54d"), "Value type", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("e264bfcd-71d2-4a66-9f29-0e04fe319b3d") },
                    { new Guid("a6567315-34d0-4bc4-b572-651cf46b118e"), "Class type", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("e264bfcd-71d2-4a66-9f29-0e04fe319b3d") },
                    { new Guid("fe84c34b-747f-4e1e-80ab-7090c16d724e"), "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("e264bfcd-71d2-4a66-9f29-0e04fe319b3d") },
                    { new Guid("4da954ad-7308-4c0e-8ebd-4d75be0d4f22"), "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("b77d774d-f697-4b01-89c1-214f0ccd9fb1") },
                    { new Guid("9b063b12-3dcb-4359-baec-f505aab5196a"), "Server", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("b77d774d-f697-4b01-89c1-214f0ccd9fb1") },
                    { new Guid("9bd6b78a-fc61-4e13-8cb9-2da7c4e3fb3e"), "Both, server and client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("b77d774d-f697-4b01-89c1-214f0ccd9fb1") },
                    { new Guid("252f0ba5-82a1-4db6-a9fd-2b1654e8b714"), "Browser", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("b77d774d-f697-4b01-89c1-214f0ccd9fb1") },
                    { new Guid("535ae009-8f31-4171-b3a2-0679855b20e1"), "Synchronous", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("dc5d66d9-589d-4c85-b8dd-218c405eeef0") },
                    { new Guid("01c0a297-089f-4eeb-9a93-bb495a3a76e7"), "Multi-threaded", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("dc5d66d9-589d-4c85-b8dd-218c405eeef0") },
                    { new Guid("53b89961-2f90-45fe-91a9-804afd2d3688"), "Asynchronous", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("dc5d66d9-589d-4c85-b8dd-218c405eeef0") },
                    { new Guid("0423b563-e600-4c9a-ab7c-6273b0a10712"), "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("dc5d66d9-589d-4c85-b8dd-218c405eeef0") },
                    { new Guid("804fe3a2-5723-4eb9-96b0-1e66d4bff49a"), "Windows", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("d277edea-70b3-4f61-bf10-1e0b4cd61b36") },
                    { new Guid("6ca63fd5-cc34-4baa-a792-2476b2268c5e"), "Mac", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("d277edea-70b3-4f61-bf10-1e0b4cd61b36") },
                    { new Guid("7437e3ad-de5d-4edb-9dcc-1812d4bdb838"), "Unix/Linux", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("d277edea-70b3-4f61-bf10-1e0b4cd61b36") },
                    { new Guid("d7804de1-c878-4e97-8e73-e0037b23e96c"), "Reference type", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("e264bfcd-71d2-4a66-9f29-0e04fe319b3d") },
                    { new Guid("338fc9a9-e81e-4eb1-add0-2a2e2f723448"), "All", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("27d793c6-a03e-40f0-a998-f9f147009247") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_TestId",
                table: "TestQuestions",
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
                name: "TestQuestions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
