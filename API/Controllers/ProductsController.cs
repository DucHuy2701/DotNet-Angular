using System;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductRepository repo) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
    {
        return Ok(await repo.GetProductsAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await repo.GetProductByIdSync(id);

        if (product == null)
            return NotFound(); 

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        repo.AddProduct(product);

        if(await repo.SaveChangesAsync())
            return CreatedAtAction("Get product", new {id = product.Id}, product);

        return BadRequest("Problem creating product!");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
    {
        if (product.Id != id || !isExist(id))
            return BadRequest("Product with id: " + id + " not found!");
        
        repo.UpdateProduct(product);

        if(await repo.SaveChangesAsync())
            return NoContent();

        return BadRequest("Problem updating product!");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
        var product = await repo.GetProductByIdSync(id);

        if (product == null)
            return NotFound();

        repo.DeleteProduct(product);

        if(await repo.SaveChangesAsync())
            return NoContent();

        return BadRequest("Problem deleting product!");
    }

    private Boolean isExist(int id)
    {
        return repo.IsExist(id);
    }
}
