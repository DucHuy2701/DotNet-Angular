using System;
using Core.Entities;

namespace Core.Interfaces;

public interface IProductRepository
{
    //Basic CRUD
    Task<IReadOnlyList<Product>> GetProductsAsync();
    Task<Product?> GetProductByIdSync(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    bool IsExist(int id);
    Task<bool> SaveChangesAsync();

    //Search Brand-Type
    Task<IReadOnlyList<string>> GetBrandAsync();
    Task<IReadOnlyList<string>> GetTypeAsync();
}
