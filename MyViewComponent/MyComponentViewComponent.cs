using Microsoft.AspNetCore.Mvc;
using System;

namespace MyComponentViewComponent
{
    [ViewComponent(Name = "MyComponentViewComponent.MyComponent")]
    public class MyComponentViewComponent : ViewComponent
    {
        
        public MyComponentViewComponent() { }
        public IViewComponentResult Invoke(string message)
        {
            return View("Default", message);
        }
    }
}
