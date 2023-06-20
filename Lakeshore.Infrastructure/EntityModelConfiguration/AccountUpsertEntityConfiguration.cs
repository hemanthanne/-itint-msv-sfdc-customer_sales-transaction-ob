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
    public class AccountUpsertEntityConfiguration : IEntityTypeConfiguration<AccountUpsert>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.AccountUpsert> entity)
        {
            // Set the table name and schema for the Account entity.
            entity.ToTable("Account_Upsert", "dbo");

            // Configure the mapping between SalesAccount properties and database columns.
            entity.Property(e => e.AccountNumber).HasColumnName("AccountNumber");
            entity.Property(e => e.Billing_Status__c).HasColumnName("Billing_Status__c"); 
            entity.Property(e => e.BillingCity).HasColumnName("BillingCity");
            entity.Property(e => e.BillingCountry).HasColumnName("BillingCountry");
            entity.Property(e => e.BillingPostalCode).HasColumnName("BillingPostalCode");
            entity.Property(e => e.BillingState).HasColumnName("BillingState");
            entity.Property(e => e.BillingStreet).HasColumnName("BillingStreet");
            entity.Property(e => e.Billing_County__c).HasColumnName("Billing_County__c");
            entity.Property(e => e.Shipping_County__c).HasColumnName("Shipping_County__c");
            entity.Property(e => e.Curr_MTD_Sales__c).HasColumnName("Curr_MTD_Sales__c");
            entity.Property(e => e.Curr_YTD_Sales__c).HasColumnName("Curr_YTD_Sales__c");
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Lakeshore_Customer_Number__c).HasColumnName("Lakeshore_Customer_Number__c");
            entity.Property(e => e.Llm_Territory_Number__c).HasColumnName("llm_Territory_Number__c");
            entity.Property(e => e.Name).HasColumnName("Name");
            entity.Property(e => e.OwnerId).HasColumnName("OwnerId");
            entity.Property(e => e.ParentId).HasColumnName("ParentId");
            entity.Property(e => e.Phone).HasColumnName("Phone");
            entity.Property(e => e.Previous_YCM_Sales__c).HasColumnName("Previous_YCM_Sales__c");
            entity.Property(e => e.Previous_Year_Sales__c).HasColumnName("Previous_Year_Sales__c");
            entity.Property(e => e.Previous_YTD_Sales__c).HasColumnName("Previous_YTD_Sales__c");
            entity.Property(e => e.RecordTypeId).HasColumnName("RecordTypeId");
            entity.Property(e => e.Rolling_Current_Year_Sales__c).HasColumnName("Rolling_Current_Year_Sales__c");
            entity.Property(e => e.Rolling_Previous_Year_Sales__c).HasColumnName("Rolling_Previous_Year_Sales__c");
            entity.Property(e => e.ShippingCity).HasColumnName("ShippingCity");
            entity.Property(e => e.ShippingCountry).HasColumnName("ShippingCountry");
            entity.Property(e => e.ShippingPostalCode).HasColumnName("ShippingPostalCode");
            entity.Property(e => e.ShippingState).HasColumnName("ShippingState");
            entity.Property(e => e.ShippingStreet).HasColumnName("ShippingStreet");
            entity.Property(e => e.Site).HasColumnName("Site");
            entity.Property(e => e.Type).HasColumnName("Type");
            entity.Property(e => e.Error).HasColumnName("Error");
            entity.Property(e => e.MDR_PID__c).HasColumnName("MDR_PID__c");
            entity.Property(e => e.MDR_Parent_PID__c).HasColumnName("MDR_Parent_PID__c");
            entity.Property(e => e.MDR_Enrollment__c).HasColumnName("MDR_Enrollment__c");
            entity.Property(e => e.Flex_Space_Approx_YTD__c).HasColumnName("Flex_Space_Approx_YTD__c");
            entity.Property(e => e.Acct_Owner_IP__c).HasColumnName("Acct_Owner_IP__c");
            entity.Property(e => e.InfTod_Approx_YTD__c).HasColumnName("InfTod_Approx_YTD__c");
            entity.Property(e => e.BT_Curr_MTD_Sales__c).HasColumnName("BT_Curr_MTD_Sales__c");
            entity.Property(e => e.BT_Curr_YTD_Sales__c).HasColumnName("BT_Curr_YTD_Sales__c");
            entity.Property(e => e.BT_Prev_MTD_Sales__c).HasColumnName("BT_Prev_MTD_Sales__c");
            entity.Property(e => e.BT_Prev_YTD_Sales__c).HasColumnName("BT_Prev_YTD_Sales__c");
            entity.Property(e => e.BT_Prev_Year_Sales__c).HasColumnName("BT_Prev_Year_Sales__c");
            entity.Property(e => e.BT_Rolling_Curr_Year_Sales__c).HasColumnName("BT_Rolling_Curr_Year_Sales__c");
            entity.Property(e => e.BT_Rolling_Prev_Year_Sales__c).HasColumnName("BT_Rolling_Prev_Year_Sales__c");
            entity.Property(e => e.Current_Quarter_to_Date_Sales__c).HasColumnName("Current_Quarter_to_Date_Sales__c");
            entity.Property(e => e.Current_Quarter_Previous_Year_Sales__c).HasColumnName("Current_Quarter_Previous_Year_Sales__c");
            entity.Property(e => e.Previous_Quarter_Previous_Year_Sales__c).HasColumnName("Previous_Quarter_Previous_Year_Sales__c");
            entity.Property(e => e.Previous_Quarter_Sales__c).HasColumnName("Previous_Quarter_Sales__c");
            entity.Property(e => e.Merch_Cert_Amount__c).HasColumnName("Merch_Cert_Amount__c");
            entity.Property(e => e.Merch_Cert_Accum__c).HasColumnName("Merch_Cert_Accum__c");
            entity.Property(e => e.Hard_Copy_of_PO__c).HasColumnName("Hard_Copy_of_PO__c");
            entity.Property(e => e.PO_Required__c).HasColumnName("PO_Required__c");
            entity.Property(e => e.ECustomer_c).HasColumnName("eCustomer__c");
            entity.Property(e => e.GSA_Account__c).HasColumnName("GSA_Account__c");
        }
    }
}
