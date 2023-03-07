namespace Webapi.Data.DataModels
{
    public class Product
    {
        //komunicera med data basen
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public bool Discontinued { get; set; }
    }
}
