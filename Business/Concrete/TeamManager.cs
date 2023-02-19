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
    public class TeamManager : ITeamService
    {
        ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public async Task Create(Team entity)
        {
            await _teamDal.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _teamDal.Delete(id);
        }

        public IEnumerable<Team> GetAll()
        {
            return _teamDal.GetAll();
        }

        public Task<Team> GetById(int id)
        {
            return _teamDal.GetById(id);
        }

        public async Task Update(int id, Team entity)
        {
            await _teamDal.Update(id, entity);
        }
    }
}
