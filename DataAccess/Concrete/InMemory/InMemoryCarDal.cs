using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{carId=1, BrandId=1, ColorId=1, ModelYear=2018,DailyPrice=200,Description="Manuel Benzin"},
                new Car{carId=2, BrandId=3, ColorId=5, ModelYear=2020,DailyPrice=350,Description="Otomatik Dizel"},
                new Car{carId=3, BrandId=5, ColorId=2, ModelYear=2020,DailyPrice=200,Description="Otomatik Hybrid"},
                new Car{carId=4, BrandId=5, ColorId=6, ModelYear=2020,DailyPrice=250,Description="Manuel Dizel"},
            };
            
        }
        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.carId == Id).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.carId == car.carId);
            carToUpdate.carId = car.carId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.carId==car.carId);
            _cars.Remove(carToDelete);
            
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        List<CarDetailDto> ICarDal.GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
