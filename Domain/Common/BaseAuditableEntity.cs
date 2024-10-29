using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseAuditableEntity<TKey> :BaseEntity<TKey> 
        where TKey : IEquatable<TKey>
    {
        public  string ? CreatedBy  { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;


        public  string ? LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; } = DateTime.Now;

    }
}
