using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateProductDto
{
    [Required]
    public string Name {set; get;} = string.Empty;

    [Required]
    public string Description {set; get;} = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0!")]
    public decimal Price {set; get;}

    [Required]
    public string PictureUrl {set; get;} = string.Empty;

    [Required]
    public string Type {set; get;} = string.Empty;

    [Required]
    public string Brand {set; get;} = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Quantity in stock must be as least 1")]
    public int QuantityInStock { get; set; }
}
