using System;
using System.Collections.Generic;
using WickedTunaCore.Common;
using WickedTunaCore.Users;

namespace WickedTunaCore.AdventuresLessons
{
    public class AdventureLesson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public int MaxNumberOfPeople { get; set; }
        public float CancellationFee { get; set; }

        public Instructor Instructor { get; set; }
        public string InstructorId { get; set; }
        public ICollection<AdventureLessonReservation> AdventureLessonReservations { get; set; }

    }
}
