using System;

namespace RestfulActivity.Models
{
    public class ProductForUpdateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImgURL { set; get; }
        public Guid CategoryId { set; get; }
    }
}
