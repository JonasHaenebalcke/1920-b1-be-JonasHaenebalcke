using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectBackEnd.Models;

namespace ProjectBackEnd.Data.Mappers
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.ToTable("Quote");
            builder.HasKey(q => q.Id);

            builder.HasOne(q => q.Auteur)
                .WithMany(a => a.Quotes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(q => q.Opmerkingen)
                .WithOne(o => o.Quote)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
