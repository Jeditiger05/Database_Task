using System;
using System.Collections.Generic;

namespace Diploma_DB_Task.Api.Models
{
    public partial class Inventory3778
    {
        public int Productid { get; set; }
        public string Locationid { get; set; }
        public int Numinstock { get; set; }

        public virtual Location3778 Location { get; set; }
        public virtual Product3778 Product { get; set; }
    }
}
