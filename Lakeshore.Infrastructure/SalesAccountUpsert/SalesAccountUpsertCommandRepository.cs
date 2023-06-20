using Lakeshore.Domain.SalesAccountRepository;
using Lakeshore.Infrastructure.EntityModelConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Infrastructure.SalesAccount
{
    public class SalesAccountUpsertCommandRepository : ISalesAccountUpsertCommandRepository
    {
        private readonly SalesAccountContext _context;

        public SalesAccountUpsertCommandRepository(SalesAccountContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task Add(Domain.Models.SalesAccountUpsert salesAccount, CancellationToken cancellationToken)
        {
            _context.SalesAccountsUpsert.AddAsync(salesAccount, cancellationToken);

            return Task.CompletedTask;
        }

        public Task Update(Domain.Models.SalesAccountUpsert salesAccount, CancellationToken cancellationToken)
        {
            var salesAccountNew = _context.SalesAccountsUpsert.Attach(salesAccount);
            salesAccountNew.State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
