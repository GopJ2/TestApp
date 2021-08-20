using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApp.Data.Migrations
{
    public partial class InitDatabase : Migration
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
                columns: new[] { "Id", "CreatedAt", "Description", "UserId" },
                values: new object[] { "91b1aa6d-bd4a-43e0-ad89-e672709e35fe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample LINQ Tests", "ce40ea29-e665-4a37-858b-e7d2359cdd4f" });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "CreatedAt", "Description", "UserId" },
                values: new object[] { "f14f0184-0b15-431f-b4e3-853224eed6dd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample C# Tests", "a8a4828c-60f0-4f99-bbe6-229df1d098a2" });

            migrationBuilder.InsertData(
                table: "TestQuestion",
                columns: new[] { "Id", "CreatedAt", "QuestionText", "TestId" },
                values: new object[,]
                {
                    { "5e56ae65-891b-4f87-a5b1-37a9798b2e53", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The full form of LINQ is _______.", "91b1aa6d-bd4a-43e0-ad89-e672709e35fe" },
                    { "59ecff8a-3952-48c0-870b-59db1f6b060a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LINQ supports ________ syntax.", "91b1aa6d-bd4a-43e0-ad89-e672709e35fe" },
                    { "698f456f-f913-4858-9be2-f5184bc5944a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the following supports LINQ queries?", "91b1aa6d-bd4a-43e0-ad89-e672709e35fe" },
                    { "127d9f22-064a-4470-8b03-d7c4b85948ef", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the following statement is TRUE?", "91b1aa6d-bd4a-43e0-ad89-e672709e35fe" },
                    { "3185b7d6-85b1-4866-8fe2-e287965b841f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the following methods is an entry point in the C# console program?", "f14f0184-0b15-431f-b4e3-853224eed6dd" },
                    { "27669b19-c256-4065-a7b5-432bb44da2c7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the followings are value types in C#?", "f14f0184-0b15-431f-b4e3-853224eed6dd" },
                    { "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Which of the following is a reference type in C#?", "f14f0184-0b15-431f-b4e3-853224eed6dd" },
                    { "0ad888e5-3db1-422c-a5bf-d3fede49a6d4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "What is the nullable type in C#?", "f14f0184-0b15-431f-b4e3-853224eed6dd" },
                    { "5a51d21e-5a17-4dc1-b892-e1abf27f92c4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Struct is a _____.", "f14f0184-0b15-431f-b4e3-853224eed6dd" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerText", "CreatedAt", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { "2d4a85cc-4b52-464e-b98d-a629d4b7a15a", "Link-List Inner Query", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5e56ae65-891b-4f87-a5b1-37a9798b2e53" },
                    { "acb0bcf9-42c5-4bee-8228-28264373c9dc", "Int32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "27669b19-c256-4065-a7b5-432bb44da2c7" },
                    { "d13aff12-4437-47ed-9478-fdaa7bdfcb5c", "Double", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "27669b19-c256-4065-a7b5-432bb44da2c7" },
                    { "85e27706-0d0c-4dfb-a6eb-57887f45fe3e", "Decimal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "27669b19-c256-4065-a7b5-432bb44da2c7" },
                    { "67748d96-0cd2-480d-a9a9-601a7ff2afe4", "All the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "27669b19-c256-4065-a7b5-432bb44da2c7" },
                    { "e3c2b7a7-3639-4a99-bb10-b0fbfb4e113b", "String", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05" },
                    { "dc6ca413-1835-4e48-a199-f2ae1336cc38", "Double", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05" },
                    { "5ca07b23-5dca-434f-808d-43de8d309f05", "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "3185b7d6-85b1-4866-8fe2-e287965b841f" },
                    { "091e92e6-2f8b-4883-bfbd-95a1f828825a", "Long", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05" },
                    { "0d9e40e8-e6e2-4d8a-b220-54f3c6194088", "It allows assignment of null to reference type.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "0ad888e5-3db1-422c-a5bf-d3fede49a6d4" },
                    { "b52e84f5-66ca-4eec-b598-e25d611eec41", "It allows assignment of null to value type.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "0ad888e5-3db1-422c-a5bf-d3fede49a6d4" },
                    { "e76aea45-9c3c-4881-a09b-3cb15f1686f5", "It allows assignment of null to static class.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "0ad888e5-3db1-422c-a5bf-d3fede49a6d4" },
                    { "cd67e410-6e6b-47be-8f40-cb4986b513ae", "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "0ad888e5-3db1-422c-a5bf-d3fede49a6d4" },
                    { "f3a1e79f-012a-4a4a-8dd4-1043a04461c1", "Reference type", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5a51d21e-5a17-4dc1-b892-e1abf27f92c4" },
                    { "f73bd6a2-63f9-40ab-80fc-2068e39b2f4a", "Value type", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "5a51d21e-5a17-4dc1-b892-e1abf27f92c4" },
                    { "a98bf1c7-da3c-4ac1-bbd0-456b1cc5f6c7", "All the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05" },
                    { "8f7c88df-cb57-4645-bc3a-0507a760de1a", "public static void main()", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "3185b7d6-85b1-4866-8fe2-e287965b841f" },
                    { "39b5135e-661c-4ebb-8853-8240f9389264", "public static void Main()", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "3185b7d6-85b1-4866-8fe2-e287965b841f" },
                    { "683ede9f-0a9f-4925-b3ba-ef36e92bcc97", "public static void Program()", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "3185b7d6-85b1-4866-8fe2-e287965b841f" },
                    { "04c0fd32-1faa-46ba-be34-26ff3b366907", "Language-Integrated Query", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "5e56ae65-891b-4f87-a5b1-37a9798b2e53" },
                    { "0851b621-1f32-4830-bb40-97f6abf3c99a", "Linked-Integrated Query", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5e56ae65-891b-4f87-a5b1-37a9798b2e53" },
                    { "552f785c-ea77-4e59-9663-79554c1b3264", "Lazy Integration Query", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5e56ae65-891b-4f87-a5b1-37a9798b2e53" },
                    { "b7fe413e-71ef-4888-b143-6248234b9c37", "C# and F#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "59ecff8a-3952-48c0-870b-59db1f6b060a" },
                    { "43382414-dafc-4ab6-9e52-285b181bb4c1", "VB and F#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "59ecff8a-3952-48c0-870b-59db1f6b060a" },
                    { "d08efed2-5d0e-44d9-9062-251a19ef7981", "C# and VB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "59ecff8a-3952-48c0-870b-59db1f6b060a" },
                    { "7e1f1422-bf51-46fc-9d31-adc13a27a945", "All the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "59ecff8a-3952-48c0-870b-59db1f6b060a" },
                    { "70a3595e-c50d-435a-8156-8966e222ddf0", "Object collection", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "698f456f-f913-4858-9be2-f5184bc5944a" },
                    { "80ddb8a6-e75e-4002-a6ab-7463493cce0c", "Double", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "698f456f-f913-4858-9be2-f5184bc5944a" },
                    { "0fa7b141-e3d7-4684-b728-f00c38358d01", "Long", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "698f456f-f913-4858-9be2-f5184bc5944a" },
                    { "21117ef6-eb49-4909-8e62-418e4e7183d4", "All the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "698f456f-f913-4858-9be2-f5184bc5944a" },
                    { "116f112a-6594-4077-99fe-36ae33664b6d", "LINQ API is a bunch of extension methods included in System.Linq.Enumerable and System.Linq.Queryable class.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "127d9f22-064a-4470-8b03-d7c4b85948ef" },
                    { "1abba0fa-9d99-4b73-9a6d-1de7bd5b09c3", "LINQ API is a bunch of abstract methods included in Enumerable and Queryable classes.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "127d9f22-064a-4470-8b03-d7c4b85948ef" },
                    { "0728a87e-0324-4700-aab1-6a2a6367427b", "LINQ API is bunch of queries written in C# and VB.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "127d9f22-064a-4470-8b03-d7c4b85948ef" },
                    { "a1848660-c2da-4367-b30b-c704bfa1a3aa", "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "127d9f22-064a-4470-8b03-d7c4b85948ef" },
                    { "3dd30000-c984-4da2-853e-50883ec57511", "Class type", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5a51d21e-5a17-4dc1-b892-e1abf27f92c4" },
                    { "b787046b-927d-4f7c-9fee-755493309ded", "None of the above", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5a51d21e-5a17-4dc1-b892-e1abf27f92c4" }
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
