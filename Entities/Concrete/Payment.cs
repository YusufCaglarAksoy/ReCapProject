using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int paymentId { get; set; }
        public string cardNumber { get; set; }
        public string cardName { get; set; }
        public string expirationDate { get; set; }
        public int CVV { get; set; }

    }
}
