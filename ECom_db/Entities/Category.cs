using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECom_db.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Field Name Is Required")]
        [MaxLength(50, ErrorMessage = "name must be less than 50 Char")]
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; } = new List<Product>();

    }
}
