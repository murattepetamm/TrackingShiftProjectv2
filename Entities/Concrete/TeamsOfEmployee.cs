using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TeamsOfEmployee : BaseEntity
    {
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        [NotMapped]
        public IList<Team> Teams { get; set; }
        public virtual Team Team { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [NotMapped]
        public IList<Employee> EmployeeNames { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
