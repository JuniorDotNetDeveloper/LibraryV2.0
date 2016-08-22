using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Model.Models;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Infrastructure;
using Repository.Abstraction.Interfaces;

namespace LibraryV._2._0
{
    class Program
    {
        static Program()
        {
            NHibernateProfiler.Initialize();
            ServiceLocator.RegisterAll();
        }
        static void Main(string[] args)
        {
            var bookRepository = ServiceLocator.Resolver<IBookRepository>();
            var authorRepository = ServiceLocator.Resolver<IAuthorRepository>();
            var authorToBookRepository = ServiceLocator.Resolver<IAuthorToBookRepository>();
            var userRepository = ServiceLocator.Resolver<IUserRepository>();
            //var roleRepository = ServiceLocator.Resolver<IRoleRepository>();
            var userToRoleRepository = ServiceLocator.Resolver<IUserToRoleRepository>();
            var bookCategoryRepository = ServiceLocator.Resolver<IBookCategoryRepository>();
            var bookToTagRepository = ServiceLocator.Resolver<IBookToTagsRepository>();


            bookRepository.GetAllGroupedBookByCategoryName("It literature");
            bookRepository.GetAuthorsInOneCatgory();
            authorRepository.GetAuthorsWithSpecifyCategory("Drama");
            

            //var allReadedBooks = userRepository.GetAllReadedBooks();
            //var getCurrentBooks = userRepository.GetCurrentBooks(1);
            //var getBooks = bookRepository.GetAllBooks();

            //var category = bookCategoryRepository.GetById(4);
            ////var Author = authorRepository.GetById(4);
            //var Author = new Author("test112", "test12");
            //var book1 = new Book("C# for dummies authors", new DateTime(2009, 01, 01), category, new List<Author> { Author });
            //bookRepository.AddNewBook(book1);



            //InertUsersAnsRoles(userToRoleRepository);
            //InsertCategories(bookCategoryRepository);
            //InsertBooksAndAuthors(bookRepository, bookCategoryRepository);
            //InsertTags(bookToTagRepository, bookRepository);


            //var Author = authorRepository.GetById(6);


            //var book = new Book("testBook22", new DateTime(2012, 08, 21), bookCategoryRepository.GetByCategoryName(".net"), new List<Author> { new Author("vaim2", "vadi2") });
            //bookRepository.Save(book);

            //var Author = authorRepository.GetById(5);
            ////authorRepository.MakeDetached(Author);
            //var book1 = new Book("Pro C# 5.0 and the .NET 4.5 Framework, edition 6", new DateTime(2012, 08, 21), bookCategoryRepository.GetByCategoryName(".net"), new List<Author> { Author }, "This new edition of Pro C# 5.0 and the .NET 4.5 Platform has been completely revised and rewritten to reflect the latest changes to the C# language specification and new advances in the .NET Framework. You'll find new chapters covering the important new features that make .NET 4.5 the most comprehensive release yet.");
            //bookRepository.Save(book1);


            //var user = userRepository.GetById(1);
            //var userRoles = user.Roles.Select(x => x.Role);

            //var book = bookRepository.GetById(3);
            //var bookAuthor = book.Authors.Select(x => x.Author);

            //foreach (var item in bookAuthor)
            //{
            //    Console.WriteLine($"{item.FirstName} {item.LastName}");
            //}
            //foreach (var item in userRoles)
            //{
            //    Console.WriteLine(item.RoleName);
            //}
            //repository.Save(book);
            //DataInitializer();

            //userRepository.GetCurrentBooks();
        }

