using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new Result(true, Messages.CardAdded);
        }

        public IResult Check(Payment payment)
        {  

            if (_paymentDal.GetAll(p=>p.cardNumber==payment.cardNumber&&p.cardName==payment.cardName&&
                                      p.CVV==payment.CVV&&p.expirationDate==payment.expirationDate).Count>0)
            {
                return new Result(true,Messages.CardCorrect);
            }
            else
            {
                return new Result(false, Messages.CardUnCorrect);
            }
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new Result(true, Messages.CardAdded);
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new Result(true, Messages.CardAdded);
        }
    }
}
