﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Data;
using Webapi.Data.DataModels;
using Webapi.Models.Dto;

namespace Webapi.Controllers
{
    //[Route["api/[controller]")]
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductsController(DataContext db)
        {
            _dataContext = db;
        }

        //Hämta alla produkter
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var data = _dataContext.Products.ToList();

            return Ok(data);
        }
    }
}