        private static void InsertBooksAndAuthors(IBookRepository bookRepository, IBookCategoryRepository bookCategoryRepository)
        {
            
            var author1 = /*authorRepository.GetById(2);*/ new Author("Jon", "Skit");
            //authorRepository.Save(author1);
            var author2 = new Author("Adam", "Freemann");
            //authorRepository.Save(author2);
            var author3 = new Author("Joseph", "Albahari");
            //authorRepository.Save(author3);
            var author4 = new Author("Ben", "Albahari");
            //authorRepository.Save(author4);


            var book1 = new Book("C# for dummies", new DateTime(2009, 01, 01), bookCategoryRepository.GetById(4), new List<Author> { author1 });
            var book2 = new Book("MVC5", new DateTime(2010, 01, 01), bookCategoryRepository.GetById(4), new List<Author> { author2 /*authorRepository.GetById(3)*/ });
            var book3 = new Book("C# Nutshell", new DateTime(2013, 01, 01), bookCategoryRepository.GetById(4), new List<Author> { author3, author4 /*authorRepository.GetById(4), authorRepository.GetById(5) */});
            bookRepository.AddNewBook(book1);
            bookRepository.Save(book2);
            bookRepository.Save(book3);


            //var authTobook = new AuthorToBook(book1, author1);
            //authorToBookRepository.Save(authTobook);

            //authTobook = new AuthorToBook(book2, author2);
            //authorToBookRepository.Save(authTobook);

            //authTobook = new AuthorToBook(book3, author3);
            //authorToBookRepository.Save(authTobook);

            //authTobook = new AuthorToBook(book3, author4);
            //authorToBookRepository.Save(authTobook);
        }
        private static void InertUsersAnsRoles(IUserToRoleRepository userToRoleRepository)
        {
            var user1 = new User("Vadim", "Abdullaev", "password", "Abdullaev@email");
            //userRepository.Save(user1);
            var user2 = new User("Jon", "Willson", "password", "Willson@email");
            //userRepository.Save(user2);
            var user3 = new User("Serge", "Ibaka", "password", "Ibaka@email");
            //userRepository.Save(user3);

            var roleAdmin = new Role("Admin");
            //roleRepository.Save(roleAdmin);

            var roleUser = new Role("User");
            //roleRepository.Save(roleUser);

            var user1ToAdmin = new UserToRole(user1, roleAdmin);
            userToRoleRepository.Save(user1ToAdmin);

            var user1ToUserRole = new UserToRole(user1, roleUser);
            userToRoleRepository.Save(user1ToUserRole);
            user1ToUserRole = new UserToRole(user2, roleUser);
            userToRoleRepository.Save(user1ToUserRole);
            user1ToUserRole = new UserToRole(user3, roleUser);
            userToRoleRepository.Save(user1ToUserRole);
        }
        private static void InsertCategories(IBookCategoryRepository bookCategoryRepository)
        {
            List<BookCategory> bookCategories = new List<BookCategory>
            {
                new BookCategory("None"),
                new BookCategory("Poem"),
                new BookCategory("Drama"),
                new BookCategory("IT Literature"),
                new BookCategory("History"),
                new BookCategory("Biography"),
                new BookCategory("Detective"),
                new BookCategory("Fantasy")
            };
            foreach (var category in bookCategories)
            {
                bookCategoryRepository.Save(category);
            }
        }
        private static void InsertTags(IBookToTagsRepository bookToTagRepository, IBookRepository bookRepo)
        {
            var tag1 = new Tag("C#");
            var tag2 = new Tag("MVC");
            var tag3 = new Tag("ORM");
            var tag4 = new Tag("CRM");
            var tag5 = new Tag("Pattern");

            var allBooks = bookRepo.GetAllBooks();

            var bookToTag = new BookToTags(allBooks.FirstOrDefault(x => x.Name == "C# for dummies"), tag5);
            bookToTagRepository.Save(bookToTag);
            bookToTag = new BookToTags(allBooks.FirstOrDefault(x => x.Name == "C# for dummies"), tag3);
            bookToTagRepository.Save(bookToTag);

            bookToTag = new BookToTags(allBooks.FirstOrDefault(x => x.Name == "MVC5"), tag2);
            bookToTagRepository.Save(bookToTag);
            bookToTag = new BookToTags(allBooks.FirstOrDefault(x => x.Name == "MVC5"), tag3);
            bookToTagRepository.Save(bookToTag);

            bookToTag = new BookToTags(allBooks.FirstOrDefault(x => x.Name == "C# Nutshell"), tag1);
            bookToTagRepository.Save(bookToTag);

        }

