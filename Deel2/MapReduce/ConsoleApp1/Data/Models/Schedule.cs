using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Data.Models
{
    class Schedule
    {
        public int ScheduleID { get; set; }
        public string Course { get; set; }
        public int Hour { get; set; }

        public Schedule(int scheduleID, string course, int hour)
        {
            ScheduleID = scheduleID;
            Course = course;
            Hour = hour;
        }
    }
}
