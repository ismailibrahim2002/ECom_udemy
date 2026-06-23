using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecom_lib.Dtos
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public string? ProductImage { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        
    }
    public class UpdateProductDto: ProductDto
    {
        public Guid? Id { get; set; }
    }
    public class GetProductDto : ProductDto
    {
        public Guid? Id { get; set; }
       public GetCategoryDto? Category { get; set; }
    }
}
