using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Store : IAggregateRoot
    {
        public Store()
        {
            Orderproduct = new HashSet<Orderproduct>();
            Product = new HashSet<Product>();
        }

        public int Idstore { get; set; }
        public string Namestore { get; set; }
        public int? Phone { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string ShippingService { get; set; }
        public int? IdaccountOwn { get; set; }
        public string Information { get; set; }
        public int? Bankinfo { get; set; }
        public string LinkImg { get; set; }

        public virtual Account IdaccountOwnNavigation { get; set; }
        public virtual ICollection<Orderproduct> Orderproduct { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
