using Lakeshore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Domain.SalesAccountRepository
{
    public interface ISalesAccountUpsertCommandRepository
    {
        Task Update(SalesAccountUpsert hpt, CancellationToken cancellationToken);

        Task Add(SalesAccountUpsert hpt, CancellationToken cancellationToken);
    }
}