        //public static void DataInitializer()
        //{
        //    var bookRepository = ServiceLocator.Resolver<IBookRepository>();
        //    var authorRepository = ServiceLocator.Resolver<IAuthorRepository>();
        //    var authorToBookRepository = ServiceLocator.Resolver<IAuthorToBookRepository>();
        //    var userRepository = ServiceLocator.Resolver<IUserRepository>();
        //    var roleRepository = ServiceLocator.Resolver<IRoleRepository>();
        //    var userToRoleRepository = ServiceLocator.Resolver<IUserToRoleRepository>();
        //    var bookCategoryRepository = ServiceLocator.Resolver<IBookCategoryRepository>();


        //    List<BookCategory> bookCategories = new List<BookCategory>
        //    {
        //        new BookCategory("None"),
        //        new BookCategory("Poem"),
        //        new BookCategory("Drama"),
        //        new BookCategory("IT Literature"),
        //        new BookCategory("History"),
        //        new BookCategory("Biography"),
        //        new BookCategory("Detective"),
        //        new BookCategory("Fantasy")
        //    };


        //    List<Author> authorList = new List<Author>()
        //    {
        //        new Author("Alexandr", "Pushkin"),
        //        new Author("Lev", "Tolstoi"),
        //        new Author("Maxin", "Gorikii"),
        //        new Author("Alexei", "Tolstoi"),
        //        new Author("Nikolai", "Gogoli"),
        //        new Author("Mihail", "Lermontov"),
        //        new Author("Fedor", "Tiutchev"),
        //        new Author("Ivan", "Turgenev"),
        //        new Author("Afanasii", "Fet"),
        //        new Author("Fedor", "Dostoevskii"),
        //        new Author("Appolon", "Maikov"),
        //        new Author("Alexandr", "Ostrovskii"),
        //        new Author("Mihail", "Saltikov-Shedrin"),
        //        new Author("Nikolai", "Leskov"),
        //        new Author("Gleb", "Uspenskii"),
        //        new Author("NoBook", "Author")
        //    };

        //    var books = new List<Book>()
        //    {
        //    //   new Book(authorList.First(a => a.LastName == "Pushkin"), "Poltava", new DateTime(1829,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),

        //    //   new Book(authorList.First(a => a.LastName == "Pushkin"), "Evgenii Onegin", new DateTime(1833, 12,12), bookCategories.Find(x=>x.CategoryName == "Poem")),
        //    //   new Book(authorList.First(a => a.LastName == "Pushkin"), "Ruslan i Liudmila", new DateTime(1820,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),

        //    //   new Book(authorList.First(a => a.LastName == "Tolstoi" & a.FirstName == "Lev"), "Detstvo", new DateTime(1852,01,01), bookCategories.Find(x=>x.CategoryName == "Biography")),
        //    //   new Book(authorList.First(a => a.LastName == "Tolstoi" & a.FirstName == "Lev"), "Iunosti", new DateTime(1864,01,01), bookCategories.Find(x=>x.CategoryName == "History")),
        //    //   new Book(authorList.First(a => a.LastName == "Tolstoi" & a.FirstName == "Lev"), "Otrochestvo", new DateTime(1854,01,01), bookCategories.Find(x=>x.CategoryName == "Biography")),

        //    //   new Book(authorList.First(a => a.LastName == "Gorikii" & a.FirstName == "Maxin"), "Rasskazi staruha Izergili", new DateTime(1895,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
        //    //   new Book(authorList.First(a => a.LastName == "Gorikii" & a.FirstName == "Maxin"), "Deti Solntsa", new DateTime(1905,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
        //    //   new Book(authorList.First(a => a.LastName == "Gorikii" & a.FirstName == "Maxin"), "Vragi", new DateTime(1906,01,01), bookCategories.Find(x=>x.CategoryName == "History")),

