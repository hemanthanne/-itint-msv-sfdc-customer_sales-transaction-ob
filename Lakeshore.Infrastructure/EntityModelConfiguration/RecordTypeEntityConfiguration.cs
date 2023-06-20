using Lakeshore.Domain;
using Lakeshore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Infrastructure.EntityModelConfiguration
{
    public class RecordTypeEntityConfiguration : IEntityTypeConfiguration<Domain.Models.RecordType>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.RecordType> entity)
        {
            // Set the table name and schema for the RecordType entity.
            entity.ToTable("RecordType", "dbo");

            // Configure the mapping between User properties and database columns.
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.DeveloperName).HasColumnName("DeveloperName");
        }
    }
}
