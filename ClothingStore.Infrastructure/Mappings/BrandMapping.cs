using AutoMapper;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;

namespace ClothStoreInfrastructure.Mappings
{
    public class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<BrandDto, Brand>();
        }
    }
}
