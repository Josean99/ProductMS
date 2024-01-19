using EntityService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContext.FluentAPI
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(c => c.Image)
                .WithOne(i => i.Category)
                .HasForeignKey<Category>(c => c.IdImage);

            builder
                .HasOne(c => c.FatherCategory)
                .WithMany(fc => fc.SonCategories)
                .HasForeignKey(c => c.IdFatherCategory)
                .IsRequired(false);

            builder
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(c => c.IdCategory);
        }
    }
}
