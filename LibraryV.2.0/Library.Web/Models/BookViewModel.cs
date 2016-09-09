using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Library.Web.Models
{
    public class BookViewModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string Name { get;  set; }

        [Required]
        [UIHint("DateTime")]
        [DataType("{0:dd - MM - yyyy}")]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; set; }
        
        [Display(Name = "Category")]
        public IList<SelectListItem> SelectItemListCategories { get; set; }

        [Display(Name = "Rating")]
        public int? Rating { get; set; }

        [Required]
        public long SelectedCategory { get; set; }
        public BookCategoryViewModel Category { get; set; }

        [DataType(DataType.Upload)]
        public string CoverLink { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }

        [Display(Name = "Authors")]
        public IList<SelectListItem> SelectListAuthors { get; set; }

        [Required]
        public IList<long> SelectedAuthor { get; set; }
        //public IList<AuthorViewModel> Authors { get; set; }

        [Obsolete]
        public BookViewModel() {}

        public BookViewModel(IList<SelectListItem> authors, IList<SelectListItem> categories)
        {
            if (authors == null)
                throw new ArgumentNullException($"{nameof(authors)} is null");
            if (categories == null)
                throw new ArgumentNullException($"{nameof(categories)} is null");
            SelectListAuthors = authors;
            SelectItemListCategories = categories;
        }
        public void SetCategories(IList<SelectListItem> categories)
        {
            if (categories == null)
                throw new ArgumentNullException($"{nameof(categories)} is null");
            SelectItemListCategories = categories;
        }

        public Book CustToBook(IList<Author> authors)
        {
            Book domainBook = new Book(Name, PublicationDate, new BookCategory(Category.CategoryName), authors, CoverLink, Description);
            return domainBook;
        }
    }
}