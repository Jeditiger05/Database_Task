using System;
using System.Collections.Generic;

namespace Diploma_DB_Task.Api.Models
{
    public partial class Location3778
    {
        public Location3778()
        {
            Inventory3778 = new HashSet<Inventory3778>();
            Purchaseorder3778 = new HashSet<Purchaseorder3778>();
        }

        public string Locationid { get; set; }
        public string Locname { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }

        public virtual ICollection<Inventory3778> Inventory3778 { get; set; }
        public virtual ICollection<Purchaseorder3778> Purchaseorder3778 { get; set; }
    }
}
