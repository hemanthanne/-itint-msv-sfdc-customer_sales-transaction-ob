using Lakeshore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Domain.AccountRepository
{
    public interface IAccountUpsertQueryRepository
    {
        Task<List<AccountUpsert>> GetAllAccountUpsert(CancellationToken cancellationToken);
    }
}
