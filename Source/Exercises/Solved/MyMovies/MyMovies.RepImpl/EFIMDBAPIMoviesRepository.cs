using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using MyMovies.Rep;

namespace MyMovies.RepImpl {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DomainModel;
    using DomainModel.ServicesRepositoryInterfaces;
    using Rep.Helpers.Collections;

    public class EFIMDBAPIMoviesRepository : EFDbContextRepository<Movie, int>, IMoviesRepository
    {
        public EFIMDBAPIMoviesRepository(MovieDbContext moviesContext) : base(moviesContext) { }

        #region Implementation of IMoviesRepository

        public Movie SearchByTitle(string title)
        {
            String url = String.Format("http://www.imdbapi.com/?i=&t={0}&r=xml", title);
            WebRequest req = WebRequest.Create(url);

            String response = new StreamReader(req.GetResponse().GetResponseStream()).ReadToEnd();
            XElement respXml = XElement.Parse(response);
            respXml = respXml.Element("movie");
            Match m = new Regex(@"(\d+)\s+hrs\s+(\d+)\s+mins", RegexOptions.IgnoreCase).
                Match(respXml.Attribute("runtime").Value);
            string runtime = String.Format("{0}:{1}", m.Groups[1].Captures[0], m.Groups[2].Captures[0]);
            return new Movie
                       {
                           Title = respXml.Attribute("title").Value,
                           Actors = respXml.Attribute("actors").Value,
                           Director = respXml.Attribute("director").Value,
                           Genre = respXml.Attribute("genre").Value,
                           Image = respXml.Attribute("poster").Value,
                           Year = Int32.Parse(respXml.Attribute("year").Value),
                           Runtime = TimeSpan.Parse(runtime),
                       };


        }

        #endregion
    }
}