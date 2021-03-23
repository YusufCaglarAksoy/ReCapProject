using Core.Entities;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        public int brandId { get; set; }
        public string BrandName { get; set; }
    }
}
