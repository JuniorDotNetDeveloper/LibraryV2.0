using Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models
{
    public class BookViewModel2
    {
        public long Id { get; set; }

        [Display(Name = "Titel")]
        public string Name { get; protected set; }

        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; protected set; }

        //[Display(Name = "Category")]
        public BookCategoryViewModel Category { get; protected set; }

        [DataType(DataType.Upload)]
        public string CoverLink { get; set; }
        public string Description { get; set; }
        public BookStatus Status { get; set; }
        public int? Rating { get; set; }
        public IList<AuthorViewModel> Authors { get; } = new List<AuthorViewModel>();

    }
}