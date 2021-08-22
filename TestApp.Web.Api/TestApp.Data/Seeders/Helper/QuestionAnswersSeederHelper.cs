using Microsoft.EntityFrameworkCore;
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
                new TestAnswer { QuestionId = Guid.Parse("C3C83D8D-2B6A-4AFF-94B8-850C231155D3"), AnswerText = "public static void Program()"},
                new TestAnswer { QuestionId = Guid.Parse("C3C83D8D-2B6A-4AFF-94B8-850C231155D3"), AnswerText = "public static void Main()", IsCorrect = true},
                new TestAnswer { QuestionId = Guid.Parse("C3C83D8D-2B6A-4AFF-94B8-850C231155D3"), AnswerText = "public static void main()"},
                new TestAnswer { QuestionId = Guid.Parse("C3C83D8D-2B6A-4AFF-94B8-850C231155D3"), AnswerText = "None of the presented" },
                new TestAnswer { QuestionId = Guid.Parse("B3CE3B36-C636-47EE-A8F2-BE1D6457590E"), AnswerText = "Int32"},
                new TestAnswer { QuestionId = Guid.Parse("B3CE3B36-C636-47EE-A8F2-BE1D6457590E"), AnswerText = "Double"},
                new TestAnswer { QuestionId = Guid.Parse("B3CE3B36-C636-47EE-A8F2-BE1D6457590E"), AnswerText = "Decimal"},
                new TestAnswer { QuestionId = Guid.Parse("B3CE3B36-C636-47EE-A8F2-BE1D6457590E"), AnswerText = "All the above",  IsCorrect = true },
                new TestAnswer { QuestionId = Guid.Parse("92AEAA44-AC36-41B1-8C05-FEDB3D4984E1"), AnswerText = "String", IsCorrect = true},
                new TestAnswer { QuestionId = Guid.Parse("92AEAA44-AC36-41B1-8C05-FEDB3D4984E1"), AnswerText = "Double"},
                new TestAnswer { QuestionId = Guid.Parse("92AEAA44-AC36-41B1-8C05-FEDB3D4984E1"), AnswerText = "Long"},
                new TestAnswer { QuestionId = Guid.Parse("92AEAA44-AC36-41B1-8C05-FEDB3D4984E1"), AnswerText = "All the above" },
                new TestAnswer { QuestionId = Guid.Parse("8891F8A7-9BBC-4A47-A143-99721B2CDF9B"), AnswerText = "It allows assignment of null to reference type."},
                new TestAnswer { QuestionId = Guid.Parse("8891F8A7-9BBC-4A47-A143-99721B2CDF9B"), AnswerText = "It allows assignment of null to value type.", IsCorrect = true},
                new TestAnswer { QuestionId = Guid.Parse("8891F8A7-9BBC-4A47-A143-99721B2CDF9B"), AnswerText = "It allows assignment of null to static class."},
                new TestAnswer { QuestionId = Guid.Parse("8891F8A7-9BBC-4A47-A143-99721B2CDF9B"), AnswerText = "None of the above" },
                new TestAnswer { QuestionId = Guid.Parse("E264BFCD-71D2-4A66-9F29-0E04FE319B3D"), AnswerText = "Reference type"},
                new TestAnswer { QuestionId = Guid.Parse("E264BFCD-71D2-4A66-9F29-0E04FE319B3D"), AnswerText = "Value type", IsCorrect = true},
                new TestAnswer { QuestionId = Guid.Parse("E264BFCD-71D2-4A66-9F29-0E04FE319B3D"), AnswerText = "Class type"},
                new TestAnswer { QuestionId = Guid.Parse("E264BFCD-71D2-4A66-9F29-0E04FE319B3D"), AnswerText = "None of the above" },
                new TestAnswer { QuestionId = Guid.Parse("673BD0C7-18FA-4BFC-A85D-E328F998985C"), AnswerText = "Link-List Inner Query"},
                new TestAnswer { QuestionId = Guid.Parse("673BD0C7-18FA-4BFC-A85D-E328F998985C"), AnswerText = "Language-Integrated Query", IsCorrect = true},
                new TestAnswer { QuestionId = Guid.Parse("673BD0C7-18FA-4BFC-A85D-E328F998985C"), AnswerText = "Linked-Integrated Query"},
                new TestAnswer { QuestionId = Guid.Parse("673BD0C7-18FA-4BFC-A85D-E328F998985C"), AnswerText = "Lazy Integration Query" },
                new TestAnswer { QuestionId = Guid.Parse("85216C10-E07E-4737-95CE-6ECD3D31963C"), AnswerText = "C# and F#"},
                new TestAnswer { QuestionId = Guid.Parse("85216C10-E07E-4737-95CE-6ECD3D31963C"), AnswerText = "VB and F#"},
                new TestAnswer { QuestionId = Guid.Parse("85216C10-E07E-4737-95CE-6ECD3D31963C"), AnswerText = "C# and VB", IsCorrect = true},
                new TestAnswer { QuestionId = Guid.Parse("85216C10-E07E-4737-95CE-6ECD3D31963C"), AnswerText = "All the above"},
                new TestAnswer { QuestionId = Guid.Parse("5C705C54-7454-4607-9C96-7B42A64FDC15"), AnswerText = "Object collection", IsCorrect = true},
                new TestAnswer { QuestionId = Guid.Parse("5C705C54-7454-4607-9C96-7B42A64FDC15"), AnswerText = "Double"},
                new TestAnswer { QuestionId = Guid.Parse("5C705C54-7454-4607-9C96-7B42A64FDC15"), AnswerText = "Long"},
                new TestAnswer { QuestionId = Guid.Parse("5C705C54-7454-4607-9C96-7B42A64FDC15"), AnswerText = "All the above" },
                new TestAnswer { QuestionId = Guid.Parse("61164F2D-70E1-410E-B03A-21D78E00D008"), AnswerText = "LINQ API is a bunch of extension methods included in System.Linq.Enumerable and System.Linq.Queryable class.", IsCorrect = true},
                new TestAnswer { QuestionId = Guid.Parse("61164F2D-70E1-410E-B03A-21D78E00D008"), AnswerText = "LINQ API is a bunch of abstract methods included in Enumerable and Queryable classes."},
                new TestAnswer { QuestionId = Guid.Parse("61164F2D-70E1-410E-B03A-21D78E00D008"), AnswerText = "LINQ API is bunch of queries written in C# and VB."},
                new TestAnswer { QuestionId = Guid.Parse("61164F2D-70E1-410E-B03A-21D78E00D008"), AnswerText = "None of the above" },
                new TestAnswer { QuestionId = Guid.Parse("B77D774D-F697-4B01-89C1-214F0CCD9FB1"), AnswerText = "Client" },
                new TestAnswer { QuestionId = Guid.Parse("B77D774D-F697-4B01-89C1-214F0CCD9FB1"), AnswerText = "Server", IsCorrect = true },
                new TestAnswer { QuestionId = Guid.Parse("B77D774D-F697-4B01-89C1-214F0CCD9FB1"), AnswerText = "Both, server and client" },
                new TestAnswer { QuestionId = Guid.Parse("B77D774D-F697-4B01-89C1-214F0CCD9FB1"), AnswerText = "Browser" },
                new TestAnswer { QuestionId = Guid.Parse("DC5D66D9-589D-4C85-B8DD-218C405EEEF0"), AnswerText = "Synchronous" },
                new TestAnswer { QuestionId = Guid.Parse("DC5D66D9-589D-4C85-B8DD-218C405EEEF0"), AnswerText = "Multi-threaded" },
                new TestAnswer { QuestionId = Guid.Parse("DC5D66D9-589D-4C85-B8DD-218C405EEEF0"), AnswerText = "Asynchronous", IsCorrect = true },
                new TestAnswer { QuestionId = Guid.Parse("DC5D66D9-589D-4C85-B8DD-218C405EEEF0"), AnswerText = "None of the above" },
                new TestAnswer { QuestionId = Guid.Parse("D277EDEA-70B3-4F61-BF10-1E0B4CD61B36"), AnswerText = "Windows" },
                new TestAnswer { QuestionId = Guid.Parse("D277EDEA-70B3-4F61-BF10-1E0B4CD61B36"), AnswerText = "Mac" },
                new TestAnswer { QuestionId = Guid.Parse("D277EDEA-70B3-4F61-BF10-1E0B4CD61B36"), AnswerText = "Unix/Linux" },
                new TestAnswer { QuestionId = Guid.Parse("D277EDEA-70B3-4F61-BF10-1E0B4CD61B36"), AnswerText = "All", IsCorrect = true },
                new TestAnswer { QuestionId = Guid.Parse("14A8C8B4-9771-4A65-8471-87D106BDE29D"), AnswerText = "Testing node.js/JavaScript expressions", IsCorrect = true },
                new TestAnswer { QuestionId = Guid.Parse("14A8C8B4-9771-4A65-8471-87D106BDE29D"), AnswerText = "Executing browser’s JavaScript expressions." },
                new TestAnswer { QuestionId = Guid.Parse("14A8C8B4-9771-4A65-8471-87D106BDE29D"), AnswerText = "The preview of node.js application." },
                new TestAnswer { QuestionId = Guid.Parse("14A8C8B4-9771-4A65-8471-87D106BDE29D"), AnswerText = "None of the above." },
                new TestAnswer { QuestionId = Guid.Parse("7735C87D-6EB9-444F-9101-7E19C67D0E4D"), AnswerText = "True", IsCorrect = true },
                new TestAnswer { QuestionId = Guid.Parse("7735C87D-6EB9-444F-9101-7E19C67D0E4D"), AnswerText = "False" },
                new TestAnswer { QuestionId = Guid.Parse("480A2F8A-7A30-4B11-A77B-44DA6991978F"), AnswerText = "<JavaScript></JavaScript>" },
                new TestAnswer { QuestionId = Guid.Parse("480A2F8A-7A30-4B11-A77B-44DA6991978F"), AnswerText = "<script></script>", IsCorrect = true },
                new TestAnswer { QuestionId = Guid.Parse("480A2F8A-7A30-4B11-A77B-44DA6991978F"), AnswerText = "<code></code>" },
                new TestAnswer { QuestionId = Guid.Parse("480A2F8A-7A30-4B11-A77B-44DA6991978F"), AnswerText = "<head></head>" },
                new TestAnswer { QuestionId = Guid.Parse("F95B3F73-DD10-4210-B049-2F85F90F462E"), AnswerText = "new" },
                new TestAnswer { QuestionId = Guid.Parse("F95B3F73-DD10-4210-B049-2F85F90F462E"), AnswerText = "int" },
                new TestAnswer { QuestionId = Guid.Parse("F95B3F73-DD10-4210-B049-2F85F90F462E"), AnswerText = "string" },
                new TestAnswer { QuestionId = Guid.Parse("F95B3F73-DD10-4210-B049-2F85F90F462E"), AnswerText = "let/const", IsCorrect = true },
                new TestAnswer { QuestionId = Guid.Parse("27D793C6-A03E-40F0-A998-F9F147009247"), AnswerText = "String" },
                new TestAnswer { QuestionId = Guid.Parse("27D793C6-A03E-40F0-A998-F9F147009247"), AnswerText = "Number" },
                new TestAnswer { QuestionId = Guid.Parse("27D793C6-A03E-40F0-A998-F9F147009247"), AnswerText = "Boolean" },
                new TestAnswer { QuestionId = Guid.Parse("27D793C6-A03E-40F0-A998-F9F147009247"), AnswerText = "All", IsCorrect = true },
            };

            answers.ForEach(x => {
                x.Id = Guid.NewGuid();
                modelBuilder.Entity<TestAnswer>().HasData(x);
            });
        }
    }
}
