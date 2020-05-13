using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Roleaccount : IAggregateRoot
    {
        public Roleaccount()
        {
            Roledetail = new HashSet<Roledetail>();
        }

        public int Idrole { get; set; }
        public string Rolename { get; set; }
        public int? Idaccount { get; set; }

        public virtual Account IdaccountNavigation { get; set; }
        public virtual ICollection<Roledetail> Roledetail { get; set; }
    }
}
