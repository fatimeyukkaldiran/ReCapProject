using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //IEntity db table
    //CarDetailDto --> can be join of many tables
    public class CarDetailDto :IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
