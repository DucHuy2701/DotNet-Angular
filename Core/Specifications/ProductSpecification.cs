using System;
using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(string? brand, string? type, string? sort) : base(p =>
        (string.IsNullOrWhiteSpace(brand) || p.Brand == brand) &&
        (string.IsNullOrWhiteSpace(type) || p.Type == type)
    )
    {
        switch (sort)
        {
            case "priceAscending":
                AddOrderBy(p => p.Price);
                break;
            case "priceDescending":
                AddOrderByDescending(p => p.Price);
                break;
            default:
                AddOrderBy(p => p.Name);
                break;
        }
    }
}
