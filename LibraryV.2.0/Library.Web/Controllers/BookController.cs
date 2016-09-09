using Domain.Model.Models;
using Library.Web.Filters;
using Library.Web.Models;
using Repository.Abstraction.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
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
            //throw new System.Exception("test");

            IList<Book> bookDetails = _bookRepository.GetAllBooks();
            //var bookDetailsViewModel = AutoMapper.Mapper.Map<IList<Book>, IList<BookViewModel>>(bookDetails);
            var bookDetailsViewModel = bookDetails.Select(x => AutoMapper.Mapper.Map<Book, BookViewModel>(x));
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
            BookViewModel newbook = new BookViewModel(GetAuthorItemList(null), GetCategoryList(null));
            return PartialView("CreateBookPartial", newbook);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel newBook)
        {
            var categories = _bookCategoryRepository.GetById(newBook.SelectedCategory);
            var authors = _authorRepository.Collection.Where(x => newBook.SelectedAuthor.Contains<long>(x.Id)).ToList();
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var cat = _bookCategoryRepository.Collection.Single(x => x.Id == newBook.SelectedCategory);

            _bookRepository.AddNewBook(new Book(newBook.Name, newBook.PublicationDate, cat, authors, newBook.CoverLink, newBook.Description));
            return RedirectToAction("Index");
        }

        // GET: Book/Edit/5
        [AjaxOrChildActionOnly]
        public PartialViewResult Edit(long id)
        {
            var book = _bookRepository.GetById(id);
            //var authors = book.Authors.Select(x=>x.Author.Id);
            var viewModelbook = AutoMapper.Mapper.Map<Book, BookViewModel>(book);
            viewModelbook.SelectListAuthors = GetAuthorItemList(null);
            viewModelbook.SelectItemListCategories = GetCategoryList(book.Category.Id);
            //viewModelbook.SelectedAuthor = (IList<long>)authors;
            return PartialView(viewModelbook);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookViewModel collection)
        {
            var authors = _authorRepository.Collection.Where(x => collection.SelectedAuthor.Contains<long>(x.Id)).ToList();
            if (_bookRepository.GetById(collection.Id) != null)
            {
                var editBook = collection.CustToBook(authors);
                _bookRepository.Update(editBook);
            }
            return RedirectToAction("Index");
        }

        // GET: Book/Delete/5
        [AjaxOrChildActionOnly]
        public PartialViewResult Delete(long id)
        {
            var bookDomain = _bookRepository.GetById(id);
            var bookViewModel = AutoMapper.Mapper.Map<Book, BookViewModel>(bookDomain);
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

        [NonAction]
        private IList<SelectListItem> GetCategoryList(long? id)
        {

            IList<SelectListItem> selectedListCategories = _bookCategoryRepository.GetAllCategories().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            }).OrderBy(x => x.Text).ToList();
            if (id != null)
            {
                var selectedIndex = selectedListCategories.IndexOf(selectedListCategories.Where(x => x.Value == id.ToString()).First());
                selectedListCategories[selectedIndex].Selected = true;
            }

            return selectedListCategories;
        }


        //var a = AutoMapper.Mapper.Map<IList<CategoryDto>, IList<BookCategoryViewModel>>(categories);

        //var d = categories.Select((t, v) => new  SelectListItem { Text = t.CategoryName, Value = v });
        [NonAction]
        private IList<SelectListItem> GetAuthorItemList(long? id)
        {
            IList<SelectListItem> selectedListAuthors = _authorRepository.Collection.Select(x => new SelectListItem
            {
                Text = x.FullName,
                Value = x.Id.ToString()
            }).OrderBy(x => x.Text).ToList();
            if (id != null)
            {
                var selectedIndex = selectedListAuthors.IndexOf(selectedListAuthors.Where(x => x.Value == id.ToString()).First());
                selectedListAuthors[selectedIndex].Selected = true;
            }
            return selectedListAuthors;
        }
    }
}
