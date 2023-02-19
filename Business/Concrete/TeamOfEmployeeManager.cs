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
    public class TeamOfEmployeeManager : ITeamOfEmployeeService
    {
        ITeamOfEmployeeDal _teamOfEmployeeDal;
        IEmployeeDal _employeeDal;
        ITeamDal _teamDal;
        public TeamOfEmployeeManager(ITeamOfEmployeeDal teamOfEmployeeDal, IEmployeeDal employeeDal, ITeamDal teamDal)
        {
            _teamOfEmployeeDal = teamOfEmployeeDal;
            _employeeDal = employeeDal;
            _teamDal = teamDal;
        }
        public async Task Create(TeamsOfEmployee entity)
        {
            await _teamOfEmployeeDal.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _teamOfEmployeeDal.Delete(id);
        }

        public IEnumerable<TeamsOfEmployee> GetAll()
        {
            var getalllist = _teamOfEmployeeDal.GetAll().ToList();
            foreach (var item in getalllist)
            {
                item.Teams = _teamDal.GetAll().Where(x => x.Id == item.TeamId).ToList();
                item.EmployeeNames = _employeeDal.GetAll().Where(x => x.Id == item.EmployeeId).ToList();
            }
            return getalllist;

        }

        public Task<TeamsOfEmployee> GetById(int id)
        {
            return _teamOfEmployeeDal.GetById(id);
        }

        public async Task Update(int id, TeamsOfEmployee entity)
        {
            await _teamOfEmployeeDal.Update(id, entity);
        }
    }
}
