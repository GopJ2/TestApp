using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Data.Mappers
{
    public static class ModelBuilderConfig
    {
        public static void AddMappers(this ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfiguration(new UserMapper());
            modelBuilder.ApplyConfiguration(new TestsMapper());
            modelBuilder.ApplyConfiguration(new TestQuestionMapper());
        }
    }
}
