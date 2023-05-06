﻿using Webapi.Data.DataModels;
using Webapi.Models.Dto;

namespace Webapi.Models
{
    public class newOrderInput
    {
        public DateTime OrderDate { get; set; }
        public Account Customer { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }

    }
}
