using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeDal _employeeDal;
        public EmployeeController(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [HttpGet("/EmployeeGetAll")]
        public string GetAllEmploye()
        {
            _employeeDal.GetAll();
            //var x = JsonConvert.SerializeObject(_employeeDal.GetAll().FirstOrDefault());
            //return x;
            return JsonConvert.SerializeObject(_employeeDal.GetAll().FirstOrDefault());
        }
    }
}
