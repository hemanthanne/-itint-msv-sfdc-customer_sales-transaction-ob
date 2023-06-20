using Lakeshore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Infrastructure.EntityModelConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<Domain.Models.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.User> entity)
        {
            // Set the table name and schema for the User entity.
            entity.ToTable("User", "dbo");

            // Configure the mapping between User properties and database columns.
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Email).HasColumnName("Email");
        }
    }
}
