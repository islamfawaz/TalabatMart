using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductBrand:BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
    }
}
