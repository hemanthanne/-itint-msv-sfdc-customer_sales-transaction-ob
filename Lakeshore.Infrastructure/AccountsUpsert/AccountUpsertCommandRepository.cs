using Lakeshore.Domain.AccountRepository;
using Lakeshore.Domain.Models;
using Lakeshore.Domain.SalesAccountRepository;
using Lakeshore.Infrastructure.EntityModelConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Infrastructure.Accounts
{
    public class AccountUpsertCommandRepository : IAccountUpsertCommandRepository
    {
        private readonly SalesAccountContext _context;

        public AccountUpsertCommandRepository(SalesAccountContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task Add(AccountUpsert account, CancellationToken cancellationToken)
        {
            _context.AccountUpsert.AddAsync(account, cancellationToken);

            return Task.CompletedTask;
        }

        public Task Update(AccountUpsert account, CancellationToken cancellationToken)
        {
            var accountNew = _context.AccountUpsert.Attach(account);
            accountNew.State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
