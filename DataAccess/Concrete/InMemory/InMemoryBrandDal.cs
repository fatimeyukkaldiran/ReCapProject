using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{BrandId = 1, BrandName = "Jaguar I-Pace"},
                new Brand{BrandId = 2, BrandName = "Bmw 3.18i"},
                new Brand{BrandId = 3, BrandName = "Ford Focus 1.5"},
                new Brand{BrandId = 4, BrandName = "Volvo XC60d"},
                new Brand{BrandId = 5, BrandName = "Honda Civic"},
            };
        }
        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brands.Remove(_brands.SingleOrDefault(b => b.BrandId == brand.BrandId));
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand brand)
        {
            Brand branToUpdate = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            branToUpdate.BrandName = brand.BrandName;
        }
    }
}
