using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecom_lib.Dtos
{
    public class CategoryDto
    {
        [Required]
        public string? Name { get; set; }
    }
    public class UpdateCategoryDto : CategoryDto
    {
        public Guid Id { get; set; }
    }
    public class GetCategoryDto : CategoryDto
    {
        public Guid Id { get; set; }
        public ICollection<GetProductDto>? Products { get; set; }
    }
}
