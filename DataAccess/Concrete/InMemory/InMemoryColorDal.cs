using DataAccess.Abstract;
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
                new Color{ColorId=1, ColorName = "Black"},
                new Color{ColorId=2, ColorName = "White"},
                new Color{ColorId=3, ColorName = "Red"},
                new Color{ColorId=4, ColorName = "Brown"},
                new Color{ColorId=5, ColorName = "Green"}
            };
        }
        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            _colors.Remove(_colors.SingleOrDefault(cl => cl.ColorId == color.ColorId));
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
            Color colorToUpdate = _colors.SingleOrDefault(cl => cl.ColorId == color.ColorId);
            colorToUpdate.ColorName = color.ColorName;
        }
    }
}