        //    //   new Book(authorList.First(a => a.LastName == "Tolstoi" & a.FirstName == "Alexei"), "Chiudaki", new DateTime(1911,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
        //    //   new Book(authorList.First(a => a.LastName == "Tolstoi" & a.FirstName == "Alexei"), "Hromoi Barin", new DateTime(1912,01,01), bookCategories.Find(x=>x.CategoryName == "History")),
        //    //   new Book(authorList.First(a => a.LastName == "Tolstoi" & a.FirstName == "Alexei"), "Emigranti", new DateTime(1931,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),

        //    //   new Book(authorList.First(a => a.LastName == "Gogoli"), "Vechera na hutore bliz Dikaniki", new DateTime(1831,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
        //    //   new Book(authorList.First(a => a.LastName == "Gogoli"), "Revizor", new DateTime(1832,01,01), bookCategories.Find(x=>x.CategoryName == "Detective")),
        //    //   new Book(authorList.First(a => a.LastName == "Gogoli"), "Mertvie Dushi", new DateTime(1842,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),

        //    //   new Book(authorList.First(a => a.LastName == "Lermontov"), "Ispantsi", new DateTime(1830,01,01), bookCategories.Find(x=>x.CategoryName == "Biography")),
        //    //   new Book(authorList.First(a => a.LastName == "Lermontov"), "Tsigani", new DateTime(1828,01,01), bookCategories.Find(x=>x.CategoryName == "Biography")),
        //    //   new Book(authorList.First(a => a.LastName == "Lermontov"), "Dva Brata", new DateTime(1834,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),

        //    //   new Book(authorList.First(a => a.LastName == "Tiutchev" & a.FirstName == "Fedor"), "Nochnie Misli", new DateTime(1832,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
        //    //   new Book(authorList.First(a => a.LastName == "Tiutchev" & a.FirstName == "Fedor"), "Kto hochet miru chiujdim biti...", new DateTime(1830,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
        //    //   new Book(authorList.First(a => a.LastName == "Tiutchev" & a.FirstName == "Fedor"), "Privetsvie Duha", new DateTime(1827,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),

        //    //   new Book(authorList.First(a => a.LastName == "Turgenev" & a.FirstName == "Ivan"), "Asea", new DateTime(1857,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
        //    //   new Book(authorList.First(a => a.LastName == "Turgenev" & a.FirstName == "Ivan"), "Dva Priatelea", new DateTime(1853,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
        //    //   new Book(authorList.First(a => a.LastName == "Turgenev" & a.FirstName == "Ivan"), "Dim", new DateTime(1867,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),

        //    //   new Book(authorList.First(a => a.LastName == "Fet" & a.FirstName == "Afanasii"), "Talisman", new DateTime(1842,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
        //    //   new Book(authorList.First(a => a.LastName == "Fet" & a.FirstName == "Afanasii"), "Student", new DateTime(1884,01,01), bookCategories.Find(x=>x.CategoryName == "Detective")),

        //    //   new Book(authorList.First(a => a.LastName == "Dostoevskii" & a.FirstName == "Fedor"), "Idiot", new DateTime(1874,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
        //    //   new Book(authorList.First(a => a.LastName == "Dostoevskii" & a.FirstName == "Fedor"), "Igrok", new DateTime(1866,01,01), bookCategories.Find(x=>x.CategoryName == "History")),
        //    //   new Book(authorList.First(a => a.LastName == "Dostoevskii" & a.FirstName == "Fedor"), "Bratia Karamazovi", new DateTime(1880,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),

        //    //   new Book(authorList.First(a => a.LastName == "Maikov" & a.FirstName == "Appolon"), "Eho i Molchanie", new DateTime(1840,01,01), bookCategories.Find(x=>x.CategoryName == "Detective")),
        //    //   new Book(authorList.First(a => a.LastName == "Maikov" & a.FirstName == "Appolon"), "Ovidii", new DateTime(1841,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
        //    //   new Book(authorList.First(a => a.LastName == "Maikov" & a.FirstName == "Appolon"), "Ia bil eshe ditea", new DateTime(1840,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),

