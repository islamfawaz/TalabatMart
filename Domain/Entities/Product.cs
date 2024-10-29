﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product :BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
        public required string NormalizedName { get; set; }
        public required string Description { get; set; }
        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }

        public ProductBrand ? Brand { get; set; }

        public int ? BrandId { get; set; }

        public ProductCategory ? Category  { get; set; }

        public int? CategoryId { get; set; }

    }
}
