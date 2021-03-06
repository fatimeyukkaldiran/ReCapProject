﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{Id=1, Name = "Black"},
                new Color{Id=2, Name = "White"},
                new Color{Id=3, Name = "Red"},
                new Color{Id=4, Name = "Brown"},
                new Color{Id=5, Name = "Green"}
            };
        }
        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            _colors.Remove(_colors.SingleOrDefault(cl => cl.Id == color.Id));
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAllByColor()
        {
            return _colors;
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(cl => cl.Id == color.Id);
            colorToUpdate.Name = color.Name;
        }
    }
}
