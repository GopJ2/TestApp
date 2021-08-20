using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Data.Entity.Tests;

namespace TestApp.Data.Mappers
{
    class TestQuestionMapper : IEntityTypeConfiguration<TestQuestion>
    {
        public void Configure(EntityTypeBuilder<TestQuestion> builder)
        {
            builder.HasMany<TestAnswer>(x => x.Answers)
                .WithOne(q => q.Question)
                .HasForeignKey(q => q.QuestionId);
        }
    }
}
