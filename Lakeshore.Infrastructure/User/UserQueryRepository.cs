using Lakeshore.Domain.UserRepository;
using Lakeshore.Infrastructure.EntityModelConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Infrastructure.User
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly SalesAccountContext _context;

        public UserQueryRepository(SalesAccountContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<string?> GetUserId(string email, CancellationToken cancellationToken)
        {
            return _context.User.FirstOrDefault(x => x.Email.Equals(email))?.Id;
        }
    }
}
