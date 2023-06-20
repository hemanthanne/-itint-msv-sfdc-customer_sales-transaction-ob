using Lakeshore.Domain.AccountRepository;
using Lakeshore.Domain.Models;
using Lakeshore.Infrastructure.EntityModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Lakeshore.Infrastructure.Accounts
{
    public class AccountUpsertQueryRepository : IAccountUpsertQueryRepository
    {
        private readonly SalesAccountContext _context;

        public AccountUpsertQueryRepository(SalesAccountContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<AccountUpsert>> GetAllAccountUpsert(CancellationToken cancellationToken)
        {
            return await _context.AccountUpsert.ToListAsync();
        }
    }
}
