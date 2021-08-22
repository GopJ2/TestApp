using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Data.Entity.Tests;
using TestApp.Data.Entity.Users;

namespace TestApp.Data.Mappers
{
    public class UserMapper : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //builder.HasIndex(x => x.Email).IsUnique();
            builder
                .HasMany<Test>(x => x.Tests)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
        }
    }
}
