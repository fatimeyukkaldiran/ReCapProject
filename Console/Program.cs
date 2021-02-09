using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(
            //    new InMemoryCarDal());

            CarTest();
           // BrandTest();

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

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());


            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + " " + car.ModelYear + " " + car.DailyPrice + " "+ car.ColorName);
            }
        }
    }
}
