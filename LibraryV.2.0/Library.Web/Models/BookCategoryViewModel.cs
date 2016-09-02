using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models
{
    public class BookCategoryViewModel
    {
        public long CategoryId { get; set; }
        [Display(Name = "Category")]
        public  string CategoryName { get; protected set; }
    }
}