using System;
using System.Collections.Generic;

namespace Diploma_DB_Task.Api.Models
{
    public partial class Order3778
    {
        public Order3778()
        {
            Orderline3778 = new HashSet<Orderline3778>();
        }

        public int Orderid { get; set; }
        public string Shippingaddress { get; set; }
        public DateTime Datetimecreated { get; set; }
        public DateTime? Datetimedispatched { get; set; }
        public decimal Total { get; set; }
        public int Userid { get; set; }

        public virtual Authorisedperson3778 User { get; set; }
        public virtual ICollection<Orderline3778> Orderline3778 { get; set; }
    }
}
