using Lakeshore.Domain.AccountRepository;
using Lakeshore.Domain.Models;
using Lakeshore.Infrastructure.EntityModelConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Infrastructure.Accounts
{
    public class AccountQueryRepository : IAccountQueryRepository
    {
        private readonly SalesAccountContext _context;

        public AccountQueryRepository(SalesAccountContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Account>> GetAllAccount(CancellationToken cancellationToken)
        {
            return await _context.Account.ToListAsync();
        }
    }
}
