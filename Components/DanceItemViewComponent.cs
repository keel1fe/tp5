using Microsoft.AspNetCore.Mvc;
using tp5.Models;

namespace tp5.Views.Shared.Components.DanceItem
{
    public class DanceItemViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Dance dance)
        {
            return View(dance);
        }
    }
}