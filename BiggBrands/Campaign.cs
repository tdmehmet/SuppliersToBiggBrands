﻿using System;
using System.Collections.Generic;

namespace SuppliersToBiggBrands.BiggBrands
{
    public partial class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int StoreId { get; set; }
        public int CustomerRoleId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? DontSendBeforeDateUtc { get; set; }
    }
}
