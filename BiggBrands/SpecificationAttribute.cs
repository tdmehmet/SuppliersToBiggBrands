﻿using System;
using System.Collections.Generic;

namespace SuppliersToBiggBrands.BiggBrands
{
    public partial class SpecificationAttribute
    {
        public SpecificationAttribute()
        {
            SpecificationAttributeOption = new HashSet<SpecificationAttributeOption>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<SpecificationAttributeOption> SpecificationAttributeOption { get; set; }
    }
}
