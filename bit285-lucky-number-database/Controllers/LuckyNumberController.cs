using bit285_lucky_number_database.Models;
using lucky_number_database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bit285_lucky_number_database.Controllers
{
    public class LuckyNumberController : Controller
    {
        private LuckyNumberDbContext dbc = new LuckyNumberDbContext();
        // GET: LuckyNumber
        public ActionResult Spin()
        {
            LuckyNumber myLuck = new LuckyNumber { Number = 7, Balance = 4 };

            dbc.LuckyNumbers.Add(myLuck);

            dbc.SaveChanges();

            return View(myLuck);
        }

        [HttpPost]
        public ActionResult Spin(LuckyNumber lucky)
        {
           LuckyNumber databaseluck = dbc.LuckyNumbers.Where(m => m.Id == 1).First();
            // change balance in database
            if (databaseluck.Balance>0)
            {
                databaseluck.Balance -= 1;
            }

            databaseluck.Number = lucky.Number;
            dbc.SaveChanges();
            return View(databaseluck);
        }

        public ActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Index(LuckyNumber l)
        {
            dbc.LuckyNumbers.Add(l);
            dbc.SaveChanges();

            return View(l);

        }
       
    }
}