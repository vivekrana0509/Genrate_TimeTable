using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaynamicTimeTable.Models
{
    public class TimeTable
    {
       
        public int Days { get; set; }
        public int tot_sub { get; set; }
        public int Subject { get; set; }
        public int working_hour { get; set; }

        public List<SelectListItem> subjectlist { get; set; }
        
       
    }
}