namespace Webapi.Models.Dto
{
    public class ProductDto
    {
        //Visa data
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public Enums.Enums.Category Category { get; set; }
        public bool Discontinued { get; set; }
    }
}
