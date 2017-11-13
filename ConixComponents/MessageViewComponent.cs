using Microsoft.AspNetCore.Mvc;
using System;

namespace ConixComponents
{
    [ViewComponent(Name = "ConixComponents.Message")]
    public class MessageViewComponent: ViewComponent
    {

        public MessageViewComponent()
        {

        }
        public IViewComponentResult Invoke(string message)
        {
            return View("Default", message);
        }
    }
}
