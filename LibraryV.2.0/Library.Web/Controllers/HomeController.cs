using Domain.Model.Models;
using Library.Web.Models;
using Repository.Abstraction.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _bookRepository;
        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        // GET: Home
        public ActionResult Index()
        {
            IList<Book> bookDetails = _bookRepository.GetAllBooks();
            return View(bookDetails);
        }
    }
}