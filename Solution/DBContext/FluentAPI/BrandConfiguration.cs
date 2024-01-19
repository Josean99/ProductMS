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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(b => b.Image)
                .WithOne(i => i.Brand)
                .HasForeignKey<Brand>(b => b.IdImage);

            builder
                .HasMany(b => b.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(b => b.IdBrand);
        }
    }
}
