using AutoMapper;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;

namespace ClothStoreInfrastructure.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
