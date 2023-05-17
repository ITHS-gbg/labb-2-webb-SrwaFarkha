namespace Models.OrderModels
{
    public class OrderDetailsModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

	    public decimal TotalProductsPrice { get; set; }
	}
}
