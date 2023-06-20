using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Domain.Models
{
    public class User : Entity
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
    }
}
