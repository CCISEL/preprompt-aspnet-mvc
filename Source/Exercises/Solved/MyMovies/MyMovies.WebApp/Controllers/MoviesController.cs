using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MyMovies.DomainModel;
using MyMovies.DomainModel.Services;
using MyMovies.WebApp.Models;

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
        public ActionResult Index(MovieFilter Filter)
        {
            return View(new IndexPresentationModel {Movies = _moviesService.GetAll(Filter), Filter = Filter});
        }


        public ActionResult Details(int id)
        {

            Movie movie = _moviesService.Get(id);
            if(movie == null)
            {
                //return RedirectToAction("Index");
                return View("NotFound", id);
            }
            return View(movie);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string Title, string  fill)
        {
            Movie newMovie;
            if(fill != null)
            {
                newMovie = _moviesService.Search(Title);
                ModelState.Remove("Title");
                return View(newMovie);
            }

            TryUpdateModel(newMovie  = new Movie());
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


        public ActionResult CreateComment(int movieId)
        {
            Comment c = new Comment {MovieID = movieId};
            return View(c);
        }

        [HttpPost]
        public ActionResult CreateComment(Comment c)
        {
            try
            {
                if (ModelState.IsValid) {
                    Movie movie = _moviesService.Get(c.MovieID);
                    movie.Comments.Add(c);
                    _moviesService.Update(movie);
                    return RedirectToRoute("Default", new { action = "Details", id = c.MovieID });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format("Edit Failure, inner exception: {0}", e));
            }

            return View(c);
        }

        public ActionResult Genres()
        {
            return Json(_moviesService.GetGenres(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Filter(MovieFilter Filter)
        {
            // The following projection is to Ugly to be shown. This is due the EF returned Movie subclass Proxy,
            // could not be Json serialized due to a circular reference.
            var movies = _moviesService.GetAll(Filter).Select(m => new Movie
                                                                       {
                                                                           Title = m.Title,
                                                                           Actors = m.Actors,
                                                                           Comments = m.Comments,
                                                                           Director = m.Director,
                                                                           Genre = m.Genre,
                                                                           ID = m.ID,
                                                                           Image = m.Image,
                                                                           Runtime = m.Runtime, 
                                                                           Year = m.Year
                                                                       });
             
            return Json(movies, JsonRequestBehavior.AllowGet);
        }
    }
}
