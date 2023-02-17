﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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
    public class TestController : ControllerBase
    {
        IEmployeeDal<TeamsOfEmployee> _employeeDal;
        public TestController(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [HttpGet("/EmployeeGetAll")]
        public string GetAllEmploye()
        {
            var x = JsonConvert.SerializeObject(_employeeDal.GetAll().FirstOrDefault());
            return x;
        }
    }
}
