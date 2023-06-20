using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Infrastructure.EntityModelConfiguration
{
    public class SalesAccountEntityConfiguration : IEntityTypeConfiguration<Domain.Models.SalesAccount>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.SalesAccount> entity)
        {
            // Set the table name and schema for the SalesAccount entity.
            entity.ToTable("Account_Sales__c", "dbo");

            // Configure the mapping between SalesAccount properties and database columns.
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.OwnerId).HasColumnName("OwnerId");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted");
            entity.Property(e => e.Name).HasColumnName("Name");
            entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
            entity.Property(e => e.CreatedById).HasColumnName("CreatedById");
            entity.Property(e => e.LastModifiedDate).HasColumnName("LastModifiedDate");
            entity.Property(e => e.LastModifiedById).HasColumnName("LastModifiedById");
            entity.Property(e => e.SystemModstamp).HasColumnName("SystemModstamp");
            entity.Property(e => e.LastViewedDate).HasColumnName("LastViewedDate");
            entity.Property(e => e.LastReferencedDate).HasColumnName("LastReferencedDate");
            entity.Property(e => e.Acct_Cat_Territory__c).HasColumnName("Acct_Cat_Territory__c");
            entity.Property(e => e.Lakeshore_Customer_Number_del__c).HasColumnName("Lakeshore_Customer_Number_del__c");
            entity.Property(e => e.Territory__c).HasColumnName("Territory__c");
            entity.Property(e => e.MTD_Sales__c).HasColumnName("MTD_Sales__c");
            entity.Property(e => e.YTD_Sales__c).HasColumnName("YTD_Sales__c");
            entity.Property(e => e.Previous_Year_Current_Month__c).HasColumnName("Previous_Year_Current_Month__c");
            entity.Property(e => e.Previous_Year_To_Date__c).HasColumnName("Previous_Year_To_Date__c");
            entity.Property(e => e.Previous_Year_Sales__c).HasColumnName("Previous_Year_Sales__c");
            entity.Property(e => e.Account_ID__c).HasColumnName("Account_ID__c");
            entity.Property(e => e.Report_Month__c).HasColumnName("Report_Month__c");
            entity.Property(e => e.Rolling_Current_Year_Sales__c).HasColumnName("Rolling_Current_Year_Sales__c");
            entity.Property(e => e.Rolling_Previous_Year_Sales__c).HasColumnName("Rolling_Previous_Year_Sales__c");
            entity.Property(e => e.Catalog__c).HasColumnName("Catalog__c");
            entity.Property(e => e.Yearly_Percent_Diff__c).HasColumnName("Yearly_Percent_Diff__c");
            entity.Property(e => e.Monthly_Percent_Diff__c).HasColumnName("Monthly_Percent_Diff__c");
            entity.Property(e => e.Customer_Number__c).HasColumnName("Customer_Number__c");
            entity.Property(e => e.Last_Modified_Date__c).HasColumnName("Last_Modified_Date__c");
            entity.Property(e => e.Billing_Postal_Code__c).HasColumnName("Billing_Postal_Code__c");
            entity.Property(e => e.EAM_Zone__c).HasColumnName("EAM_Zone__c");
            entity.Property(e => e.zEAM_Visibility__c).HasColumnName("zEAM_Visibility__c");
        }
    }
}
