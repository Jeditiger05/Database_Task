using System;
using System.Collections.Generic;

namespace Diploma_DB_Task.Api.Models
{
    public partial class Purchaseorder3778
    {
        public int Productid { get; set; }
        public string Locationid { get; set; }
        public DateTime Datetimecreated { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }

        public virtual Location3778 Location { get; set; }
        public virtual Product3778 Product { get; set; }
    }
}
