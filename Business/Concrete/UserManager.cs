using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        EfUserDal _userDal;
        InputManager inputManager = new InputManager();
        public UserManager(EfUserDal userDal)
        {
            _userDal = userDal;
        }
        public IDataResult<User> GetById()
        {
            Console.Write("Id girini: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            return new SuccessDataResult<User>(_userDal.Get(c => c.Id == inputManager.InputId()));
        }
        public IResult Add()
        {
            _userDal.Add(inputManager.InputUser(false));
            return new Result(true, Messages.UserAdded);
        }

        public IResult Delete()
        {
            _userDal.Delete(inputManager.InputUser(true));
            return new Result(true, Messages.UserDeleted);
        }

        public IResult Update()
        {
            _userDal.Update(inputManager.InputUser(true));
            return new Result(true, Messages.UserUpdated);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }
    }
}
