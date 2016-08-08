using System;
using System.Collections.Generic;
using Domain.Model.Models;
using Infrastructure;
using Repository.Abstraction.Interfaces;

namespace LibraryV._2._0
{
    class Program
    {
        static Program()
        {
            ServiceLocator.RegisterAll();
        }
        static void Main(string[] args)
        {
            var author = new Author("Jon", "White");
            var book = new Book(new List<Author> {author}, "C# for Dummies", DateTime.Now, "");
            var repository = ServiceLocator.Resolver<IBookRepository>();

            repository.Save(book);
            //repository.Save(book);
        }
    }
}
