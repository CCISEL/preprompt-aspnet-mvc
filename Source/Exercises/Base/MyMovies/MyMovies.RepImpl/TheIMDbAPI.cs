using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMovies.DomainModel;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace MyMovies.RepImpl
{
    public static class TheIMDbAPI
    {
        public static Movie SearchByTitle(string title)
        {
            String url = String.Format("http://www.imdbapi.com/?i=&t={0}&r=xml", title);
            WebRequest req = WebRequest.Create(url);

            String response = new StreamReader(req.GetResponse().GetResponseStream()).ReadToEnd();
            XElement respXml = XElement.Parse(response);
            respXml = respXml.Element("movie");
            Match m = new Regex(@"(\d+)\s+\w*\s+(\d+)\s+\w*", RegexOptions.IgnoreCase).
                Match(respXml.Attribute("runtime").Value);
            int idx = m.Groups.Count == 3 ? 1 : 0;
            string runtime = String.Format("{0}:{1}", m.Groups[idx].Captures[0], m.Groups[2].Captures[0]);
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
    }
}
