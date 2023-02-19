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
    public class ShiftOfTeamManager : IShiftOfTeamService
    {
        private readonly IShiftOfTeamDal _shiftOfTeamDal;
        private readonly IShiftDal _shiftDal;
        private readonly ITeamDal _teamDal;

        public ShiftOfTeamManager(IShiftOfTeamDal shiftOfTeamDal, IShiftDal shiftDal, ITeamDal teamDal)
        {
            _shiftOfTeamDal = shiftOfTeamDal;
            _shiftDal = shiftDal;
            _teamDal = teamDal;
        }

        public async Task Create(ShiftOfTeam entity)
        {
            await _shiftOfTeamDal.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _shiftOfTeamDal.Delete(id);
        }

        public IEnumerable<ShiftOfTeam> GetAll()
        {
            var getAllList = _shiftOfTeamDal.GetAll().ToList();
            foreach (var item in getAllList)
            {
                item.ShiftName = _shiftDal.GetAll().Where(x => x.Id == item.ShiftId).FirstOrDefault().Name;
                item.TeamName = _teamDal.GetAll().Where(x => x.Id == item.TeamId).FirstOrDefault().Name;
                item.ShiftStartTime = _shiftDal.GetAll().Where(x => x.Id == item.ShiftId).FirstOrDefault().ShiftStartTime;
                item.ShiftEndTime = _shiftDal.GetAll().Where(x => x.Id == item.ShiftId).FirstOrDefault().ShiftEndTime;
            }
            return getAllList;
        }

        public Task<ShiftOfTeam> GetById(int id)
        {
            return _shiftOfTeamDal.GetById(id);
        }

        public async Task Update(int id, ShiftOfTeam entity)
        {
            await _shiftOfTeamDal.Update(id, entity);
        }
    }
}
