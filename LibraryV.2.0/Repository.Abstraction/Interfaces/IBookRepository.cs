using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction.Interfaces
{
    public interface IBookRepository<Book> : IRepository<Book> where Book : Entity
    {
        void ModifyBook(Book book);
        void AddNewBook(Book book);
    }
}
