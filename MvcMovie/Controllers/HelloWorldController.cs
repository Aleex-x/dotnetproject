using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers {
  public class HelloWorldController: Controller {
    // public string Index() {
    //   return "This is my default action...";
    // }

    public IActionResult Index() {
      return View();
    }

    // GET: /HelloWorld/Welcome/ 
    // Requires using System.Text.Encodings.Web;
    public string Welcome(string name, int numTimes = 1) {
      return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes} tontopoi");
    }

    public string NewMethod(string propiedad = "jesucristo", int otrapropiedad = 10) {
      return HtmlEncoder.Default.Encode($"{propiedad}, {otrapropiedad}");
    }
  }
}