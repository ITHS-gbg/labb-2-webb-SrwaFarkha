namespace Models.AccountModels
{
    public class ShoppingCartModel
    {
        public List<ProductCartModel> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
