﻿using System;
using System.Web.Mvc;
using MyMovies.DomainModel;
using MyMovies.DomainModel.Services;

namespace MyMovies.WebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        //
        // GET: /Movies/
        public ActionResult Index()
        {
            return View(_moviesService.GetAllMovies());
        }


        public ActionResult Details(int id)
        {

            Movie movie = _moviesService.Get(id);
            if(movie == null)
            {
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                _moviesService.Add(newMovie);
                return RedirectToAction("Details", new { id = newMovie.ID });
            }
            else
            {
                return View(newMovie);
            }
        }


        public ActionResult Edit(int id)
        {
            return View(_moviesService.Get(id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(int id)
        {
            Movie movie = _moviesService.Get(id);
            try
            {
                UpdateModel(movie);
                if (ModelState.IsValid)
                {
                    _moviesService.Update(movie);
                    return RedirectToAction("Details", new {id});
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format("Edit Failure, inner exception: {0}", e));
            }

            return View(movie);
        }


        public ActionResult Delete(int id)
        {
            return View(_moviesService.Get(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _moviesService.Delete(id);
                TempData["Message"] = String.Format("Product with id {0} successfully removed!", id);
            }
            catch (ArgumentException e)
            {
                TempData["Message"] = e.Message;
            }

            return RedirectToAction("Index");
        }

    }
}