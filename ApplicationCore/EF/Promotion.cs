using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Promotion : IAggregateRoot
    {
        public int Idpromotion { get; set; }
        public string Content { get; set; }
        public string LinkImg { get; set; }
        public string Status { get; set; }
        public DateTime? Createday { get; set; }
        public string Linkimgpromotion { get; set; }
    }
}
