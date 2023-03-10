using DataAccess.Abstract;
using DataAccess.AppDbContext;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class TeamOfEmployeeRepository: GenericRepository<TeamsOfEmployee>, ITeamOfEmployeeDal
    {
        public TeamOfEmployeeRepository(AppDb_Context appDb_Context) : base(appDb_Context)
        {
        }
    }
}
