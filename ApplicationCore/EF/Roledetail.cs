using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Roledetail : IAggregateRoot
    {
        public int Idroledetail { get; set; }
        public int? Idrole { get; set; }
        public string Note { get; set; }

        public virtual Roleaccount IdroleNavigation { get; set; }
    }
}
