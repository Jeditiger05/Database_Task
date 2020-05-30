using System;
using System.Collections.Generic;

namespace Diploma_DB_Task.Api.Models
{
    public partial class Orderline3778
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Order3778 Order { get; set; }
        public virtual Product3778 Product { get; set; }
    }
}
