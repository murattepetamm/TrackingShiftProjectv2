using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Abstract.IRepository;

namespace DataAccess.Abstract
{
    public interface ITeamDal : IRepository<Team>
    {
    }
}
