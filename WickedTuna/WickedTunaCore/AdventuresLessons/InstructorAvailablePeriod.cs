using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.Users;

namespace WickedTunaCore.AdventuresLessons
{
    public class InstructorAvailablePeriod
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Instructor Instructor { get; set; }
        public string InstructorId { get; set; }

    }
}
