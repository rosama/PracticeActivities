using System;
using System.ComponentModel.DataAnnotations;

namespace RestfulActivity.Models
{
    public class CategoryDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
