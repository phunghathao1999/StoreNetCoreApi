using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Complain : IAggregateRoot
    {
        public int Idcomplain { get; set; }
        public int? Idaccount { get; set; }
        public int? Idcartdetail { get; set; }
        public DateTime? Createday { get; set; }
        public string Status { get; set; }

        public virtual Account IdaccountNavigation { get; set; }
        public virtual Cartdetail IdcartdetailNavigation { get; set; }
    }
}
