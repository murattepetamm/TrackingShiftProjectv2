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
        public virtual Shift Shift { get; set; }
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
