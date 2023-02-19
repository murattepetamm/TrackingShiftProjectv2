using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ShiftOfTeam : BaseEntity
    {
        [ForeignKey("Shift")]
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftEndTime { get; set; }
        public virtual Shift Shift { get; set; }
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public virtual Team Team { get; set; }
    }
}