        //    //   new Book(authorList.First(a => a.LastName == "Ostrovskii" & a.FirstName == "Alexandr"), "Groza", new DateTime(1859,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
        //    //   new Book(authorList.First(a => a.LastName == "Ostrovskii" & a.FirstName == "Alexandr"), "Volki i Ovtsi", new DateTime(1875,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
        //    //   new Book(authorList.First(a => a.LastName == "Ostrovskii" & a.FirstName == "Alexandr"), "Goriachee Serdtse", new DateTime(1868,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),

        //    //   new Book(authorList.First(a => a.LastName == "Saltikov-Shedrin" & a.FirstName == "Mihail"), "Jenih", new DateTime(1857,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
        //    //   new Book(authorList.First(a => a.LastName == "Saltikov-Shedrin" & a.FirstName == "Mihail"), "Smerti Pazuhina", new DateTime(1859,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
        //    //   new Book(authorList.First(a => a.LastName == "Saltikov-Shedrin" & a.FirstName == "Mihail"), "Teni", new DateTime(1863,01,01), bookCategories.Find(x=>x.CategoryName == "History")),

        //    //   new Book(authorList.First(a => a.LastName == "Leskov" & a.FirstName == "Nikolai"), "Smeh i Gore", new DateTime(1871,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
        //    //   new Book(authorList.First(a => a.LastName == "Leskov" & a.FirstName == "Nikolai"), "Na Kraiu Sveta", new DateTime(1875,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
        //    //   new Book(authorList.First(a => a.LastName == "Leskov" & a.FirstName == "Nikolai"), "Levsha", new DateTime(1881,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),

        //    //   new Book(authorList.First(a => a.LastName == "Uspenskii" & a.FirstName == "Gleb"), "Krokodil Gena i ego Druzia", new DateTime(1970,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
        //    //   new Book(authorList.First(a => a.LastName == "Uspenskii" & a.FirstName == "Gleb"), "Diadia Fedor Kot i Peos", new DateTime(1974,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
        //    //   new Book(authorList.First(a => a.LastName == "Uspenskii" & a.FirstName == "Gleb"), "Vot tak Shkola", new DateTime(1968,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy"))
        //    };

        //    List<User> users = new List<User>
        //    {
        //        new User("Serge", "Ibaka", "password", "email", 373220000),
        //        new User("Kevin", "Durant", "password", "email", 373220000),
        //        new User("Rassel", "Westbrook", "password", "email"),
        //        new User("Steph", "Curry", "password", "email"),
        //        new User("Dramond", "Green", "password", "email", 373220000),
        //        new User("Dwayne", "Wade", "password", "email")
        //    };

        //    List<Role> roles = new List<Role>
        //    {
        //        new Role("Admin"),
        //        new Role("User")
        //    };
        //    foreach (var category in bookCategories)
        //    {
        //        bookCategoryRepository.Save(category);
        //    }

        //    foreach (var book in books)
        //    {
        //        bookRepository.Save(book);
        //        //var authorToBookEntity = new AuthorToBook(book: book, Author: book.Authors.First());
        //        //authorToBookRepository.Save(authorToBookEntity);
        //    }

        //    foreach (var Author in authorList)
        //    {
        //        authorRepository.Save(Author);
        //    }



        //    foreach (var role in roles)
        //    {
        //        roleRepository.Save(role);
        //    }

        //    foreach (var user in users)
        //    {
        //        userRepository.Save(user);
        //        var userToRole = new UserToRole(user, roles.First(x => x.RoleName == "User"));
        //        userToRoleRepository.Save(userToRole);
        //    }

        //    userToRoleRepository.Save(new UserToRole(users.First(x => x.FirstName == "Steph"),
        //        roles.First(r => r.RoleName == "Admin")));

        //}
    }
}
