using Lakeshore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Domain.SalesAccountRepository
{
    public interface ISalesAccountUpsertQueryRepository
    {
        Task<List<SalesAccountUpsert>> GetAllSalesAccount(CancellationToken cancellationToken);
    }
}
