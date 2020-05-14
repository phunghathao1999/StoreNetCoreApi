using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Orderproduct : IAggregateRoot
    {
        public int Idorder { get; set; }
        public DateTime? Createday { get; set; }
        public decimal? Totalprice { get; set; }
        public string Shipaddress { get; set; }
        public int? Idaccount { get; set; }
        public string Statusorder { get; set; }
        public int? Idvoucher { get; set; }

        public virtual Account IdaccountNavigation { get; set; }
        public virtual Voucher IdvoucherNavigation { get; set; }
    }
}
