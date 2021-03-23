using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int carImageId { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
