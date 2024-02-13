using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStoreApplication.DataTransferObjects
{
    public class BrandDto
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        public byte[]? BrandImage { get; set; }

    }
}
