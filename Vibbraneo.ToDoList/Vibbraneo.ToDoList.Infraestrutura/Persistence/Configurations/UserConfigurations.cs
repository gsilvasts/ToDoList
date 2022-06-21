using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vibbraneo.ToDoList.Domain.Entities;

namespace Vibbraneo.ToDoList.Infraestrutura.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(200);

            builder
                .Property(x => x.UserName)
                .HasMaxLength(100);

            builder
                .Property(x => x.Password)
                .HasMaxLength(200);

            builder
                .Property(x => x.Email)
                .HasMaxLength(200);
        }
    }
}
