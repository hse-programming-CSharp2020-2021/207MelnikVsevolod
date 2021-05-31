﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using WebCW1.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebCW1.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>(new[] {
        new Product() { Id = 1, Name = "Notebook", Price = 100000 },
        new Product() { Id = 2, Name = "Car", Price = 2000000 },
        new Product() { Id = 3, Name = "Apple", Price = 30 },
        });

        private int NextProductId =>
        products.Count() == 0 ? 1 : products.Max(x => x.Id) + 1;
        [HttpGet("GetNextProductId")] // проверка: /api/GetNextProductId/
        public int GetNextProductId() {
            return NextProductId;
        }

        [HttpGet]
        public IEnumerable<Product> Get() => products;

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            products.Remove(products.SingleOrDefault(p => p.Id == id));
            return Ok();
        }

        [HttpGet("{id}")] // параметр для маршрутизации
        public IActionResult Get(int id)
        {
            var product = products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.Id = NextProductId;
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id },
            product);
        }

        [HttpPost("AddProduct")]
        public IActionResult PostBody([FromBody] Product product) =>
            Post(product);

        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var storedProduct = products.SingleOrDefault(p => p.Id == product.Id);
            if (storedProduct == null) return NotFound();
            storedProduct.Name = product.Name;
            storedProduct.Price = product.Price;
            return Ok(storedProduct);
        }

        public ProductsController()
        {
        }
    }
}
