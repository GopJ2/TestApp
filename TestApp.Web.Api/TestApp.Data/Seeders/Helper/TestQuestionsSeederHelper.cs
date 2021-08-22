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
                    Id = "3185b7d6-85b1-4866-8fe2-e287965b841f",
                    TestId = "f14f0184-0b15-431f-b4e3-853224eed6dd",
                    QuestionText = "Which of the following methods is an entry point in the C# console program?"
                },
                new TestQuestion
                {
                    Id = "27669b19-c256-4065-a7b5-432bb44da2c7",
                    TestId = "f14f0184-0b15-431f-b4e3-853224eed6dd",
                    QuestionText = "Which of the followings are value types in C#?",
                },
                new TestQuestion
                {
                    Id = "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05",
                    TestId = "f14f0184-0b15-431f-b4e3-853224eed6dd",
                    QuestionText = "Which of the following is a reference type in C#?",
                },
                new TestQuestion
                {
                    Id = "0ad888e5-3db1-422c-a5bf-d3fede49a6d4",
                    TestId = "f14f0184-0b15-431f-b4e3-853224eed6dd",
                    QuestionText = "What is the nullable type in C#?",
                },
                new TestQuestion
                {
                    Id = "5a51d21e-5a17-4dc1-b892-e1abf27f92c4",
                    TestId = "f14f0184-0b15-431f-b4e3-853224eed6dd",
                    QuestionText = "Struct is a _____.",
                },
                new TestQuestion
                {
                    Id = "5e56ae65-891b-4f87-a5b1-37a9798b2e53",
                    TestId = "91b1aa6d-bd4a-43e0-ad89-e672709e35fe",
                    QuestionText = "The full form of LINQ is _______.",
                },
                new TestQuestion
                {
                    Id = "59ecff8a-3952-48c0-870b-59db1f6b060a",
                    TestId = "91b1aa6d-bd4a-43e0-ad89-e672709e35fe",
                    QuestionText = "LINQ supports ________ syntax.",
                },
                new TestQuestion
                {
                    Id = "698f456f-f913-4858-9be2-f5184bc5944a",
                    TestId = "91b1aa6d-bd4a-43e0-ad89-e672709e35fe",
                    QuestionText = "Which of the following supports LINQ queries?",

                },
                new TestQuestion
                {
                    Id = "127d9f22-064a-4470-8b03-d7c4b85948ef",
                    TestId = "91b1aa6d-bd4a-43e0-ad89-e672709e35fe",
                    QuestionText = "Which of the following statement is TRUE?",
                },
                new TestQuestion
                {
                    Id = "cf8d414b-0a84-4961-9049-52b6c1756047",
                    TestId = "b5902bf9-bea2-4fac-96bc-52c0ed52e6c7",
                    QuestionText = "Node.js runs on __________",
                },
                new TestQuestion
                {
                    Id = "cf8d123f-0a84-4961-f029-12h6x1756047",
                    TestId = "b5902bf9-bea2-4fac-96bc-52c0ed52e6c7",
                    QuestionText = "Node.js is ________ by default.",
                },
                new TestQuestion
                {
                    Id = "692235e8-1fb5-449e-9d43-b1a807cf3ca6",
                    TestId = "b5902bf9-bea2-4fac-96bc-52c0ed52e6c7",
                    QuestionText = "Node.js supports which of the following platform?",
                },
                new TestQuestion
                {
                    Id = "0508062a-da04-4349-9832-113b1405cfff",
                    TestId = "b5902bf9-bea2-4fac-96bc-52c0ed52e6c7",
                    QuestionText = "Node.js terminal (REPL) is used for _________.",
                },

                new TestQuestion
                {
                    Id = "1834f0be-b24e-47cf-b609-d5c184cb6a02",
                    TestId = "c23f9ea6-50a9-417c-89bb-15194cc2787b",
                    QuestionText = "JavaScript is ECMAScript",
                }, 
                new TestQuestion
                {
                    Id = "b997c953-a860-4a0d-a403-ec689ff60d46",
                    TestId = "c23f9ea6-50a9-417c-89bb-15194cc2787b",
                    QuestionText = "JavaScript written under which of the following tag?",
                },
                new TestQuestion
                {
                    Id = "6b119880-12e5-4510-aa14-83a51f94adb6",
                    TestId = "c23f9ea6-50a9-417c-89bb-15194cc2787b",
                    QuestionText = "A variable in JavaScript declared with which of the following keyword?",
                },
                new TestQuestion
                {
                    Id = "73eddcbd-5964-4d2c-ab8d-85dd0d6ed6cd",
                    TestId = "c23f9ea6-50a9-417c-89bb-15194cc2787b",
                    QuestionText = "Which of the followings are primitive data types in JavaScript?",
                },
            };

            questions.ForEach(x => modelBuilder.Entity<TestQuestion>().HasData(x));
        }
    }
}
