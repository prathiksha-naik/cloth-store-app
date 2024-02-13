using AutoMapper;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;

namespace ClothStoreInfrastructure.Mappings
{
    public class ClothCategoryMapping : Profile
    {
        public ClothCategoryMapping()
        {
            CreateMap<ClothCategory, ClothCategoryDto>();
            CreateMap<ClothCategoryDto, ClothCategory>();
        }
    }
}
