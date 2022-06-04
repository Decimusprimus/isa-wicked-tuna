using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.Users;

namespace WickedTunaCore.AdventuresLessons
{
    public class AdventureLessonReservation
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public AdventureLesson AdventureLesson { get; set; }
        public Guid AdventureLessonId { get; set; }
        public Client Client { get; set; }
        public string ClientId { get; set; }
    }
}
