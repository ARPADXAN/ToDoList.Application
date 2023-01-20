using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns;
using Application.Services.TodoItem.Queries.GetCountForAnalyz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class AnalyzController : Controller
    {
        private readonly IDataBaseContext DB;
        private readonly ICartFacad CF;
        public AnalyzController(ICartFacad cF ,IDataBaseContext dB)
        {
            DB = dB;
            CF = cF;
        }

        public IActionResult index( )
        {
            ViewBag.suspend = DB.StatusInCarts.Count(x => x.StatusId == 1);
            ViewBag.Nostart = DB.StatusInCarts.Count(x => x.StatusId == 2); ;
            ViewBag.InProgress = DB.StatusInCarts.Count(x => x.StatusId == 3);
            ViewBag.isComplete = DB.StatusInCarts.Count(x => x.StatusId == 4);
            ViewBag.General = DB.PriorityInCarts.Count(p => p.PriorityId == 1);
            ViewBag.Urgent = DB.PriorityInCarts.Count(p => p.PriorityId == 2);
            ViewBag.Critical = DB.PriorityInCarts.Count(p => p.PriorityId == 3);
            return View();
            //try
            //{
            //var result = CF.GetCountAnalyzForService.Excute();
            //return View(result);

            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.ToString());
            //}
        }
       
    }
}
