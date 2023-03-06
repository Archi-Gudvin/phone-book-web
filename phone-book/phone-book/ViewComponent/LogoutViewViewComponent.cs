using Microsoft.AspNetCore.Mvc;

namespace phone_book.Component
{
    public class LogoutViewViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
