using System;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductRepository(StoreContext context) : IProductRepository
{
    //add new product
    public void AddProduct(Product product)
    {
        context.Products.Add(product);
    }

    //delete product
    public void DeleteProduct(Product product)
    {
        context.Products.Remove(product);
    }

    //get product's brands
    public async Task<IReadOnlyList<string>> GetBrandAsync()
    {
        return await context.Products.Select(p => p.Brand)
            .Distinct()
            .ToListAsync();
    }

    //get product by id
    public async Task<Product?> GetProductByIdSync(int id)
    {
        return await context.Products.FindAsync(id);
    }

    //get product list
    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await context.Products.ToListAsync();
    }

    //get product's types
    public async Task<IReadOnlyList<string>> GetTypeAsync()
    {
        return await context.Products.Select(p => p.Type)
            .Distinct()
            .ToListAsync();
    }

    //check product is exist
    public bool IsExist(int id)
    {
        return context.Products.Any(p => p.Id == id);
    }

    //save changes
    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    //update product
    public void UpdateProduct(Product product)
    {
        context.Entry(product).State = EntityState.Modified;
    }
}
