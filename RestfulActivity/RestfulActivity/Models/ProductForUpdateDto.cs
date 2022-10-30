using System;
using System.ComponentModel.DataAnnotations;

namespace RestfulActivity.Models
{
    public class ProductForUpdateDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImgURL { set; get; }
        public Guid CategoryId { set; get; }
    }
}
