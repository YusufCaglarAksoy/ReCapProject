﻿using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }

    }
}
