using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Data.Models
{
    class Classes
    { 
        public string ClassID { get; set; }
        public string SLC { get; set; }

        public Classes(string classID, string slc)
        {
            ClassID = classID;
            SLC = slc;
        }
    }
}
