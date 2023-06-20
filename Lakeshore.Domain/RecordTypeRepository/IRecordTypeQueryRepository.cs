using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Domain.RecordTypeRepository
{
    public interface IRecordTypeQueryRepository
    {
        Task<string?> RecordTypeId(string developerName, CancellationToken cancellationToken);
    }
}
