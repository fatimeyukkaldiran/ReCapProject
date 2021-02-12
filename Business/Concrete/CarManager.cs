using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //the built did not change because never stay bind the Entity Framework
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length < 10)
            {
                //magic strings
                return new ErrorResult(Messages.CarDescriptionInvalid);
            }
            _carDal.Add(car);
          
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, "Car was deleted");
        }

        public IDataResult<List<Car>> GetAll()
        {
            // Business codes
            // Data Access

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult();
            }
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(),true, "Cars was listed");
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),true,"Cars brandId was gotten");
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
            {
            return new  DataResult<List<Car>>(_carDal.GetAll(c =>c.DailyPrice >= min && c.DailyPrice <= max),true,"was gotten prices");
            }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new DataResult<List<Car>>(_carDal.GetCarDetails(),true);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, "Car was updated");
        }
    }
}