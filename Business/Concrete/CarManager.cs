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
            if (car.DailyPrice < 0)
            {
                //magic strings
                return new ErrorResult(Messages.CarPriceInvalid);
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
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
            {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c =>c.DailyPrice >= min && c.DailyPrice <= max));
            }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice < 0 || car.Description.Length < 10 || car.Name.Length < 3)
            {
                return new ErrorResult(Messages.CarUpdatedFailed);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}