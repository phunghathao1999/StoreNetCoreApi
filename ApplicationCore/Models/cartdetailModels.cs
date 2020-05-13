namespace ApplicationCore.Models
{
    public class cartdetailModels
    {
        public int Idcartdetail { get; set; }
        public int? Idcart { get; set; }
        public int? Idproduct { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string Note { get; set; }
    }
}
