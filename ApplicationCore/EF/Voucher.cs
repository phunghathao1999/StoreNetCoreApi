using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Voucher : IAggregateRoot
    {
        public Voucher()
        {
            Orderproduct = new HashSet<Orderproduct>();
        }

        public int Idvoucher { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public int? Discount { get; set; }
        public DateTime? Startday { get; set; }
        public DateTime? Finishday { get; set; }

        public virtual ICollection<Orderproduct> Orderproduct { get; set; }
    }
}
