﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            //business code
            _brandDal.Add(brand);
        }

        public List<Brand> GetAll()
        {
            // Business codes
            // Data Access
            return _brandDal.GetAll();
        }

        public Brand GetyById(int brandId)
        {
            return _brandDal.Get(b => b.BrandId == brandId);
        }
    }
}
