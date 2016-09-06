using Domain.Model.Models;
using Library.Web.Filters;
using Library.Web.Models;
using Repository.Abstraction.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    //[Authorize]
    public class BookController : Controller
    {
        private IBookRepository _bookRepository;
        private IBookCategoryRepository _bookCategoryRepository;
        private IAuthorRepository _authorRepository;

        public BookController(IBookRepository bookRepository, IBookCategoryRepository bookCategoryRepository, IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _bookCategoryRepository = bookCategoryRepository;
        }
    
        // GET: Book
        public ViewResult Index()
        {
            IList<Book> bookDetails = _bookRepository.GetAllBooks();
            var bookDetailsViewModel = AutoMapper.Mapper.Map<IList<Book>, IList<BookDetailsViewModel>>(bookDetails);
            return View(bookDetailsViewModel); 
        }

        // GET: Book/Details/5
        public ViewResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        
        [AjaxOrChildActionOnly]
        public PartialViewResult Create()
        {
            
            IList<SelectListItem> selectedListCategories = new List<SelectListItem>();
            var categories = _bookCategoryRepository.GetAllCategories();
            //var a = AutoMapper.Mapper.Map<IList<CategoryDto>, IList<BookCategoryViewModel>>(categories);
            foreach (var cat in categories)
            {
                selectedListCategories.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.Id.ToString() });
            }
            //var d = categories.Select((t, v) => new  SelectListItem { Text = t.CategoryName, Value = v });

            IList<SelectListItem> selectedListAuthors = new List<SelectListItem>();
            var authors = _authorRepository.Collection;
            foreach (var author in authors)
            {
                selectedListAuthors.Add(new SelectListItem { Text = author.FullName, Value = author.Id.ToString() });
            }
            CreateBookViewModel newbook = new CreateBookViewModel(selectedListAuthors, selectedListCategories);
            
            return PartialView("CreateBookPartial", newbook);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOrChildActionOnly]
        public ActionResult Create(CreateBookViewModel newBook)
        {

            var categories = _bookCategoryRepository.GetById(newBook.SelectedCategory);
            var authors = _authorRepository.Collection.Where(x => newBook.SelectedAuthor.Contains<long>(x.Id)).ToList();
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var cat = _bookCategoryRepository.Collection.Single(x => x.Id == newBook.SelectedCategory);

            _bookRepository.AddNewBook(new Book(newBook.Name, newBook.PublicationDate, cat, authors));
            return RedirectToAction("Index");
        }

        // GET: Book/Edit/5
        [AjaxOrChildActionOnly]
        [ValidateAntiForgeryToken]
        public ViewResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        [AjaxOrChildActionOnly]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        [AjaxOrChildActionOnly]
        public PartialViewResult Delete(long id)
        {
            var bookDomain = _bookRepository.GetById(id);
            var bookViewModel = AutoMapper.Mapper.Map<Book, BookDetailsViewModel>(bookDomain);
            return PartialView(bookViewModel);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult ConfirmDelete(long id)
        {
            try
            {
                if (_bookRepository.GetById(id) != null)
                    _bookRepository.DeleteById(id);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
