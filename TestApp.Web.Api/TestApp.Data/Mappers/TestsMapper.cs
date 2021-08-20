using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Data.Entity.Tests;

namespace TestApp.Data.Mappers
{
    class TestsMapper : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasMany<TestQuestion>(x => x.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(q => q.TestId);
        }
    }
}
