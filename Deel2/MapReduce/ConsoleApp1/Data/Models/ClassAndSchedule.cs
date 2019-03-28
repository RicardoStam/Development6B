using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Data.Models
{
    class ClassAndSchedule
    {
        public string ClassID { get; set; }
        public int ScheduleID { get; set; }

        public ClassAndSchedule(string classID, int scheduleID)
        {
            ClassID = classID;
            ScheduleID = scheduleID;
        }
    }
}
