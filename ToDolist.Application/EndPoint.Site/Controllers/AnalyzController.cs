using Application.Interfaces.FacadPatterns;
using Application.Services.TodoItem.Queries.GetCountForAnalyz;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EndPoint.Site.Controllers
{
    public class AnalyzController : Controller
    {
        private readonly ICartFacad CF;
        public AnalyzController(ICartFacad cF)
        {
            CF = cF;
        }

        public IActionResult index( )
        {
            try
            {
            var result = CF.GetCountAnalyzForService.Excute();
            return View(result);

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
       
    }
}
