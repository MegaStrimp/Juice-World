using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Juice_World.Controllers.Test
{
    public class HelloWorldController : Controller
    {
        #region GET: /HelloWorld/
        #region Direct Approach
        /*
        public string Index()
        {
            return "This is my default action...";
        }
        */
        #endregion

        #region View Approach
        public IActionResult Index()
        {
            return View(); // Calls the controller's 'View' method
            // Since no view name has specified, the returning view will have the same name as 'Index()'
        }
        #endregion
        #endregion

        #region GET: /HelloWorld/Welcome/
        #region Direct Approach
        /*
        public string Welcome(string name, int numTimes = 1)
        {
            // 'HtmlEncoder.Default.Encode' protects the app from malicious input
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
            
        }
        */
        #endregion

        #region View Approach
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            // 'ViewData' object contains data that will be passed to the view
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
        #endregion
        #endregion
    }
}
