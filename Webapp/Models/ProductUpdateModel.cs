﻿namespace Webapp.Models
{
    public class ProductUpdateModel
    {
        public int ProductId{ get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
    }
}
