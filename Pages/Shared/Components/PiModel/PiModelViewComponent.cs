using IpTest.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace IpTest.Pages.Shared.Components.PiModel
{
    public class PiModelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new ViewModel
            {
                PiModel = PiHelper.GetModel()
            });
        }
    }
}
