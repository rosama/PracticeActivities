using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulActivity.Entities
{
    public class Products
    {
        [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string ImgURL { set; get; }
        [Required]
        public Guid CategoryId { set; get; }
    }
}
