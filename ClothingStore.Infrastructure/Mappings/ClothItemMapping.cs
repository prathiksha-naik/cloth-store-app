using AutoMapper;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;

namespace ClothStoreInfrastructure.Mappings
{
    public class ClothItemMapping : Profile
    {
        public ClothItemMapping()
        {
            CreateMap<ClothItem, ClothItemDto>();
            CreateMap<ClothItemDto, ClothItem>();
        }
    }
}
