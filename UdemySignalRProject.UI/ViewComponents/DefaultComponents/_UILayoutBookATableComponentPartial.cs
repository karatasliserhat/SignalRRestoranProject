﻿using Microsoft.AspNetCore.Mvc;

namespace UdemySignalRProject.UI.ViewComponents.DefaultComponents
{
    public class _UILayoutBookATableComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}