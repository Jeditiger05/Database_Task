using System;
using System.Collections.Generic;

namespace Diploma_DB_Task.Api.Models
{
    public partial class Authorisedperson3778
    {
        public Authorisedperson3778()
        {
            Order3778 = new HashSet<Order3778>();
        }

        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Accountid { get; set; }

        public virtual Clientaccount3778 Account { get; set; }
        public virtual ICollection<Order3778> Order3778 { get; set; }
    }
}
