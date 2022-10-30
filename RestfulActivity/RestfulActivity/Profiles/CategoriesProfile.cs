using AutoMapper;

namespace RestfulActivity.Profiles
{
    public class CategoriesProfile:Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Entities.Category, Models.CategoryDto>();
            ;
            CreateMap<Models.CategoryDto, Entities.Category>();
        }
    }
}
