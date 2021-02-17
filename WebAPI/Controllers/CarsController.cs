using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // attribute in c# ,  annotation in java bir class için bilgi verme ve imzalama
    public class CarsController : ControllerBase //this class has a controller task
    {    //Loosely coupled
         //naming convention
         //IoC Container -- Inversion of Control
        ICarService _carService;
       
        //fieldelerin defaultu private

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public List<Car> Get()
        {
            //dependency chain
           
           var result = _carService.GetAll();
           return  result.Data;
        }

    }
}
