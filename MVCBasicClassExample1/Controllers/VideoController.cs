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
        //context object that stores the context passed in via constructor
        private readonly VideoDbContext _context;
        //Constructor has Db Context passed in 
        public VideoController(VideoDbContext Context)
        {
            _context = Context;
        }

        //GET: Video/Index
        public ViewResult Index()
        {
            //model is loaded with a list of Video Objects 
            //the context to is used fetch all video rows from the database  
            //creates a list of video objects to hold the data and is passed to the view
            var model = _context.Videos.ToList();
            return View(model);
        }
        //GET: Video/Details/5
        public IActionResult Details(int id)
        {
            //model is loaded with one video object 
            //the context is used to find  a row in the database with the corresponding id
            //the data is loaded into a video object to be passed to the view 
            var model = _context.Find<Video>(id);
            return View(model);
        }
        //GET: Videos/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //POST: Video/Create
        [HttpPost]
        public IActionResult Create(Video model)
        {
            //cheacks if the modelstate is valid accoridng to any rules enfocred by the data annotations
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            //Creates a new video object using a constructor and 
            //sets the title and genre attributes to those from the model passed into the method (the values from the form on the view)
            var video = new Video()
            {
                Title = model.Title,
                Genre = model.Genre
            };
            //You first need to use the add method to add the video object you have created 
            _context.Add(video);
            //savechanges will take all added videos and insert them into the database (Genreates SQL)
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = video.Id });
        }

        //GET: Video/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _context.Find<Video>(id);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        //POST: Video/Edit/5
        [HttpPost]
        public IActionResult Edit(int id,Video model)
        {
            var video = _context.Find<Video>(id);
            if(video== null||!ModelState.IsValid)
            {
                return View(model);
            }

            video.Title = model.Title;
            video.Genre = model.Genre;

            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        //GET: Video/Delete/5
        public IActionResult Delete(int id)
        {
            var model = _context.Find<Video>(id);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        //POST: Video/Delete/5
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var video = _context.Find<Video>(id);
            if (video == null)
                return View(video);

            _context.Videos.Remove(video);
            _context.SaveChanges();

            return  RedirectToAction("Index");
        }
    }
}
