using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(
            //    new InMemoryCarDal());

            ListCar();
            // BrandTest();
            //AddCar();
            //DeletedCar();
            UpDatedCar();
            ListCar();
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 2, ColorId = 3, DailyPrice = 620, ModelYear = 2019, Description = "Yolcu Airbag,4 Yetişkin,ABS" });
            Console.WriteLine("New car was added");
        }

        private static void DeletedCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { Id = 3 });
            Console.WriteLine("Car deleted");
        }
        private static void UpDatedCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { BrandId = 2, ColorId = 5, DailyPrice = 200, ModelYear = 2009, Description = "Yolcu Airbag,2 Yetişkin,ABS"  });
            Console.WriteLine("Car updated");

        }
       

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine(brandManager.GetyById(6));
        }

        private static void ListCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " " + car.ColorName + " " + car.ModelYear + " " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Messages);
            }
            
        }
    }
}
