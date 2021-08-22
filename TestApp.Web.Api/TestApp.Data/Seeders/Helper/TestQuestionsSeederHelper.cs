using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Data.Entity.Tests;

namespace TestApp.Data.Seeders.Helper
{
    public static class TestQuestionsSeederHelper
    {
        public static void GenerateQuestions(this ModelBuilder modelBuilder)
        {
            var questions = new List<TestQuestion>
            {
                new TestQuestion
                {
                    Id = Guid.Parse("C3C83D8D-2B6A-4AFF-94B8-850C231155D3"),
                    TestId = Guid.Parse("f14f0184-0b15-431f-b4e3-853224eed6dd"),
                    QuestionText = "Which of the following methods is an entry point in the C# console program?"
                },
                new TestQuestion
                {
                    Id = Guid.Parse("B3CE3B36-C636-47EE-A8F2-BE1D6457590E"),
                    TestId = Guid.Parse("f14f0184-0b15-431f-b4e3-853224eed6dd"),
                    QuestionText = "Which of the followings are value types in C#?",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("92AEAA44-AC36-41B1-8C05-FEDB3D4984E1"),
                    TestId = Guid.Parse("f14f0184-0b15-431f-b4e3-853224eed6dd"),
                    QuestionText = "Which of the following is a reference type in C#?",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("8891F8A7-9BBC-4A47-A143-99721B2CDF9B"),
                    TestId = Guid.Parse("f14f0184-0b15-431f-b4e3-853224eed6dd"),
                    QuestionText = "What is the nullable type in C#?",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("E264BFCD-71D2-4A66-9F29-0E04FE319B3D"),
                    TestId = Guid.Parse("f14f0184-0b15-431f-b4e3-853224eed6dd"),
                    QuestionText = "Struct is a _____.",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("673BD0C7-18FA-4BFC-A85D-E328F998985C"),
                    TestId = Guid.Parse("91b1aa6d-bd4a-43e0-ad89-e672709e35fe"),
                    QuestionText = "The full form of LINQ is _______.",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("85216C10-E07E-4737-95CE-6ECD3D31963C"),
                    TestId = Guid.Parse("91b1aa6d-bd4a-43e0-ad89-e672709e35fe"),
                    QuestionText = "LINQ supports ________ syntax.",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("5C705C54-7454-4607-9C96-7B42A64FDC15"),
                    TestId = Guid.Parse("91b1aa6d-bd4a-43e0-ad89-e672709e35fe"),
                    QuestionText = "Which of the following supports LINQ queries?",

                },
                new TestQuestion
                {
                    Id = Guid.Parse("61164F2D-70E1-410E-B03A-21D78E00D008"),
                    TestId = Guid.Parse("91b1aa6d-bd4a-43e0-ad89-e672709e35fe"),
                    QuestionText = "Which of the following statement is TRUE?",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("B77D774D-F697-4B01-89C1-214F0CCD9FB1"),
                    TestId = Guid.Parse("b5902bf9-bea2-4fac-96bc-52c0ed52e6c7"),
                    QuestionText = "Node.js runs on __________",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("DC5D66D9-589D-4C85-B8DD-218C405EEEF0"),
                    TestId = Guid.Parse("b5902bf9-bea2-4fac-96bc-52c0ed52e6c7"),
                    QuestionText = "Node.js is ________ by default.",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("D277EDEA-70B3-4F61-BF10-1E0B4CD61B36"),
                    TestId = Guid.Parse("b5902bf9-bea2-4fac-96bc-52c0ed52e6c7"),
                    QuestionText = "Node.js supports which of the following platform?",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("14A8C8B4-9771-4A65-8471-87D106BDE29D"),
                    TestId = Guid.Parse("b5902bf9-bea2-4fac-96bc-52c0ed52e6c7"),
                    QuestionText = "Node.js terminal (REPL) is used for _________.",
                },

                new TestQuestion
                {
                    Id = Guid.Parse("7735C87D-6EB9-444F-9101-7E19C67D0E4D"),
                    TestId = Guid.Parse("c23f9ea6-50a9-417c-89bb-15194cc2787b"),
                    QuestionText = "JavaScript is ECMAScript",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("480A2F8A-7A30-4B11-A77B-44DA6991978F"),
                    TestId = Guid.Parse("c23f9ea6-50a9-417c-89bb-15194cc2787b"),
                    QuestionText = "JavaScript written under which of the following tag?",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("F95B3F73-DD10-4210-B049-2F85F90F462E"),
                    TestId = Guid.Parse("c23f9ea6-50a9-417c-89bb-15194cc2787b"),
                    QuestionText = "A variable in JavaScript declared with which of the following keyword?",
                },
                new TestQuestion
                {
                    Id = Guid.Parse("27D793C6-A03E-40F0-A998-F9F147009247"),
                    TestId = Guid.Parse("c23f9ea6-50a9-417c-89bb-15194cc2787b"),
                    QuestionText = "Which of the followings are primitive data types in JavaScript?",
                },
            };

            questions.ForEach(x => modelBuilder.Entity<TestQuestion>().HasData(x));
        }
    }
}
