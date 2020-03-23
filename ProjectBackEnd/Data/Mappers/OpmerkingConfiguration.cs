using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Data.Mappers
{
    public class OpmerkingConfiguration : IEntityTypeConfiguration<Opmerking>
    {
        public void Configure(EntityTypeBuilder<Opmerking> builder)
        {
            builder.ToTable("Opmerking");
            builder.HasKey(q => q.Id);
        }
    }
}
