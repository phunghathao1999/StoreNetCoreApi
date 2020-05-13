using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Cartdetail : IAggregateRoot
    {
        public Cartdetail()
        {
            Complain = new HashSet<Complain>();
            Reviewproduct = new HashSet<Reviewproduct>();
        }

        public int Idcartdetail { get; set; }
        public int? Idcart { get; set; }
        public int? Idproduct { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string Note { get; set; }

        public virtual Cart IdcartNavigation { get; set; }
        public virtual Product IdproductNavigation { get; set; }
        public virtual ICollection<Complain> Complain { get; set; }
        public virtual ICollection<Reviewproduct> Reviewproduct { get; set; }
    }
}
