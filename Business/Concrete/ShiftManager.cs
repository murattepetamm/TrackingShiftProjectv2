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
    public class ShiftManager : IShiftService
    {
        private readonly IShiftDal _shiftDal;

        public ShiftManager(IShiftDal shiftDal)
        {
            _shiftDal = shiftDal;
        }

        public async Task Create(Shift entity)
        {
            await _shiftDal.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _shiftDal.Delete(id);
        }

        public IEnumerable<Shift> GetAll()
        {
            return _shiftDal.GetAll();
        }

        public Task<Shift> GetById(int id)
        {
            return _shiftDal.GetById(id);
        }

        public async Task Update(int id, Shift entity)
        {
            await _shiftDal.Update(id, entity);
        }
    }
}
