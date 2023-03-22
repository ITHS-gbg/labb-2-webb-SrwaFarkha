namespace Webapp.Models
{
    public class CreateNewProductModel
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public CategoryModel Category { get; set; }
        public bool Discontinued { get; set; }
    }
}
