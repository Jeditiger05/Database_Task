using System;
using System.Collections.Generic;

namespace Diploma_DB_Task.Api.Models
{
    public partial class Clientaccount3778
    {
        public Clientaccount3778()
        {
            Accountpayment3778 = new HashSet<Accountpayment3778>();
            Authorisedperson3778 = new HashSet<Authorisedperson3778>();
        }

        public int Accountid { get; set; }
        public string Acctname { get; set; }
        public decimal Balance { get; set; }
        public decimal Creditlimit { get; set; }

        public virtual ICollection<Accountpayment3778> Accountpayment3778 { get; set; }
        public virtual ICollection<Authorisedperson3778> Authorisedperson3778 { get; set; }
    }
}
