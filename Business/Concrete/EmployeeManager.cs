using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
       private readonly IEmployeeDal _employeeDal;
       private readonly ITitleDal _titleDal;

        public EmployeeManager(IEmployeeDal employeeDal, ITitleDal titleDal)
        {
            _employeeDal = employeeDal;
            _titleDal = titleDal;
        }

        public async Task Create(Employee entity)
        {
            await _employeeDal.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _employeeDal.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            var getAllList = _employeeDal.GetAll().ToList();
            foreach (var item in getAllList)
            {
                item.TitleName = _titleDal.GetAll().Where(x => x.Id == item.TitleId).FirstOrDefault().Name ?? "";
            }
            return getAllList;
        }

        public Task<Employee> GetById(int id)
        {
            return _employeeDal.GetById(id);
        }

        public async Task Update(int id, Employee entity)
        {
            await _employeeDal.Update(id, entity);
        }
    }
}
