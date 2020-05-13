using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class PaginationModels<T>
    {
        public IEnumerable<T> array {get;set;}
        public int current { get; set; }
        public int pageSize { get; set; }
        public int count { get; set; }
        public int totalPage { get; set; }
    }
}
