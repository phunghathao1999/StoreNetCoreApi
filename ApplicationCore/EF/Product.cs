using ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Product : IAggregateRoot
    {
        public Product()
        {
            Cartdetail = new HashSet<Cartdetail>();
        }

        public int Idproduct { get; set; }
        public string Nameproduct { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Idstore { get; set; }
        public string LinkImg { get; set; }
        public int? Count { get; set; }
        public string Trademark { get; set; }
        public int? Idcategory { get; set; }

        public virtual Category IdcategoryNavigation { get; set; }
        public virtual Store IdstoreNavigation { get; set; }
        public virtual ICollection<Cartdetail> Cartdetail { get; set; }
    }
}
