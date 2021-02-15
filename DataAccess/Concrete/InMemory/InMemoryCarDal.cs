using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; // global variable //reference type
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 4, Name = "Jaguar I-Pace", DailyPrice = 300, ModelYear = 2010, Description ="Yolcu Airbag,3 Yetişkin,ABS" },
                new Car{Id = 2, BrandId = 1, ColorId = 4, Name = "Bmw 3.18i", DailyPrice = 400, ModelYear = 2012, Description ="Yolcu Airbag,4 Yetişkin,ABS" },
                new Car{Id = 3, BrandId = 2, ColorId = 6, Name = "Ford Focus 1.5", DailyPrice = 350, ModelYear = 2017, Description ="Yolcu Airbag,3 Yetişkin,ABS" },
                new Car{Id = 4, BrandId = 2, ColorId = 5, Name = "Volvo XC60d", DailyPrice = 450, ModelYear = 2019, Description ="Yolcu Airbag,4 Yetişkin,ABS" },
                new Car{Id = 5, BrandId = 3, ColorId = 5, Name = "Honda Civic", DailyPrice = 500, ModelYear = 2020, Description ="Yolcu Airbag,5 Yetişkin,ABS" }

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           _cars.Remove(_cars.SingleOrDefault(c => c.Id == car.Id));
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public List<Car> GetAllByBrand(Car car)
        {
            return _cars.Where(c => c.BrandId == car.BrandId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
