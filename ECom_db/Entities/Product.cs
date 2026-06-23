using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECom_db.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Field Name Is Required")]
        [MaxLength(50,ErrorMessage ="name must be less than 50 Char")]
        public string? Name { get; set; }
        [MaxLength(100, ErrorMessage = "name must be less than 100 Char")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
        public string? ProductImage { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
        public int? Quantity { get; set; }
        [ForeignKey("CategoryGuid")]
        public Category Category { get; set; }
        public Guid CategoryGuid { get; set; }
    }
}
