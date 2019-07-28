using JWTImplementationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
//using System.Web;
using System.Web.Http;

namespace JWTImplementationMVC.Controllers
{
    [JWTAuthenticationFilter]
    public class DashboardController : ApiController
    {
        
        public HttpResponseMessage Get()
        {
            //checking role of Current User 
            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                var listOfbooks = GetAllBooks();

                return Request.CreateResponse(HttpStatusCode.OK, listOfbooks);
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized,"You are not allowed to see this");
        }

        private List<Books> GetAllBooks()
        {
            List<Books> book = new List<Books>();
            book.Add(new Books { Id = 1, Name = "ABC Books" });
            book.Add(new Books { Id = 2, Name = "XYZ Books" });
            book.Add(new Books { Id = 3, Name = "DEF Books" });
            return book;
        }

        public class Books
        {
            public int Id { get; set; }
            public string Name { get; set; }

        }

    }
}
