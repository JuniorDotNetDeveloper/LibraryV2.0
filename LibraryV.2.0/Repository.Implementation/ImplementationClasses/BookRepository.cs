using System.Collections.Generic;
using Domain.Model.Common;
using Domain.Model.Models;
using NHibernate;
using NHibernate.Transform;
using Repository.Abstraction.Interfaces;
using NHibernate.Criterion;
using Model.Dto.Dto;

namespace Repository.Implementation.ImplementationClasses
{
    public class BookRepository : Repository<Book>, 
        IBookRepository
    {
        public BookRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }

        public void ModifyBook(Book book)
        {
            throw new System.NotImplementedException();
        }

        public void AddNewBook(Book book)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.SaveOrUpdate(book);
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public IList<Book> FindAllBooksByLevel(DeveloperLevel level)
        {
            var books = _session.QueryOver<Book>()
                                   .Where(x => x.FilterLevel == level)
                                   .TransformUsing(Transformers.RootEntity)
                                   .List();
            return books;
        }

        public IList<Book> GetAllBooks()
        {
            var books = _session.QueryOver<Book>().List();
            return books;
        }

        /*
            select b.Name, b.CategoryName
	        from Book b
	        group by b.Name, b.CategoryName
	        having b.CategoryName = 'Fantasy'
        */
        public IList<Book> GetAllBooksBycategoryName(string categoryName)
        {
            Book b = null;
            BookCategory bookCategory = null;

            var bookList = _session.QueryOver(() => b)
                .JoinAlias(() => b.Category, () => bookCategory)
                .Where(() => bookCategory.CategoryName == categoryName)
                .List();

            return bookList;    
        }
        public IList<Book> GetAllGroupedBookByCategoryName(string category)
        {
            GroupedByCategoriesBooksDto output = null;
            Book b = null;
            BookCategory bookCategory = null;
            
            var books = _session.QueryOver(() => b)
                .JoinAlias(() => b.Category, () => bookCategory)
                .SelectList(list => list
                    .SelectGroup(x => x.Name)/*.WithAlias(() => output.BookName)*/
                    .SelectGroup(x => x.PublicationDate)/*.WithAlias(() => output.PublicationDate)*/
                    .SelectGroup(x => bookCategory.CategoryName)/*.WithAlias(() => output.CategoryName)*/)
                    //.Where(Restrictions.Eq(Projections.GroupProperty( Projections.Property( () => bookCategory.CategoryName)), category))

                    .TransformUsing(Transformers.AliasToBean<Book>())
                    .List<Book>();

            return books;
        }
        /*
                 	select a.FirstName, a.LastName, b.CategoryName
	                    from Author a
	                    join BookToAuthor ba on a.Id = ba.AuthorId
	                    join Book b on ba.BookId = b.Id
	                    group by a.FirstName, a.LastName, b.CategoryName
	                    having b.CategoryName in	(	
									                    select CategoryName from Category 
									                    where CategoryName = 'Fantasy'
								                    )
             */
        public IList<Model.Dto.Dto.AuthorsAndCategoriesDto> GetAuthorsInOneCatgory()
        {
            Model.Dto.Dto.AuthorsAndCategoriesDto authorsDto = null;
            Author authorAlies = null;
            Book bookAlies = null;
            BookCategory category = null;

            var subquery = QueryOver.Of<BookCategory>()
                .Where(x => x.CategoryName == "It")
                .Select(x => x.CategoryName);


            var authors = _session.QueryOver<AuthorToBook>()
                .JoinAlias(x => x.Author, () => authorAlies)
                .JoinAlias(x => x.Book, () => bookAlies)
                .JoinAlias(() => bookAlies.Category, () => category)
                .SelectList(list => list
                    .SelectGroup(x => authorAlies.FirstName)
                    .SelectGroup(x => authorAlies.LastName)
                    .SelectGroup(() => category.CategoryName))
                    
                    .WithSubquery.WhereProperty(() => category.CategoryName).In(subquery)
                    .TransformUsing(Transformers.AliasToBean<Model.Dto.Dto.AuthorsAndCategoriesDto>()) 
                    .List<Model.Dto.Dto.AuthorsAndCategoriesDto>();

            return authors;
        }
    }
}