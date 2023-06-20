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
    public class AccountEntityConfiguration : IEntityTypeConfiguration<Domain.Models.Account>
    {
        public void Configure(EntityTypeBuilder<Account> entity)
        {
            // Set the table name and schema for the SalesAccount entity.
            entity.ToTable("Account", "dbo");

            // Configure the mapping between SalesAccount properties and database columns.
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.OwnerId).HasColumnName("OwnerId");
            entity.Property(e => e.Lakeshore_Customer_Number__c).HasColumnName("Lakeshore_Customer_Number__c ");
            entity.Property(e => e.Billing_Status__c).HasColumnName("Billing_Status__c ");
            entity.Property(e => e.ParentId).HasColumnName("ParentId");
            entity.Property(e => e.MDR_PID__c).HasColumnName("MDR_PID__c");
            entity.Property(e => e.MDR_Parent_PID__c).HasColumnName("MDR_Parent_PID__c");
            entity.Property(e => e.MDR_Enrollment__c).HasColumnName("MDR_Enrollment__c");
            entity.Property(e => e.Flex_Space_Approx_YTD__c).HasColumnName("Flex_Space_Approx_YTD__c");
            entity.Property(e => e.Acct_Owner_IP__c).HasColumnName("Acct_Owner_IP__c");
            entity.Property(e => e.InfTod_Approx_YTD__c).HasColumnName("InfTod_Approx_YTD__c");
            entity.Property(e => e.Flex_Space_Approx_LYTD__c).HasColumnName("flex_Space_Approx_LYTD__c");
            entity.Property(e => e.Description).HasColumnName("Description");
        }
    }
}
