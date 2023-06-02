using Microsoft.AspNetCore.Mvc;

namespace MegaOneMvc.Areas.Manage.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
