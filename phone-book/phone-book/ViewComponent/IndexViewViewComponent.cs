using Microsoft.AspNetCore.Mvc;

namespace phone_book.Component
{
    public class IndexViewViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
