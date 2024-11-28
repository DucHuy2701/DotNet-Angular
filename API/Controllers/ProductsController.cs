using System;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IGenericRepository<Product> repo) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, string? sort)
    {
        var spec = new ProductSpecification(brand, type, sort);

        var products = await repo.ListAsync(spec);

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await repo.GetByIdAsync(id);

        if (product == null)
            return NotFound(); 

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        repo.Add(product);

        if(await repo.SaveAllAsync())
            return CreatedAtAction("Get product", new {id = product.Id}, product);

        return BadRequest("Problem creating product!");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
    {
        if (product.Id != id || !isExist(id))
            return BadRequest("Product with id: " + id + " not found!");
        
        repo.Update(product);

        if(await repo.SaveAllAsync())
            return NoContent();

        return BadRequest("Problem updating product!");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
        var product = await repo.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        repo.Remove(product);

        if(await repo.SaveAllAsync())
            return NoContent();

        return BadRequest("Problem deleting product!");
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
    {
        //impl method
        return Ok();
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
    {
        //impl method
        return Ok();
    }

    private Boolean isExist(int id)
    {
        return repo.IsExist(id);
    }
}
