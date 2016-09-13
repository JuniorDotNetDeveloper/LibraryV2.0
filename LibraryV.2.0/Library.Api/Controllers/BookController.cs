using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Domain.Model.Models;
using Repository.Abstraction.Interfaces;

namespace Library.Api.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        // GET: api/Book
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Book/5
        public Book Get(int id)
        {
            var book = _bookRepository.GetById(id);
            return book;
        }

        // POST: api/Book
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Book/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Book/5
        public void Delete(int id)
        {
        }
        [Route("json/test")]
        public JsonResult<Book> MyJsonResult()
        {
            var book = _bookRepository.GetById(3);
            return Json(book);
        }
    }
}
