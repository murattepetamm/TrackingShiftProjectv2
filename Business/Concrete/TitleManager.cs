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
    public class TitleManager : ITitleService
    {
        private readonly ITitleDal _titleDal;
        public TitleManager(ITitleDal titleDal)
        {
            _titleDal = titleDal;
        }

        public async Task Create(Title entity)
        {
            await _titleDal.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _titleDal.Delete(id);
        }

        public IEnumerable<Title> GetAll()
        {
            return _titleDal.GetAll();
        }

        public Task<Title> GetById(int id)
        {
            return _titleDal.GetById(id);
        }

        public async Task Update(int id, Title entity)
        {
            await _titleDal.Update(id, entity);
        }
    }
}
