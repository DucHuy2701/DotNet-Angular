using System;

namespace Core.Entities;

public class Product : BaseEntity
{
    public required String Name {set; get;}
    public required String Description {set; get;}
    public decimal Price {set; get;}
    public required String ImgUrl {set; get;}
    public required String Type {set; get;}
    public required String Brand {set; get;}
    public int QuantityInStock { get; set; }
}
