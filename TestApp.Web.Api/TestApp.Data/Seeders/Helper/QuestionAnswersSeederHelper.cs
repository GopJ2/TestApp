﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Data.Entity.Tests;

namespace TestApp.Data.Seeders.Helper
{
    public static class QuestionAnswersSeederHelper
    {
        public static void GenerateAnswers(this ModelBuilder modelBuilder)
        {

            var answers = new List<TestAnswer>()
            {
                new TestAnswer { QuestionId = "3185b7d6-85b1-4866-8fe2-e287965b841f", AnswerText = "public static void Program()"},
                new TestAnswer { QuestionId = "3185b7d6-85b1-4866-8fe2-e287965b841f", AnswerText = "public static void Main()", IsCorrect = true},
                new TestAnswer { QuestionId = "3185b7d6-85b1-4866-8fe2-e287965b841f", AnswerText = "public static void main()"},
                new TestAnswer { QuestionId = "3185b7d6-85b1-4866-8fe2-e287965b841f", AnswerText = "None of the above" },
                new TestAnswer { QuestionId = "27669b19-c256-4065-a7b5-432bb44da2c7", AnswerText = "Int32"},
                new TestAnswer { QuestionId = "27669b19-c256-4065-a7b5-432bb44da2c7", AnswerText = "Double"},
                new TestAnswer { QuestionId = "27669b19-c256-4065-a7b5-432bb44da2c7", AnswerText = "Decimal"},
                new TestAnswer { QuestionId = "27669b19-c256-4065-a7b5-432bb44da2c7", AnswerText = "All the above",  IsCorrect = true },
                new TestAnswer { QuestionId = "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05", AnswerText = "String", IsCorrect = true},
                new TestAnswer { QuestionId = "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05", AnswerText = "Double"},
                new TestAnswer { QuestionId = "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05", AnswerText = "Long"},
                new TestAnswer { QuestionId = "b8ff191d-ccaa-4f3a-b447-acfc9ee7fc05", AnswerText = "All the above" },
                new TestAnswer { QuestionId = "0ad888e5-3db1-422c-a5bf-d3fede49a6d4", AnswerText = "It allows assignment of null to reference type."},
                new TestAnswer { QuestionId = "0ad888e5-3db1-422c-a5bf-d3fede49a6d4", AnswerText = "It allows assignment of null to value type.", IsCorrect = true},
                new TestAnswer { QuestionId = "0ad888e5-3db1-422c-a5bf-d3fede49a6d4", AnswerText = "It allows assignment of null to static class."},
                new TestAnswer { QuestionId = "0ad888e5-3db1-422c-a5bf-d3fede49a6d4", AnswerText = "None of the above" },
                new TestAnswer { QuestionId = "5a51d21e-5a17-4dc1-b892-e1abf27f92c4", AnswerText = "Reference type"},
                new TestAnswer { QuestionId = "5a51d21e-5a17-4dc1-b892-e1abf27f92c4", AnswerText = "Value type", IsCorrect = true},
                new TestAnswer { QuestionId = "5a51d21e-5a17-4dc1-b892-e1abf27f92c4", AnswerText = "Class type"},
                new TestAnswer { QuestionId = "5a51d21e-5a17-4dc1-b892-e1abf27f92c4", AnswerText = "None of the above" },
                new TestAnswer { QuestionId = "5e56ae65-891b-4f87-a5b1-37a9798b2e53", AnswerText = "Link-List Inner Query"},
                new TestAnswer { QuestionId = "5e56ae65-891b-4f87-a5b1-37a9798b2e53", AnswerText = "Language-Integrated Query", IsCorrect = true},
                new TestAnswer { QuestionId = "5e56ae65-891b-4f87-a5b1-37a9798b2e53", AnswerText = "Linked-Integrated Query"},
                new TestAnswer { QuestionId = "5e56ae65-891b-4f87-a5b1-37a9798b2e53", AnswerText = "Lazy Integration Query" },
                new TestAnswer { QuestionId = "59ecff8a-3952-48c0-870b-59db1f6b060a", AnswerText = "C# and F#"},
                new TestAnswer { QuestionId = "59ecff8a-3952-48c0-870b-59db1f6b060a", AnswerText = "VB and F#"},
                new TestAnswer { QuestionId = "59ecff8a-3952-48c0-870b-59db1f6b060a", AnswerText = "C# and VB", IsCorrect = true},
                new TestAnswer { QuestionId = "59ecff8a-3952-48c0-870b-59db1f6b060a", AnswerText = "All the above"},
                new TestAnswer { QuestionId = "698f456f-f913-4858-9be2-f5184bc5944a", AnswerText = "Object collection", IsCorrect = true},
                new TestAnswer { QuestionId = "698f456f-f913-4858-9be2-f5184bc5944a", AnswerText = "Double"},
                new TestAnswer { QuestionId = "698f456f-f913-4858-9be2-f5184bc5944a", AnswerText = "Long"},
                new TestAnswer { QuestionId = "698f456f-f913-4858-9be2-f5184bc5944a", AnswerText = "All the above" },
                new TestAnswer { QuestionId = "127d9f22-064a-4470-8b03-d7c4b85948ef", AnswerText = "LINQ API is a bunch of extension methods included in System.Linq.Enumerable and System.Linq.Queryable class.", IsCorrect = true},
                new TestAnswer { QuestionId = "127d9f22-064a-4470-8b03-d7c4b85948ef", AnswerText = "LINQ API is a bunch of abstract methods included in Enumerable and Queryable classes."},
                new TestAnswer { QuestionId = "127d9f22-064a-4470-8b03-d7c4b85948ef", AnswerText = "LINQ API is bunch of queries written in C# and VB."},
                new TestAnswer { QuestionId = "127d9f22-064a-4470-8b03-d7c4b85948ef", AnswerText = "None of the above" },
            };

            answers.ForEach(x => {
                x.Id = Guid.NewGuid().ToString();
                modelBuilder.Entity<TestAnswer>().HasData(x);
            });
        }
    }
}