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
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(i => i.ProductImages)
                .WithOne(pi => pi.Image)
                .HasForeignKey(i => i.IdImage);

            builder
                .HasOne(i => i.Brand)
                .WithOne(b => b.Image)
                .HasForeignKey<Brand>(b => b.IdImage);

            builder
                .HasOne(i => i.Category)
                .WithOne(c => c.Image)
                .HasForeignKey<Category>(c => c.IdImage);
        }
    }
}
