using Microsoft.AspNetCore.Mvc;
using NumbersToWordsApp.Models;

namespace NumbersToWordsApp.Controllers
{
  public class ConvertController : Controller
  {
    [HttpGet("/convert")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost("/convert/display")]
    public ActionResult ConvertDisplay(int num)
    {
      NumberWithConversion numberWithConversion = new NumberWithConversion(num);
      return View(numberWithConversion);
    }
  }
}