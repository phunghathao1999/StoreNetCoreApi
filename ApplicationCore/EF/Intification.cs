using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Intification : IAggregateRoot
    {
        public int Idintification { get; set; }
        public int? Idaccount { get; set; }
        public string Content { get; set; }

        public virtual Account IdaccountNavigation { get; set; }
    }
}
