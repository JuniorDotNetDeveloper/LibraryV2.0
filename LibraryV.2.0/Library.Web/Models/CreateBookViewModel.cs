using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Library.Web.Models
{
    public class CreateBookViewModel
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Titel")]
        public string Name { get; protected set; }
        [Required]
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; protected set; }
        [Required]
        //[Display(Name = "Category")]
        public IList<SelectListItem> Categories { get; protected set; }
        [DataType(DataType.Upload)]
        public string CoverLink { get; set; }
        public string Description { get; set; }
        public IList<SelectListItem> Authors { get; } = new List<SelectListItem>();

        public CreateBookViewModel(IList<SelectListItem> authors, IList<SelectListItem> categories)
        {
            if (authors == null)
                throw new ArgumentNullException($"{nameof(authors)} is null");
            if (categories == null)
                throw new ArgumentNullException($"{nameof(categories)} is null");
            Authors = authors;
            Categories = categories;
        }
        public void SetCategories (IList<SelectListItem> categories)
        {
            if (categories == null)
                throw new ArgumentNullException($"{nameof(categories)} is null");
            Categories = categories;
        }
    }
}