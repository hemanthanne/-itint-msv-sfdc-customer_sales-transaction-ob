using Lakeshore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Domain.UserRepository
{
    public interface IUserQueryRepository
    {
        Task<string?> GetUserId(string email,CancellationToken cancellationToken);
    }
}
