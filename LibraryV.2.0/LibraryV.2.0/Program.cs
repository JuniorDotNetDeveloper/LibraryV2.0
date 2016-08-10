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
            //NHibernateProfiler.Initialize();
            ServiceLocator.RegisterAll();
        }
        static void Main(string[] args)
        {
            //var author = new Author("Jon", "White");
            //var book = new Book(new List<Author> {author}, "C# for Dummies", DateTime.Now, "");
            var userRepository = ServiceLocator.Resolver<IUserRepository>();
            var bookRepository = ServiceLocator.Resolver<IBookRepository>();
            //repository.Save(book);
            DataInitializer();

            //var allBooksByLevel = bookRepository.FindAllBooksByLevel(Domain.Model.Common.DeveloperLevel.Beginner);
            //userRepository.GetCurrentBooks();
        }


        public static void DataInitializer()
        {
            var bookRepository = ServiceLocator.Resolver<IBookRepository>();
            var authorRepository = ServiceLocator.Resolver<IAuthorRepository>();
            var authorToBookRepository = ServiceLocator.Resolver<IAuthorToBookRepository>();
            var userRepository = ServiceLocator.Resolver<IUserRepository>();
            var roleRepository = ServiceLocator.Resolver<IRoleRepository>();
            var userToRoleRepository = ServiceLocator.Resolver<IUserToRoleRepository>();
            var bookCategoryRepository = ServiceLocator.Resolver<IBookCategoryRepository>();


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
            

            List<Author> authorList = new List<Author>()
            {
                new Author("Alexandr", "Pushkin"),
                new Author("Lev", "Tolstoi"),
                new Author("Maxin", "Gorikii"),
                new Author("Alexei", "Tolstoi"),
                new Author("Nikolai", "Gogoli"),
                new Author("Mihail", "Lermontov"),
                new Author("Fedor", "Tiutchev"),
                new Author("Ivan", "Turgenev"),
                new Author("Afanasii", "Fet"),
                new Author("Fedor", "Dostoevskii"),
                new Author("Appolon", "Maikov"),
                new Author("Alexandr", "Ostrovskii"),
                new Author("Mihail", "Saltikov-Shedrin"),
                new Author("Nikolai", "Leskov"),
                new Author("Gleb", "Uspenskii"),
                new Author("NoBook", "Author")
            };

            var books = new List<Book>()
            {
               new Book("Evgenii Onegin", new DateTime(1833, 12,12), bookCategories.Find(x=>x.CategoryName == "Poem")),
               new Book("Ruslan i Liudmila", new DateTime(1820,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
               new Book("Detstvo", new DateTime(1852,01,01), bookCategories.Find(x=>x.CategoryName == "Biography")),
               new Book("Iunosti", new DateTime(1864,01,01), bookCategories.Find(x=>x.CategoryName == "History")),
               new Book("Otrochestvo", new DateTime(1854,01,01), bookCategories.Find(x=>x.CategoryName == "Biography")),
               new Book("Rasskazi staruha Izergili", new DateTime(1895,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
               new Book("Deti Solntsa", new DateTime(1905,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
               new Book("Vragi", new DateTime(1906,01,01), bookCategories.Find(x=>x.CategoryName == "History")),
               new Book( "Chiudaki", new DateTime(1911,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
               new Book( "Hromoi Barin", new DateTime(1912,01,01), bookCategories.Find(x=>x.CategoryName == "History")),
               new Book( "Emigranti", new DateTime(1931,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
               new Book( "Vechera na hutore bliz Dikaniki", new DateTime(1831,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
               new Book( "Revizor", new DateTime(1832,01,01), bookCategories.Find(x=>x.CategoryName == "Detective")),
               new Book( "Mertvie Dushi", new DateTime(1842,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
               new Book( "Ispantsi", new DateTime(1830,01,01), bookCategories.Find(x=>x.CategoryName == "Biography")),
               new Book( "Tsigani", new DateTime(1828,01,01), bookCategories.Find(x=>x.CategoryName == "Biography")),
               new Book( "Dva Brata", new DateTime(1834,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
               new Book( "Nochnie Misli", new DateTime(1832,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
               new Book( "Kto hochet miru chiujdim biti...", new DateTime(1830,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
               new Book(  "Privetsvie Duha", new DateTime(1827,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
               new Book( "Asea", new DateTime(1857,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
               new Book( "Dva Priatelea", new DateTime(1853,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
               new Book( "Dim", new DateTime(1867,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
               new Book( "Talisman", new DateTime(1842,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
               new Book( "Student", new DateTime(1884,01,01), bookCategories.Find(x=>x.CategoryName == "Detective")),
               new Book( "Idiot", new DateTime(1874,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
               new Book( "Igrok", new DateTime(1866,01,01), bookCategories.Find(x=>x.CategoryName == "History")),
               new Book( "Bratia Karamazovi", new DateTime(1880,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
               new Book( "Eho i Molchanie", new DateTime(1840,01,01), bookCategories.Find(x=>x.CategoryName == "Detective")),
               new Book( "Ovidii", new DateTime(1841,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
               new Book( "Ia bil eshe ditea", new DateTime(1840,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
               new Book( "Groza", new DateTime(1859,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
               new Book( "Volki i Ovtsi", new DateTime(1875,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
               new Book( "Goriachee Serdtse", new DateTime(1868,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),    
               new Book( "Jenih", new DateTime(1857,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
               new Book( "Smerti Pazuhina", new DateTime(1859,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
               new Book( "Teni", new DateTime(1863,01,01), bookCategories.Find(x=>x.CategoryName == "History")),   
               new Book( "Smeh i Gore", new DateTime(1871,01,01), bookCategories.Find(x=>x.CategoryName == "Drama")),
               new Book( "Na Kraiu Sveta", new DateTime(1875,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")),
               new Book( "Levsha", new DateTime(1881,01,01), bookCategories.Find(x=>x.CategoryName == "Poem")), 
               new Book( "Krokodil Gena i ego Druzia", new DateTime(1970,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
               new Book( "Diadia Fedor Kot i Peos", new DateTime(1974,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy")),
               new Book( "Vot tak Shkola", new DateTime(1968,01,01), bookCategories.Find(x=>x.CategoryName == "Fantasy"))
            };

            List<User> users = new List<User>
            {
                new User("Serge", "Ibaka", "password", "email", 373220000),
                new User("Kevin", "Durant", "password", "email", 373220000),
                new User("Rassel", "Westbrook", "password", "email"),
                new User("Steph", "Curry", "password", "email"),
                new User("Dramond", "Green", "password", "email", 373220000),
                new User("Dwayne", "Wade", "password", "email")
            };

            List<Role> roles = new List<Role>
            {
                new Role("Admin"),
                new Role("User")
            };
            foreach (var category in bookCategories)
            {
                bookCategoryRepository.Save(category);
            }

            foreach (var book in books)
            {
                bookRepository.Save(book);
                var authorToBookEntity = new AuthorToBook(book: book, author: book.Authors.Select(x=>x.Author).First());
                authorToBookRepository.Save(authorToBookEntity);
            }

            foreach (var author in authorList)
            {
                authorRepository.Save(author);
            }

            foreach (var user in users)
            {
                
                var userToRole = new UserToRole(user, roles.First(x => x.RoleName == "User"));
                userToRoleRepository.Save(userToRole);
                //userRepository.Save(user);
            }

            foreach (var role in roles)
            {
                roleRepository.Save(role);
            }

            

            userToRoleRepository.Save(new UserToRole(users.First(x => x.FirstName == "Steph"),
                roles.First(r => r.RoleName == "Admin")));


            
        }
    }
}
