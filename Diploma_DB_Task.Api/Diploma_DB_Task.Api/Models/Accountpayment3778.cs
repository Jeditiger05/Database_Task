using System;
using System.Collections.Generic;

namespace Diploma_DB_Task.Api.Models
{
    public partial class Accountpayment3778
    {
        public int Accountid { get; set; }
        public DateTime Datetimereceived { get; set; }
        public decimal Amount { get; set; }

        public virtual Clientaccount3778 Account { get; set; }
    }
}
