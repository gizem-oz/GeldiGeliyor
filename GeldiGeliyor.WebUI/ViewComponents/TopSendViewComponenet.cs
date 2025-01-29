using Microsoft.AspNetCore.Mvc;

namespace GeldiGeliyor.WebUI.ViewComponents
{
    public class TopSendViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            List<string> enCokSatilanOnUrun = new List<string>() 
            {
                "x","y","z"
            };
            return View(enCokSatilanOnUrun);
        }
    }
}
