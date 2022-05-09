using Microsoft.AspNetCore.Mvc;
using NumbersToWordsApp.Models;

namespace NumbersToWordsApp.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}