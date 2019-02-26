using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCBasicClassExample1.Models;

namespace MVCBasicClassExample1.Controllers
{
    public class VideoController:Controller
    {
        public ViewResult index()
        {
            var model = new Video { Id = 1, Title = "Shrek", Genre = "Animated" };
            return View(model);
        }
        public string BestMovie()
        {
            return "Green Book";
        }
    }
}
