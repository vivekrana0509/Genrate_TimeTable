using DaynamicTimeTable.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaynamicTimeTable.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TimeTable tb)
        {
            int total_working = tb.Subject * tb.Days;
            tb.working_hour = total_working;
            return View("subjectname",tb);
        }
        [HttpPost]
        public ActionResult submitsubject(TimeTable tb)
        {
            int subjectcount = 0, subjectlist = 0;
            
            DataTable dt = new DataTable();
            for(int c = 1;c<=tb.Days;c++)
            {
                dt.Columns.Add("Day" + (c));
            }
            for(int r = 0; r < tb.Subject; r++)
            {
                dt.Rows.Add();
            }


            for(int r = 0;r<dt.Rows.Count;r++)
            {
                for(int c = 0;c < dt.Columns.Count;)
                {
                 
                    if(subjectlist < tb.subjectlist.Count)
                    {
                        int a = int.Parse(tb.subjectlist[subjectlist].Value);
                            if ((int.Parse(tb.subjectlist[subjectlist].Value)) > 0)
                            {
                                dt.Rows[r][c] = tb.subjectlist[subjectlist].Text;
                            tb.subjectlist[subjectlist].Value = (int.Parse(tb.subjectlist[subjectlist].Value) - 1).ToString();
                                c++;
                            }
                            else
                            {
                                subjectlist++;
                            }
                        
                        
                    }
                    else
                    {
                        break;
                    }

                }

            }
            Session["timetable"] = dt;
            return View("genratetimetable");
        }
     
    }
}