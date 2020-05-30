using System;
using System.Collections.Generic;

namespace Diploma_DB_Task.Api.Models
{
    public partial class Product3778
    {
        public Product3778()
        {
            Inventory3778 = new HashSet<Inventory3778>();
            Orderline3778 = new HashSet<Orderline3778>();
            Purchaseorder3778 = new HashSet<Purchaseorder3778>();
        }

        public int Productid { get; set; }
        public string Prodname { get; set; }
        public decimal? Buyprice { get; set; }
        public decimal? Sellprice { get; set; }

        public virtual ICollection<Inventory3778> Inventory3778 { get; set; }
        public virtual ICollection<Orderline3778> Orderline3778 { get; set; }
        public virtual ICollection<Purchaseorder3778> Purchaseorder3778 { get; set; }
    }
}
