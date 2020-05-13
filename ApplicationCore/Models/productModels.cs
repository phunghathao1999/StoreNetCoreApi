namespace ApplicationCore.Models
{
    public class productModels
    {
        public int Idproduct { get; set; }
        public string Nameproduct { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Idstore { get; set; }
        public string LinkImg { get; set; }
        public int? Count { get; set; }
        public string Trademark { get; set; }
        public int? Idcategory { get; set; }
    }
}
