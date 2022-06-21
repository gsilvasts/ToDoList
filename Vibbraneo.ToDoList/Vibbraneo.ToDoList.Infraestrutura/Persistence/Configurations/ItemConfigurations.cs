using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vibbraneo.ToDoList.Domain.Entities;

namespace Vibbraneo.ToDoList.Infraestrutura.Persistence.Configurations
{
    public class ItemConfigurations : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Items)
                .WithOne()
                .IsRequired(false)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(x => x.User)
               .WithMany()
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(200);

            builder
                .Property(x => x.ItemId)
                .IsRequired(false);

        }
    }
}
