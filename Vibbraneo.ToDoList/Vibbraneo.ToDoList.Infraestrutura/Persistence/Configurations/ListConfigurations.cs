using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vibbraneo.ToDoList.Domain.Entities;

namespace Vibbraneo.ToDoList.Infraestrutura.Persistence.Configurations
{
    public class ListConfigurations : IEntityTypeConfiguration<TaskList>
    {
        public void Configure(EntityTypeBuilder<TaskList> builder)
        {
            builder.ToTable("List");
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Items)
                .WithOne()
                .IsRequired()
                .HasForeignKey(x => x.ListId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(50);

            builder
                .Property(x => x.Description)
                .HasMaxLength(200);

        }
    }
}
