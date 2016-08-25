using Domain.Model.Common;
using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models
{
    public class BookDetailsViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Book")]
        public string Name { get; protected set; }
        public DateTime PublicationDate { get; protected set; }
        public BookCategory Category { get; protected set; }
        [DataType(DataType.Upload)]
        public string CoverLink { get; set; }
        public string Description { get; set; }
        public BookStatus Status { get; set; }
        public int? Rating { get; set; }

        //public BookDetailsViewModel GetBookDetailsDto(Book book)
        //{
        //    if (book == null)
        //        throw new ArgumentNullException($"{nameof(book)} is null");

        //    BookDetailsViewModel dto = new BookDetailsViewModel();
        //    dto.BookName = book.Name;
        //    dto.CoverLink = book.CoverLink;
        //    dto.Description = book.Description;
        //    dto.PublicationDate = book.PublicationDate;
        //    dto.Rating = book.Rating;
        //    dto.Category = book.Category;

        //    return dto;
        //}

        //public Book GetDominBook()
        //{
        //    Book domainBook = new Book(BookName, PublicationDate, Category, )
        //}
    }
}