//using Lakeshore.Domain.Models.Views;
using Lakeshore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Infrastructure.EntityModelConfiguration
{
    public class SalesAccountContext : DbContext
    {
        public SalesAccountContext(DbContextOptions<SalesAccountContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public virtual DbSet<Domain.Models.SalesAccountUpsert> SalesAccountsUpsert { get; set; }
        public virtual DbSet<Domain.Models.AccountUpsert> AccountUpsert { get; set; }
        public virtual DbSet<Domain.Models.SalesAccount> SalesAccount { get; set; }
        public virtual DbSet<Domain.Models.Account> Account { get; set; }
        public virtual DbSet<Domain.Models.User> User { get; set; }
        public virtual DbSet<Domain.Models.RecordType> RecordType { get; set; }
    }
}
