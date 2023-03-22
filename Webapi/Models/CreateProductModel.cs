using Webapi.Data.DataModels;
using Webapi.Models;

public class CreateProductModel
{
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public CreateCategoryModel Category { get; set; }
        public bool Discontinued { get; set; }
}
