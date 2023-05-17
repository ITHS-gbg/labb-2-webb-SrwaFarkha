namespace Models.AccountModels
{
    public class ShoppingCartModel
    {
        public List<ProductCartModel> Products { get; set; }
        public decimal TotalPrice { get; set; }

        public string GetTotalOrderPrice()
        {
	        decimal price = 0;
	        foreach (var product in Products)
	        {
		        price += product.Quantity;
	        }

	        return price.ToString("0.00") + " kr";

	        //return OrderDetails.Sum(x => x.TotalProductsPrice).ToString("0.00") + " kr  ";
        }
	}
}
