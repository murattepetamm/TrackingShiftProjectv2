using Microsoft.AspNetCore.Mvc;
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
        public EmployeeController()
        {

        }

        [HttpGet("/EmployeeGetAll")]
        public string GetAllEmploye()
        {
            //var x = JsonConvert.SerializeObject(_employeeDal.GetAll().FirstOrDefault());
            //return x;
            return null;
        }
    }
}
