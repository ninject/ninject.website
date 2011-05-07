#region Using Directives

using System.Web.Mvc;

#endregion

namespace Ninject.Website.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult ShowNotFound()
        {
            return View( "404" );
        }

        public ViewResult Show( string code )
        {
            return View( "error" + code );
        }
    }
}