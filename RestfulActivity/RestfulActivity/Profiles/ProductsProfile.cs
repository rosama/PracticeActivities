using AutoMapper;
namespace RestfulActivity.Profiles
{
    public class ProductsProfile:Profile
    {
        public ProductsProfile() {
            CreateMap<Entities.Products, Models.ProductsDto>();
            CreateMap<Models.ProductForCreationDto, Entities.Products>();
            CreateMap<Models.ProductForUpdateDto, Entities.Products>();
            CreateMap<Models.ProductForUpdateDto, Models.ProductsDto>();


        }
    }
}
