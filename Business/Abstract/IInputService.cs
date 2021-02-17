using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IInputService
    {
        Brand InputBrand(bool IdControl);
        Car InputCar(bool IdControl);
        Color InputColor(bool IdControl);
        Customer InputCustomer(bool IdControl);
        Rental InputRental(bool IdControl);
        User InputUser(bool IdControl);
        int InputId();
        int InputTitle();
        int Inputoperation(int operation);
    }
}
