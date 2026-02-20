using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents
{
    public class _NavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
