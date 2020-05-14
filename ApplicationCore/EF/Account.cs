using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Account : IAggregateRoot
    {
        public Account()
        {
            Cart = new HashSet<Cart>();
            Complain = new HashSet<Complain>();
            Intification = new HashSet<Intification>();
            Orderproduct = new HashSet<Orderproduct>();
            Reviewproduct = new HashSet<Reviewproduct>();
            Roleaccount = new HashSet<Roleaccount>();
        }

        public int Idaccount { get; set; }
        public string Accountname { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Complain> Complain { get; set; }
        public virtual ICollection<Intification> Intification { get; set; }
        public virtual ICollection<Orderproduct> Orderproduct { get; set; }
        public virtual ICollection<Reviewproduct> Reviewproduct { get; set; }
        public virtual ICollection<Roleaccount> Roleaccount { get; set; }
    }
}
