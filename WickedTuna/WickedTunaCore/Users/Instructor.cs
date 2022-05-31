
using System.Collections.Generic;
using WickedTunaCore.AdventuresLessons;

namespace WickedTunaCore.Users
{
    public class Instructor : TUser 
    {
        public string ShortBiography { get; set; }

        public ICollection<AdventureLesson> AdventureLessons { get; set; }
    }
}
