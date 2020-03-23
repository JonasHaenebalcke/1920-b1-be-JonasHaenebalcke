using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Data.Mappers
{
    public class AuteurConfiguration : IEntityTypeConfiguration<Auteur>
    {
        public void Configure(EntityTypeBuilder<Auteur> builder)
        {
            builder.ToTable("Auteur");
            builder.HasKey(q => q.Id);
        }
    }
}
