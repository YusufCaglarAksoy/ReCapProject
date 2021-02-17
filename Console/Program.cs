using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program

    {
        static void Main(string[] args)
        {
            InputManager inputManager = new InputManager();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());
            do
            {
                Console.Clear();
                int operation1 = inputManager.InputTitle();
                int operation2 = inputManager.Inputoperation(operation1);
                
                switch (operation1)
                {
                    case 1:
                        switch (operation2)
                        {
                            case 1:                               
                                var result1 = brandManager.GetById();

                                Console.WriteLine(Lists.BrandList);
                                Console.WriteLine(result1.Data.Id + "\t\t\t" + result1.Data.BrandName);
                                Console.WriteLine(result1.Message);
                                break;

                            case 2:
                                var result2 = brandManager.GetAll();
                     
                                Console.WriteLine(Lists.BrandList);
                                foreach (var brand in result2.Data)
                                {
                                    Console.WriteLine(brand.Id + "\t\t\t" + brand.BrandName);
                                }
                                Console.WriteLine(result2.Message);
                                break;

                            case 3:
                                var result3 = brandManager.Add();
                                Console.WriteLine(result3.Message);
                                break;

                            case 4:
                                var result4 = brandManager.Update();
                                Console.WriteLine(result4.Message);
                                break;

                            case 5:
                                var result5 = brandManager.Delete();
                                Console.WriteLine(result5.Message);
                                break;


                        }
                        break;

                    case 2:
                        switch (operation2)
                        {
                            case 1:
                                var result1 = carManager.GetById();

                                Console.WriteLine(Lists.CarList);
                                Console.WriteLine(
                                    result1.Data.Id + "\t\t" +
                                    result1.Data.BrandId + "\t\t" +
                                    result1.Data.ColorId + "\t\t" +
                                    result1.Data.ModelYear + "\t\t" +
                                    result1.Data.DailyPrice + "\t\t" +
                                    result1.Data.Description 
                                    );
                                Console.WriteLine(result1.Message);
                                break;

                            case 2:
                                var result2 = carManager.GetAll();

                                Console.WriteLine(Lists.CarList);
                                foreach (var car in result2.Data)
                                {
                                    Console.WriteLine(
                                    car.Id + "\t\t" +
                                    car.BrandId + "\t\t" +
                                    car.ColorId + "\t\t" +
                                    car.ModelYear + "\t\t" +
                                    car.DailyPrice + "\t\t" +
                                    car.Description 
                                    );
                                }
                                Console.WriteLine(result2.Message);
                                break;

                            case 3:
                                var result3 = carManager.Add();
                                Console.WriteLine(result3.Message);
                                break;

                            case 4:
                                var result4 = carManager.Update();
                                Console.WriteLine(result4.Message);
                                break;

                            case 5:
                                var result5 = carManager.Delete();
                                Console.WriteLine(result5.Message);
                                break;
                            case 6:
                                var result6 = carManager.GetCarsByBrandId();

                                Console.WriteLine(Lists.CarList);
                                foreach (var car in result6.Data)
                                {
                                    Console.WriteLine(
                                    car.Id + "\t\t" +
                                    car.BrandId + "\t\t" +
                                    car.ColorId + "\t\t" +
                                    car.ModelYear + "\t\t" +
                                    car.DailyPrice + "\t\t" +
                                    car.Description 
                                    );
                                }
                                Console.WriteLine(result6.Message);
                                break;
                            case 7:
                                var result7 = carManager.GetCarsByColorId();

                                Console.WriteLine(Lists.CarList);
                                foreach (var car in result7.Data)
                                {
                                    Console.WriteLine(
                                    car.Id + "\t\t" +
                                    car.BrandId + "\t\t" +
                                    car.ColorId + "\t\t" +
                                    car.ModelYear + "\t\t" +
                                    car.DailyPrice + "\t\t" +
                                    car.Description 
                                    );
                                }
                                Console.WriteLine(result7.Message);
                                break;
                            case 8:
                                var result8 = carManager.GetCarDetailDtos();

                                Console.WriteLine(Lists.CarList);
                                foreach (var car in result8.Data)
                                {
                                    Console.WriteLine(
                                     car.CarName +
                                    "\t\t" + car.BrandName +
                                    "\t\t\t" + car.ColorName +
                                    "\t\t\t" + car.DailyPrice);
                                }
                                Console.WriteLine(result8.Message);
                                break;


                        }
                        break;

                    case 3:
                        switch (operation2)
                        {
                            case 1:
                                var result1 = colorManager.GetById();

                                Console.WriteLine(Lists.ColorList);
                                Console.WriteLine(result1.Data.Id + "\t\t\t" + result1.Data.ColorName);
                                Console.WriteLine(result1.Message);
                                break;

                            case 2:
                                var result2 = colorManager.GetAll();

                                Console.WriteLine(Lists.ColorList);
                                foreach (var color in result2.Data)
                                {
                                    Console.WriteLine(color.Id + "\t\t" + color.ColorName);
                                }
                                Console.WriteLine(result2.Message);
                                break;

                            case 3:
                                var result3 = colorManager.Add();
                                Console.WriteLine(result3.Message);
                                break;

                            case 4:
                                var result4 = colorManager.Update();
                                Console.WriteLine(result4.Message);
                                break;

                            case 5:
                                var result5 = colorManager.Delete();
                                Console.WriteLine(result5.Message);
                                break;


                        }
                        break;

                    case 4:
                        switch (operation2)
                        {
                            case 1:   
                                var result1 = customerManager.GetById();

                                Console.WriteLine(Lists.CustomerList);
                                Console.WriteLine(result1.Data.Id + "\t\t\t"
                                    + result1.Data.UserId+ "\t\t\t"
                                    + result1.Data.CompanyName);
                                Console.WriteLine(result1.Message);
                                break;

                            case 2: 
                                var result2 = customerManager.GetAll();

                                Console.WriteLine(Lists.CustomerList);
                                foreach (var customer in result2.Data)
                                {
                                    Console.WriteLine(customer.Id + "\t\t\t"
                                    + customer.UserId + "\t\t\t"
                                    + customer.CompanyName);
                                }
                                Console.WriteLine(result2.Message);
                                break;

                            case 3:
                                var result3 = customerManager.Add();
                                Console.WriteLine(result3.Message);
                                break;

                            case 4:
                                var result4 = customerManager.Update();
                                Console.WriteLine(result4.Message);
                                break;

                            case 5:
                                var result5 = customerManager.Delete();
                                Console.WriteLine(result5.Message);
                                break;


                        }
                        break;

                    case 5:
                        switch (operation2)
                        {
                            case 1:   
                                var result1 = rentalManager.GetById();

                                Console.WriteLine(Lists.RentalList);
                                Console.WriteLine(
                                    result1.Data.Id + "\t\t\t" + 
                                    result1.Data.CarId + "\t\t\t" + 
                                    result1.Data.CustomerId + "\t\t\t" + 
                                    result1.Data.RentDate + "\t\t" + 
                                    result1.Data.ReturnDate);
                                Console.WriteLine(result1.Message);
                                break;

                            case 2:
                                var result2 = rentalManager.GetAll();

                                Console.WriteLine(Lists.RentalList);
                                foreach (var rental in result2.Data)
                                {
                                    Console.WriteLine(
                                    rental.Id + "\t\t\t" +
                                    rental.CarId + "\t\t\t" +
                                    rental.CustomerId + "\t\t\t" +
                                    rental.RentDate + "\t\t" +
                                    rental.ReturnDate);
                                }
                                Console.WriteLine(result2.Message);
                                break;

                            case 3:
                                var result3 = rentalManager.Add();
                                Console.WriteLine(result3.Message);
                                break;

                            case 4:
                                var result4 = rentalManager.Update();
                                Console.WriteLine(result4.Message);
                                break;

                            case 5:
                                var result5 = rentalManager.Delete();
                                Console.WriteLine(result5.Message);
                                break;


                        }
                        break;

                    case 6:
                        switch (operation2)
                        {
                            case 1:  
                                var result1 = userManager.GetById();

                                Console.WriteLine(Lists.UserList);
                                Console.WriteLine(
                                    result1.Data.Id + "\t\t\t" +
                                    result1.Data.FirstName + "\t\t" +
                                    result1.Data.LastName + "\t\t" +
                                    result1.Data.Email + "\t\t" +
                                    result1.Data.Password);
                                Console.WriteLine(result1.Message);
                                break;

                            case 2:
                                var result2 = userManager.GetAll();

                                Console.WriteLine(Lists.UserList);
                                foreach (var user in result2.Data)
                                {
                                    Console.WriteLine(
                                    user.Id + "\t\t\t" +
                                    user.FirstName + "\t\t" +
                                    user.LastName + "\t\t" +
                                    user.Email + "\t\t" +
                                    user.Password);
                                }
                                Console.WriteLine(result2.Message);
                                break;

                            case 3:
                                var result3 = userManager.Add();
                                Console.WriteLine(result3.Message);
                                break;

                            case 4:
                                var result4 = userManager.Update();
                                Console.WriteLine(result4.Message);
                                break;

                            case 5:
                                var result5 = userManager.Delete();
                                Console.WriteLine(result5.Message);
                                break;


                        }
                        break;
                }

                Console.Write("Devam Etmek İster Misiniz? (e/h)");
            } while(Console.ReadLine()=="e");
            
    
        }
    }
}
