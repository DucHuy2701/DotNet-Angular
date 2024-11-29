using System;
using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(ProductSpecParams specParams) : base(p =>
        (!specParams.Brands.Any() || specParams.Brands.Contains(p.Brand)) &&
        (!specParams.Types.Any() || specParams.Types.Contains(p.Type))
    )
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex-1), specParams.PageSize);

        switch (specParams.Sort)
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
