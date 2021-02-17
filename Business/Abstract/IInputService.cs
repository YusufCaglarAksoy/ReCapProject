using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IInputService
    {
        Brand InputBrand();
        Car InputCar();
        Color InputColor();
        Customer InputCustomer();
        Rental InputRental();
        User InputUser();
        int InputId();
        int InputTitle();
        int Inputoperation(int operation);
    }
}
