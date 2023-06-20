using Lakeshore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Domain.AccountRepository
{
    public interface IAccountUpsertCommandRepository
    {
        Task Update(AccountUpsert account, CancellationToken cancellationToken);

        Task Add(AccountUpsert account, CancellationToken cancellationToken);
    }
}
