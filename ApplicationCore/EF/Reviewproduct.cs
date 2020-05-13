using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Reviewproduct : IAggregateRoot
    {
        public int Idreview { get; set; }
        public double? Startnum { get; set; }
        public int? Idaccount { get; set; }
        public DateTime? Createday { get; set; }
        public int? Idcartdetail { get; set; }
        public string Status { get; set; }

        public virtual Account IdaccountNavigation { get; set; }
        public virtual Cartdetail IdcartdetailNavigation { get; set; }
    }
}
