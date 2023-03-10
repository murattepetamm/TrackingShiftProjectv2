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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeDal
    {
        private readonly AppDb_Context _appDb_Context;
        public EmployeeRepository(AppDb_Context appDb_Context) : base(appDb_Context)
        {
            _appDb_Context = appDb_Context;
        }        
    }
}
