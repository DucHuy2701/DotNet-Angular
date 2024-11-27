using System;
using Core.Entities;

namespace Core.Interfaces;

public interface IProductRepository
{
    //Basic CRUD
    Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type);
    Task<Product?> GetProductByIdSync(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    bool IsExist(int id);
    Task<bool> SaveChangesAsync();

    //Get Brands-Types
    Task<IReadOnlyList<string>> GetBrandAsync();
    Task<IReadOnlyList<string>> GetTypeAsync();

}
