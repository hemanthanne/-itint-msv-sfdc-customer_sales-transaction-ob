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
    public class SalesAccountUpsertQueryRepository : ISalesAccountUpsertQueryRepository
    {
        private readonly SalesAccountContext _context;

        public SalesAccountUpsertQueryRepository(SalesAccountContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Domain.Models.SalesAccountUpsert>> GetAllSalesAccount(CancellationToken cancellationToken)
        {
            return await _context.SalesAccountsUpsert.ToListAsync();
        }
    }
}
