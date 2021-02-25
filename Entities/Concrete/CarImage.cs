using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using Core.Entities;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
