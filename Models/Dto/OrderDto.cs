﻿namespace Models.Dto
{
    public class OrderDto
    {
        public AccountDto Account { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }
    }
}
