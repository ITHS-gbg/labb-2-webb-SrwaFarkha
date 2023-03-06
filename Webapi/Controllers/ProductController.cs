﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Data;
using Webapi.Data.DataModels;
using Webapi.Data.Repositories.Interfaces;
using Webapi.Models.Dto;

namespace Webapi.Controllers
{
    //[Route["api/[controller]")]
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //Hämta alla produkter
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var data = _productRepository.GetAll();

            return Ok(data);
        }

        //Hämtar en product baserat på namn
        [HttpGet("{name}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Product> GetProduct(string name)
        {
            var data = _productRepository.GetByName(name);
            return Ok(data);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult CreateProduct(Product product)
        {
            _productRepository.CreateProduct(product);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
            return Ok();
        }
    }
}
