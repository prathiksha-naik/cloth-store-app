using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Interface
{
    public interface ISizeForCloth
    {
        Task<IEnumerable<SizeVariant>> GetSizeVariantsForClothItem(int clothItemId);
        Task<IEnumerable<ClothItem>> GetClothItemsByParticularSizeAsync(string size); 
        Task<IEnumerable<ClothItem>> GetClothItemsBySizeRangeAsync(List<string> sizes);
        bool ClothItemSizeExists(string size);
    }
}
