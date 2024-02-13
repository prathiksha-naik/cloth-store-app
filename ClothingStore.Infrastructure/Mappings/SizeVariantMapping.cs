using AutoMapper;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;

namespace ClothStoreInfrastructure.Mappings
{
    public class SizeVariantMapping : Profile
    {
        public SizeVariantMapping()
        {
            CreateMap<SizeVariant, SizeVariantDto>();
            CreateMap<SizeVariantDto, SizeVariant>();
        }
    }
}
