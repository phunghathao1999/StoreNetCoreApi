using ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Category : IAggregateRoot
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int Idcategory { get; set; }
        public string Namecategory { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
