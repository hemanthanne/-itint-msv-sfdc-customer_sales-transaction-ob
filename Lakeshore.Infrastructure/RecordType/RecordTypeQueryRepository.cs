using Lakeshore.Domain.RecordTypeRepository;
using Lakeshore.Infrastructure.EntityModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Infrastructure.RecordType
{
    public class RecordTypeQueryRepository : IRecordTypeQueryRepository
    {
        private readonly SalesAccountContext _context;

        public RecordTypeQueryRepository(SalesAccountContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<string?> RecordTypeId(string developerName, CancellationToken cancellationToken)
        {
            return _context.RecordType.FirstOrDefault(x => x.DeveloperName.Equals(developerName))?.Id;
        }
    }
}
