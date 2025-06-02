using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Context
{
    public static class ModelBuiderData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
        }

        public static void SeedData(this BookDbContext context)
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Check if the database is empty and add sample data
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "F. Scott Fitzgerald" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "George Orwell" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Harper Lee" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Jane Austen" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Herman Melville" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "J.R.R. Tolkien" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Leo Tolstoy" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Fyodor Dostoevsky" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Aldous Huxley" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "J.D. Salinger" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Ray Bradbury" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Charlotte Brontë" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Homer" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "William Golding" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Charles Dickens" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Joseph Heller" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "John Steinbeck" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Gabriel García Márquez" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Kurt Vonnegut" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Emily Brontë" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Albert Camus" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Ernest Hemingway" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Frank Herbert" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Victor Hugo" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Franz Kafka" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Dante Alighieri" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Miguel de Cervantes" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Alexandre Dumas" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Oscar Wilde" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "William Faulkner" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Gustave Flaubert" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Mark Twain" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Nathaniel Hawthorne" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Bram Stoker" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Mary Shelley" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "H.G. Wells" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Robert Louis Stevenson" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Anthony Burgess" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Hermann Hesse" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Rudyard Kipling" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Lewis Carroll" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Kenneth Grahame" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "J.M. Barrie" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "E.B. White" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "C.S. Lewis" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Roald Dahl" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "J.K. Rowling" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Anne Frank" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Paulo Coelho" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Cormac McCarthy" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Yann Martel" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Khaled Hosseini" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Markus Zusak" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Stieg Larsson" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Gillian Flynn" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "John Green" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Suzanne Collins" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Veronica Roth" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Andy Weir" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Ernest Cline" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Margaret Atwood" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Patrick Rothfuss" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "George R.R. Martin" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Dan Brown" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Stephen King" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "S.E. Hinton" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Lois Lowry" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Louis Sachar" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Rick Riordan" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Frances Hodgson Burnett" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Louisa May Alcott" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Madeleine L'Engle" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Katherine Paterson" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Norton Juster" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Jack London" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Jules Verne" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Joseph Conrad" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Jonathan Swift" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Daniel Defoe" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Edgar Allan Poe" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Haruki Murakami" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Sylvia Plath" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Zora Neale Hurston" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Toni Morrison" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Ralph Ellison" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Chinua Achebe" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Alice Walker" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Maya Angelou" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Junot Díaz" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Kazuo Ishiguro" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Ian McEwan" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Erin Morgenstern" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Emily St. John Mandel" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Donna Tartt" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Anthony Doerr" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Delia Owens" },
                    new Author { AuthorId = Guid.NewGuid(), AuthorName = "Madeline Miller" }
                );
                context.SaveChanges();
            }
            if (!context.Countries.Any())
            {
                context.Countries.AddRange(
                    new Country { CountryId = Guid.NewGuid(), CountryName = "United States" },
                    new Country { CountryId = Guid.NewGuid(), CountryName = "Canada" },
                    new Country { CountryId = Guid.NewGuid(), CountryName = "Mexico" },
                    new Country { CountryId = Guid.NewGuid(), CountryName = "Japan" },
                    new Country { CountryId = Guid.NewGuid(), CountryName = "Germany" }
                );
                context.SaveChanges();
            }
            if (!context.Addresses.Any())
            {
                var countryDict = context.Countries.ToDictionary(c => c.CountryName, c => c.CountryId);
                context.Addresses.AddRange(
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "123", StreetName = "Main St", City = "New York", CountryId = countryDict["United States"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "456", StreetName = "Broadway", City = "Los Angeles", CountryId = countryDict["United States"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "789", StreetName = "5th Ave", City = "Chicago", CountryId = countryDict["United States"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "101", StreetName = "Maple St", City = "Toronto", CountryId = countryDict["Canada"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "202", StreetName = "Queen St", City = "Vancouver", CountryId = countryDict["Canada"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "303", StreetName = "King St", City = "Montreal", CountryId = countryDict["Canada"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "404", StreetName = "Oak St", City = "Mexico City", CountryId = countryDict["Mexico"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "505", StreetName = "Pine St", City = "Guadalajara", CountryId = countryDict["Mexico"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "606", StreetName = "Cedar St", City = "Monterrey", CountryId = countryDict["Mexico"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "707", StreetName = "Cherry St", City = "Tokyo", CountryId = countryDict["Japan"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "808", StreetName = "Sakura St", City = "Osaka", CountryId = countryDict["Japan"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "909", StreetName = "Hibiscus St", City = "Kyoto", CountryId = countryDict["Japan"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "111", StreetName = "Linden St", City = "Berlin", CountryId = countryDict["Germany"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "222", StreetName = "Blumen Str", City = "Munich", CountryId = countryDict["Germany"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "333", StreetName = "Rosen Str", City = "Frankfurt", CountryId = countryDict["Germany"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "444", StreetName = "Tulip St", City = "Hamburg", CountryId = countryDict["Germany"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "555", StreetName = "Magnolia St", City = "Dresden", CountryId = countryDict["Germany"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "666", StreetName = "Birch St", City = "Leipzig", CountryId = countryDict["Germany"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "777", StreetName = "Spruce St", City = "Cologne", CountryId = countryDict["Germany"] },
                    new Address { AddressId = Guid.NewGuid(), StreetNumber = "888", StreetName = "Palm St", City = "Stuttgart", CountryId = countryDict["Germany"] }
                );
                context.SaveChanges();
            }
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Fiction" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Non-Fiction" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Science Fiction" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Fantasy" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Mystery" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Horror" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Romance" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Biography" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "History" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Self-Help" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Cooking" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Travel" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Science" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Mathematics" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Art" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Music" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Sports" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Religion" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Philosophy" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Psychology" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Education" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Business" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Computers" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Health" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Fitness" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Crafts" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Hobbies" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Games" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Gardening" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Pets" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Parenting" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Family" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Relationships" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Humor" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Comics" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Graphic Novels" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Children" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Young Adult" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Teen" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Middle Grade" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Picture Books" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Board Books" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Classics" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Literature" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Thriller" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Historical Fiction" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Poetry" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Drama" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Adventure" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Children’s Literature" }
                );
                context.SaveChanges();
            }
            if (!context.Publishers.Any())
            {
                context.Publishers.AddRange(
                    new Publisher { PublisherId = Guid.NewGuid(), PublisherName = "Penguin Random House" },
                    new Publisher { PublisherId = Guid.NewGuid(), PublisherName = "HarperCollins" },
                    new Publisher { PublisherId = Guid.NewGuid(), PublisherName = "Simon & Schuster" },
                    new Publisher { PublisherId = Guid.NewGuid(), PublisherName = "Hachette Livre" },
                    new Publisher { PublisherId = Guid.NewGuid(), PublisherName = "Macmillan" },
                    new Publisher { PublisherId = Guid.NewGuid(), PublisherName = "Oxford University Press" },
                    new Publisher { PublisherId = Guid.NewGuid(), PublisherName = "Wiley" },
                    new Publisher { PublisherId = Guid.NewGuid(), PublisherName = "Scholastic" },
                    new Publisher { PublisherId = Guid.NewGuid(), PublisherName = "Cambridge University Press" },
                    new Publisher { PublisherId = Guid.NewGuid(), PublisherName = "Pearson" }
                );
                context.SaveChanges();
            }
            if (!context.BookLanguages.Any())
            {
                context.BookLanguages.AddRange(
                    new BookLanguage { LanguageId = Guid.NewGuid(), LanguageCode = "EN", LanguageName = "English" },
                    new BookLanguage { LanguageId = Guid.NewGuid(), LanguageCode = "FR", LanguageName = "French" },
                    new BookLanguage { LanguageId = Guid.NewGuid(), LanguageCode = "ES", LanguageName = "Spanish" },
                    new BookLanguage { LanguageId = Guid.NewGuid(), LanguageCode = "DE", LanguageName = "German" },
                    new BookLanguage { LanguageId = Guid.NewGuid(), LanguageCode = "JP", LanguageName = "Japanese" }
                );
                context.SaveChanges();
            }
            if (!context.OrderStatuses.Any())
            {
                context.OrderStatuses.AddRange(
                    new OrderStatus { StatusId = Guid.NewGuid(), StatusValue = "Pending", CreatedTime = DateTime.Now, ModifiedTime = DateTime.Now, IsDeleted = false },
                    new OrderStatus { StatusId = Guid.NewGuid(), StatusValue = "Processing", CreatedTime = DateTime.Now, ModifiedTime = DateTime.Now, IsDeleted = false },
                    new OrderStatus { StatusId = Guid.NewGuid(), StatusValue = "Shipped", CreatedTime = DateTime.Now, ModifiedTime = DateTime.Now, IsDeleted = false },
                    new OrderStatus { StatusId = Guid.NewGuid(), StatusValue = "Delivered", CreatedTime = DateTime.Now, ModifiedTime = DateTime.Now, IsDeleted = false },
                    new OrderStatus { StatusId = Guid.NewGuid(), StatusValue = "Cancelled", CreatedTime = DateTime.Now, ModifiedTime = DateTime.Now, IsDeleted = false },
                    new OrderStatus { StatusId = Guid.NewGuid(), StatusValue = "Returned", CreatedTime = DateTime.Now, ModifiedTime = DateTime.Now, IsDeleted = false }
                );
                context.SaveChanges();
            }
            if (!context.ShippingMethods.Any())
            {
                context.ShippingMethods.AddRange(
                    new ShippingMethod { MethodId = Guid.NewGuid(), MethodName = "Standard Shipping", Code = 1 },
                    new ShippingMethod { MethodId = Guid.NewGuid(), MethodName = "Express Shipping", Code = 2 },
                    new ShippingMethod { MethodId = Guid.NewGuid(), MethodName = "Next-Day Shipping", Code = 3 },
                    new ShippingMethod { MethodId = Guid.NewGuid(), MethodName = "International Shipping", Code = 4 },
                    new ShippingMethod { MethodId = Guid.NewGuid(), MethodName = "Same-Day Delivery", Code = 5 }
                );
                context.SaveChanges();
            }
            if (!context.Books.Any())
            {
                var languageDict = context.BookLanguages.ToDictionary(l => l.LanguageCode, l => l.LanguageId);
                var categoryDict = context.Categories.ToDictionary(c => c.CategoryName, c => c.CategoryId);
                var publisherDict = context.Publishers.ToDictionary(p => p.PublisherName, p => p.PublisherId);

                context.Books.AddRange(
                    new Book { BookId = Guid.NewGuid(), Title = "The Great Gatsby", IBSN13 = "9780743273565", ImageName = "gatsby.jpg", ImageUrl = "https://example.com/gatsby.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 180, PublicationDate = new DateTime(1925, 4, 10), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "1984", IBSN13 = "9780451524935", ImageName = "1984.jpg", ImageUrl = "https://example.com/1984.jpg", LanguageId = languageDict["EN"], Price = 15, NumPages = 328, PublicationDate = new DateTime(1949, 6, 8), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "To Kill a Mockingbird", IBSN13 = "9780060935467", ImageName = "mockingbird.jpg", ImageUrl = "https://example.com/mockingbird.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 281, PublicationDate = new DateTime(1960, 7, 11), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Pride and Prejudice", IBSN13 = "9780141439518", ImageName = "pride.jpg", ImageUrl = "https://example.com/pride.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 279, PublicationDate = new DateTime(1813, 1, 28), CategoryId = categoryDict["Romance"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Moby Dick", IBSN13 = "9781503280786", ImageName = "mobydick.jpg", ImageUrl = "https://example.com/mobydick.jpg", LanguageId = languageDict["EN"], Price = 12, NumPages = 635, PublicationDate = new DateTime(1851, 10, 18), CategoryId = categoryDict["Adventure"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Hobbit", IBSN13 = "9780547928227", ImageName = "hobbit.jpg", ImageUrl = "https://example.com/hobbit.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 310, PublicationDate = new DateTime(1937, 9, 21), CategoryId = categoryDict["Fantasy"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "War and Peace", IBSN13 = "9780199232765", ImageName = "warandpeace.jpg", ImageUrl = "https://example.com/warandpeace.jpg", LanguageId = languageDict["FR"], Price = 7, NumPages = 1225, PublicationDate = new DateTime(1869, 1, 1), CategoryId = categoryDict["Historical Fiction"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Crime and Punishment", IBSN13 = "9780143107637", ImageName = "crime.jpg", ImageUrl = "https://example.com/crime.jpg", LanguageId = languageDict["FR"], Price = 6, NumPages = 671, PublicationDate = new DateTime(1866, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Scholastic"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Brave New World", IBSN13 = "9780060850524", ImageName = "bravenewworld.jpg", ImageUrl = "https://example.com/bravenewworld.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 311, PublicationDate = new DateTime(1932, 1, 1), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Catcher in the Rye", IBSN13 = "9780316769488", ImageName = "catcher.jpg", ImageUrl = "https://example.com/catcher.jpg", LanguageId = languageDict["EN"], Price = 11, NumPages = 277, PublicationDate = new DateTime(1951, 7, 16), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Fahrenheit 451", IBSN13 = "9781451673319", ImageName = "fahrenheit451.jpg", ImageUrl = "https://example.com/fahrenheit451.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 194, PublicationDate = new DateTime(1953, 10, 19), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Jane Eyre", IBSN13 = "9780141441146", ImageName = "janeeyre.jpg", ImageUrl = "https://example.com/janeeyre.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 500, PublicationDate = new DateTime(1847, 10, 16), CategoryId = categoryDict["Romance"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Animal Farm", IBSN13 = "9780451526342", ImageName = "animalfarm.jpg", ImageUrl = "https://example.com/animalfarm.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 112, PublicationDate = new DateTime(1945, 8, 17), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Odyssey", IBSN13 = "9780140268867", ImageName = "odyssey.jpg", ImageUrl = "https://example.com/odyssey.jpg", LanguageId = languageDict["EN"], Price = 7, NumPages = 541, PublicationDate = new DateTime(1200, 1, 1), CategoryId = categoryDict["Classics"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Lord of the Flies", IBSN13 = "9780399501487", ImageName = "lordoftheflies.jpg", ImageUrl = "https://example.com/lordoftheflies.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 224, PublicationDate = new DateTime(1954, 9, 17), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Lord of the Rings", IBSN13 = "9780544003415", ImageName = "lotr.jpg", ImageUrl = "https://example.com/lotr.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 1178, PublicationDate = new DateTime(1954, 7, 29), CategoryId = categoryDict["Fantasy"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "A Tale of Two Cities", IBSN13 = "9780141439600", ImageName = "twocities.jpg", ImageUrl = "https://example.com/twocities.jpg", LanguageId = languageDict["EN"], Price = 12, NumPages = 489, PublicationDate = new DateTime(1859, 4, 30), CategoryId = categoryDict["Historical Fiction"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Brothers Karamazov", IBSN13 = "9780374528379", ImageName = "karamazov.jpg", ImageUrl = "https://example.com/karamazov.jpg", LanguageId = languageDict["FR"], Price = 10, NumPages = 796, PublicationDate = new DateTime(1880, 11, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Scholastic"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Catch-22", IBSN13 = "9781451626650", ImageName = "catch22.jpg", ImageUrl = "https://example.com/catch22.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 453, PublicationDate = new DateTime(1961, 11, 10), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Grapes of Wrath", IBSN13 = "9780143039433", ImageName = "grapesofwrath.jpg", ImageUrl = "https://example.com/grapesofwrath.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 464, PublicationDate = new DateTime(1939, 4, 14), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "One Hundred Years of Solitude", IBSN13 = "9780060883287", ImageName = "solitude.jpg", ImageUrl = "https://example.com/solitude.jpg", LanguageId = languageDict["ES"], Price = 10, NumPages = 417, PublicationDate = new DateTime(1967, 5, 30), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Slaughterhouse-Five", IBSN13 = "9780385333849", ImageName = "slaughterhouse.jpg", ImageUrl = "https://example.com/slaughterhouse.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 275, PublicationDate = new DateTime(1969, 3, 31), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Wuthering Heights", IBSN13 = "9780141439556", ImageName = "wutheringheights.jpg", ImageUrl = "https://example.com/wutheringheights.jpg", LanguageId = languageDict["EN"], Price = 6, NumPages = 416, PublicationDate = new DateTime(1847, 12, 1), CategoryId = categoryDict["Romance"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Stranger", IBSN13 = "9780679720201", ImageName = "stranger.jpg", ImageUrl = "https://example.com/stranger.jpg", LanguageId = languageDict["FR"], Price = 10, NumPages = 123, PublicationDate = new DateTime(1942, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Old Man and the Sea", IBSN13 = "9780684801223", ImageName = "oldmansea.jpg", ImageUrl = "https://example.com/oldmansea.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 127, PublicationDate = new DateTime(1952, 9, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Dune", IBSN13 = "9780441172719", ImageName = "dune.jpg", ImageUrl = "https://example.com/dune.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 896, PublicationDate = new DateTime(1965, 8, 1), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Les Misérables", IBSN13 = "9780451419439", ImageName = "lesmiserables.jpg", ImageUrl = "https://example.com/lesmiserables.jpg", LanguageId = languageDict["FR"], Price = 10, NumPages = 1463, PublicationDate = new DateTime(1862, 1, 1), CategoryId = categoryDict["Historical Fiction"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Metamorphosis", IBSN13 = "9780553213690", ImageName = "metamorphosis.jpg", ImageUrl = "https://example.com/metamorphosis.jpg", LanguageId = languageDict["DE"], Price = 12, NumPages = 201, PublicationDate = new DateTime(1915, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Scholastic"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Sun Also Rises", IBSN13 = "9780743297332", ImageName = "sunrises.jpg", ImageUrl = "https://example.com/sunrises.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 251, PublicationDate = new DateTime(1926, 10, 22), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "A Farewell to Arms", IBSN13 = "9780684801469", ImageName = "farewell.jpg", ImageUrl = "https://example.com/farewell.jpg", LanguageId = languageDict["EN"], Price = 15, NumPages = 332, PublicationDate = new DateTime(1929, 9, 27), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Divine Comedy", IBSN13 = "9780142437223", ImageName = "divinecomedy.jpg", ImageUrl = "https://example.com/divinecomedy.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 798, PublicationDate = new DateTime(1320, 1, 1), CategoryId = categoryDict["Poetry"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Don Quixote", IBSN13 = "9780060934347", ImageName = "donquixote.jpg", ImageUrl = "https://example.com/donquixote.jpg", LanguageId = languageDict["ES"], Price = 10, NumPages = 1072, PublicationDate = new DateTime(1605, 1, 16), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Iliad", IBSN13 = "9780140275360", ImageName = "iliad.jpg", ImageUrl = "https://example.com/iliad.jpg", LanguageId = languageDict["EN"], Price = 12, NumPages = 704, PublicationDate = new DateTime(1200, 1, 1), CategoryId = categoryDict["Classics"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Great Expectations", IBSN13 = "9780141439563", ImageName = "greatexpectations.jpg", ImageUrl = "https://example.com/greatexpectations.jpg", LanguageId = languageDict["EN"], Price = 7, NumPages = 544, PublicationDate = new DateTime(1861, 8, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Count of Monte Cristo", IBSN13 = "9780140449266", ImageName = "monte_cristo.jpg", ImageUrl = "https://example.com/monte_cristo.jpg", LanguageId = languageDict["FR"], Price = 11, NumPages = 1276, PublicationDate = new DateTime(1844, 1, 1), CategoryId = categoryDict["Adventure"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Trial", IBSN13 = "9780805209990", ImageName = "trial.jpg", ImageUrl = "https://example.com/trial.jpg", LanguageId = languageDict["DE"], Price = 9, NumPages = 255, PublicationDate = new DateTime(1925, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Anna Karenina", IBSN13 = "9780143035008", ImageName = "annakarenina.jpg", ImageUrl = "https://example.com/annakarenina.jpg", LanguageId = languageDict["FR"], Price = 10, NumPages = 864, PublicationDate = new DateTime(1878, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Picture of Dorian Gray", IBSN13 = "9780141439570", ImageName = "doriangray.jpg", ImageUrl = "https://example.com/doriangray.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 254, PublicationDate = new DateTime(1890, 7, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Scholastic"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Sound and the Fury", IBSN13 = "9780679732242", ImageName = "soundfury.jpg", ImageUrl = "https://example.com/soundfury.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 326, PublicationDate = new DateTime(1929, 10, 7), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Of Mice and Men", IBSN13 = "9780140177398", ImageName = "ofmiceandmen.jpg", ImageUrl = "https://example.com/ofmiceandmen.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 107, PublicationDate = new DateTime(1937, 2, 6), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Madame Bovary", IBSN13 = "9780140449129", ImageName = "madamebovary.jpg", ImageUrl = "https://example.com/madamebovary.jpg", LanguageId = languageDict["FR"], Price = 7, NumPages = 329, PublicationDate = new DateTime(1857, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Adventures of Huckleberry Finn", IBSN13 = "9780142437179", ImageName = "huckfinn.jpg", ImageUrl = "https://example.com/huckfinn.jpg", LanguageId = languageDict["EN"], Price = 12, NumPages = 366, PublicationDate = new DateTime(1884, 12, 10), CategoryId = categoryDict["Adventure"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Scarlet Letter", IBSN13 = "9780142437261", ImageName = "scarletletter.jpg", ImageUrl = "https://example.com/scarletletter.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 274, PublicationDate = new DateTime(1850, 3, 16), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Dracula", IBSN13 = "9780141439846", ImageName = "dracula.jpg", ImageUrl = "https://example.com/dracula.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 418, PublicationDate = new DateTime(1897, 5, 26), CategoryId = categoryDict["Horror"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Frankenstein", IBSN13 = "9780141439471", ImageName = "frankenstein.jpg", ImageUrl = "https://example.com/frankenstein.jpg", LanguageId = languageDict["EN"], Price = 11, NumPages = 280, PublicationDate = new DateTime(1818, 1, 1), CategoryId = categoryDict["Horror"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Time Machine", IBSN13 = "9780141439976", ImageName = "timemachine.jpg", ImageUrl = "https://example.com/timemachine.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 128, PublicationDate = new DateTime(1895, 1, 1), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Treasure Island", IBSN13 = "9780141321004", ImageName = "treasureisland.jpg", ImageUrl = "https://example.com/treasureisland.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 224, PublicationDate = new DateTime(1883, 11, 14), CategoryId = categoryDict["Adventure"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The War of the Worlds", IBSN13 = "9780141441030", ImageName = "waroftheworlds.jpg", ImageUrl = "https://example.com/waroftheworlds.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 192, PublicationDate = new DateTime(1898, 1, 1), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Scholastic"] },
                    new Book { BookId = Guid.NewGuid(), Title = "A Clockwork Orange", IBSN13 = "9780393312836", ImageName = "clockworkorange.jpg", ImageUrl = "https://example.com/clockworkorange.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 213, PublicationDate = new DateTime(1962, 1, 1), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Invisible Man", IBSN13 = "9780141439983", ImageName = "invisibleman.jpg", ImageUrl = "https://example.com/invisibleman.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 192, PublicationDate = new DateTime(1897, 1, 1), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Siddhartha", IBSN13 = "9780553208849", ImageName = "siddhartha.jpg", ImageUrl = "https://example.com/siddhartha.jpg", LanguageId = languageDict["DE"], Price = 12, NumPages = 152, PublicationDate = new DateTime(1922, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Jungle Book", IBSN13 = "9780141325293", ImageName = "junglebook.jpg", ImageUrl = "https://example.com/junglebook.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 277, PublicationDate = new DateTime(1894, 1, 1), CategoryId = categoryDict["Children"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Alice's Adventures in Wonderland", IBSN13 = "9780141439761", ImageName = "alice.jpg", ImageUrl = "https://example.com/alice.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 200, PublicationDate = new DateTime(1865, 11, 26), CategoryId = categoryDict["Children"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Wind in the Willows", IBSN13 = "9780143039099", ImageName = "windwillows.jpg", ImageUrl = "https://example.com/windwillows.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 256, PublicationDate = new DateTime(1908, 10, 8), CategoryId = categoryDict["Children"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Peter Pan", IBSN13 = "9780147508652", ImageName = "peterpan.jpg", ImageUrl = "https://example.com/peterpan.jpg", LanguageId = languageDict["EN"], Price = 12, NumPages = 200, PublicationDate = new DateTime(1911, 1, 1), CategoryId = categoryDict["Children"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Charlotte's Web", IBSN13 = "9780064400558", ImageName = "charlottesweb.jpg", ImageUrl = "https://example.com/charlottesweb.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 192, PublicationDate = new DateTime(1952, 10, 15), CategoryId = categoryDict["Children"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Lion, the Witch and the Wardrobe", IBSN13 = "9780064404990", ImageName = "narnia.jpg", ImageUrl = "https://example.com/narnia.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 208, PublicationDate = new DateTime(1950, 10, 16), CategoryId = categoryDict["Fantasy"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Matilda", IBSN13 = "9780142410370", ImageName = "matilda.jpg", ImageUrl = "https://example.com/matilda.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 240, PublicationDate = new DateTime(1988, 10, 1), CategoryId = categoryDict["Children"], PublisherId = publisherDict["Scholastic"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Harry Potter and the Sorcerer's Stone", IBSN13 = "9780590353427", ImageName = "harrypotter1.jpg", ImageUrl = "https://example.com/harrypotter1.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 309, PublicationDate = new DateTime(1997, 6, 26), CategoryId = categoryDict["Fantasy"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Diary of a Young Girl", IBSN13 = "9780553577129", ImageName = "annefrank.jpg", ImageUrl = "https://example.com/annefrank.jpg", LanguageId = languageDict["EN"], Price = 11, NumPages = 283, PublicationDate = new DateTime(1947, 6, 25), CategoryId = categoryDict["Biography"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Alchemist", IBSN13 = "9780061122415", ImageName = "alchemist.jpg", ImageUrl = "https://example.com/alchemist.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 208, PublicationDate = new DateTime(1988, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Road", IBSN13 = "9780307387899", ImageName = "road.jpg", ImageUrl = "https://example.com/road.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 287, PublicationDate = new DateTime(2006, 9, 26), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Life of Pi", IBSN13 = "9780156027328", ImageName = "lifeofpi.jpg", ImageUrl = "https://example.com/lifeofpi.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 326, PublicationDate = new DateTime(2001, 9, 11), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Kite Runner", IBSN13 = "9781594480003", ImageName = "kiterunner.jpg", ImageUrl = "https://example.com/kiterunner.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 371, PublicationDate = new DateTime(2003, 5, 29), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Book Thief", IBSN13 = "9780375842207", ImageName = "bookthief.jpg", ImageUrl = "https://example.com/bookthief.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 552, PublicationDate = new DateTime(2005, 3, 14), CategoryId = categoryDict["Historical Fiction"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Girl with the Dragon Tattoo", IBSN13 = "9780307454546", ImageName = "dragontattoo.jpg", ImageUrl = "https://example.com/dragontattoo.jpg", LanguageId = languageDict["EN"], Price = 12, NumPages = 465, PublicationDate = new DateTime(2005, 8, 1), CategoryId = categoryDict["Mystery"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Gone Girl", IBSN13 = "9780307588371", ImageName = "gonegirl.jpg", ImageUrl = "https://example.com/gonegirl.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 432, PublicationDate = new DateTime(2012, 6, 5), CategoryId = categoryDict["Thriller"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Fault in Our Stars", IBSN13 = "9780525478812", ImageName = "faultstars.jpg", ImageUrl = "https://example.com/faultstars.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 313, PublicationDate = new DateTime(2012, 1, 10), CategoryId = categoryDict["Young Adult"], PublisherId = publisherDict["Scholastic"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Hunger Games", IBSN13 = "9780439023481", ImageName = "hungergames.jpg", ImageUrl = "https://example.com/hungergames.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 374, PublicationDate = new DateTime(2008, 9, 14), CategoryId = categoryDict["Young Adult"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Divergent", IBSN13 = "9780062024039", ImageName = "divergent.jpg", ImageUrl = "https://example.com/divergent.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 487, PublicationDate = new DateTime(2011, 4, 25), CategoryId = categoryDict["Young Adult"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Martian", IBSN13 = "9780553418026", ImageName = "martian.jpg", ImageUrl = "https://example.com/martian.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 369, PublicationDate = new DateTime(2011, 9, 27), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Ready Player One", IBSN13 = "9780307887443", ImageName = "readyplayerone.jpg", ImageUrl = "https://example.com/readyplayerone.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 374, PublicationDate = new DateTime(2011, 8, 16), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Handmaid's Tale", IBSN13 = "9780385490818", ImageName = "handmaidstale.jpg", ImageUrl = "https://example.com/handmaidstale.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 311, PublicationDate = new DateTime(1985, 2, 1), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Name of the Wind", IBSN13 = "9780756404079", ImageName = "nameofthewind.jpg", ImageUrl = "https://example.com/nameofthewind.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 662, PublicationDate = new DateTime(2007, 3, 27), CategoryId = categoryDict["Fantasy"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "A Game of Thrones", IBSN13 = "9780553103540", ImageName = "gameofthrones.jpg", ImageUrl = "https://example.com/gameofthrones.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 694, PublicationDate = new DateTime(1996, 8, 1), CategoryId = categoryDict["Fantasy"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Da Vinci Code", IBSN13 = "9780307474278", ImageName = "davincicode.jpg", ImageUrl = "https://example.com/davincicode.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 689, PublicationDate = new DateTime(2003, 3, 18), CategoryId = categoryDict["Mystery"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Shining", IBSN13 = "9780307743657", ImageName = "shining.jpg", ImageUrl = "https://example.com/shining.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 659, PublicationDate = new DateTime(1977, 1, 28), CategoryId = categoryDict["Horror"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Stand", IBSN13 = "9780307743688", ImageName = "stand.jpg", ImageUrl = "https://example.com/stand.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 1153, PublicationDate = new DateTime(1978, 10, 3), CategoryId = categoryDict["Horror"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Misery", IBSN13 = "9781501143106", ImageName = "misery.jpg", ImageUrl = "https://example.com/misery.jpg", LanguageId = languageDict["EN"], Price = 12, NumPages = 310, PublicationDate = new DateTime(1987, 6, 8), CategoryId = categoryDict["Thriller"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Outsiders", IBSN13 = "9780142407332", ImageName = "outsiders.jpg", ImageUrl = "https://example.com/outsiders.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 192, PublicationDate = new DateTime(1967, 4, 24), CategoryId = categoryDict["Young Adult"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Giver", IBSN13 = "9780544336261", ImageName = "giver.jpg", ImageUrl = "https://example.com/giver.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 240, PublicationDate = new DateTime(1993, 1, 1), CategoryId = categoryDict["Young Adult"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Holes", IBSN13 = "9780440414803", ImageName = "holes.jpg", ImageUrl = "https://example.com/holes.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 233, PublicationDate = new DateTime(1998, 8, 20), CategoryId = categoryDict["Young Adult"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Percy Jackson & The Lightning Thief", IBSN13 = "9780786838653", ImageName = "percyjackson1.jpg", ImageUrl = "https://example.com/percyjackson1.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 377, PublicationDate = new DateTime(2005, 6, 28), CategoryId = categoryDict["Fantasy"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Chronicles of Narnia", IBSN13 = "9780066238500", ImageName = "narniacomplete.jpg", ImageUrl = "https://example.com/narniacomplete.jpg", LanguageId = languageDict["EN"], Price = 7, NumPages = 767, PublicationDate = new DateTime(1956, 1, 1), CategoryId = categoryDict["Fantasy"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Secret Garden", IBSN13 = "9780142437056", ImageName = "secretgarden.jpg", ImageUrl = "https://example.com/secretgarden.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 331, PublicationDate = new DateTime(1911, 1, 1), CategoryId = categoryDict["Children"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Little Women", IBSN13 = "9780142408766", ImageName = "littlewomen.jpg", ImageUrl = "https://example.com/littlewomen.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 816, PublicationDate = new DateTime(1868, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "A Wrinkle in Time", IBSN13 = "9780312367541", ImageName = "wrinkleintime.jpg", ImageUrl = "https://example.com/wrinkleintime.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 211, PublicationDate = new DateTime(1962, 1, 1), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Scholastic"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Bridge to Terabithia", IBSN13 = "9780064401845", ImageName = "terabithia.jpg", ImageUrl = "https://example.com/terabithia.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 128, PublicationDate = new DateTime(1977, 10, 21), CategoryId = categoryDict["Children"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Phantom Tollbooth", IBSN13 = "9780394820378", ImageName = "phantomtollbooth.jpg", ImageUrl = "https://example.com/phantomtollbooth.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 256, PublicationDate = new DateTime(1961, 1, 1), CategoryId = categoryDict["Children"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Call of the Wild", IBSN13 = "9780141321059", ImageName = "callofthewild.jpg", ImageUrl = "https://example.com/callofthewild.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 160, PublicationDate = new DateTime(1903, 1, 1), CategoryId = categoryDict["Adventure"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "White Fang", IBSN13 = "9780141321110", ImageName = "whitefang.jpg", ImageUrl = "https://example.com/whitefang.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 252, PublicationDate = new DateTime(1906, 1, 1), CategoryId = categoryDict["Adventure"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Three Musketeers", IBSN13 = "9780141442341", ImageName = "threemusketeers.jpg", ImageUrl = "https://example.com/threemusketeers.jpg", LanguageId = languageDict["FR"], Price = 8, NumPages = 674, PublicationDate = new DateTime(1844, 1, 1), CategoryId = categoryDict["Adventure"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Journey to the Center of the Earth", IBSN13 = "9780141441979", ImageName = "journeyearth.jpg", ImageUrl = "https://example.com/journeyearth.jpg", LanguageId = languageDict["FR"], Price = 10, NumPages = 240, PublicationDate = new DateTime(1864, 1, 1), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Twenty Thousand Leagues Under the Sea", IBSN13 = "9780141441955", ImageName = "20000leagues.jpg", ImageUrl = "https://example.com/20000leagues.jpg", LanguageId = languageDict["FR"], Price = 9, NumPages = 418, PublicationDate = new DateTime(1870, 1, 1), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Around the World in Eighty Days", IBSN13 = "9780141366296", ImageName = "aroundworld80.jpg", ImageUrl = "https://example.com/aroundworld80.jpg", LanguageId = languageDict["FR"], Price = 8, NumPages = 252, PublicationDate = new DateTime(1873, 1, 1), CategoryId = categoryDict["Adventure"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Mysterious Island", IBSN13 = "9780141441306", ImageName = "mysteriousisland.jpg", ImageUrl = "https://example.com/mysteriousisland.jpg", LanguageId = languageDict["FR"], Price = 7, NumPages = 514, PublicationDate = new DateTime(1874, 1, 1), CategoryId = categoryDict["Adventure"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Island of Doctor Moreau", IBSN13 = "9780141441023", ImageName = "doctormoreau.jpg", ImageUrl = "https://example.com/doctormoreau.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 176, PublicationDate = new DateTime(1896, 1, 1), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Scholastic"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Strange Case of Dr Jekyll and Mr Hyde", IBSN13 = "9780141439730", ImageName = "jekyllhyde.jpg", ImageUrl = "https://example.com/jekyllhyde.jpg", LanguageId = languageDict["EN"], Price = 11, NumPages = 144, PublicationDate = new DateTime(1886, 1, 1), CategoryId = categoryDict["Horror"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Heart of Darkness", IBSN13 = "9780141441672", ImageName = "heartofdarkness.jpg", ImageUrl = "https://example.com/heartofdarkness.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 112, PublicationDate = new DateTime(1899, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Gulliver's Travels", IBSN13 = "9780141439495", ImageName = "gulliverstravels.jpg", ImageUrl = "https://example.com/gulliverstravels.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 306, PublicationDate = new DateTime(1726, 10, 28), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Robinson Crusoe", IBSN13 = "9780141439822", ImageName = "robinsoncrusoe.jpg", ImageUrl = "https://example.com/robinsoncrusoe.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 320, PublicationDate = new DateTime(1719, 4, 25), CategoryId = categoryDict["Adventure"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Adventures of Tom Sawyer", IBSN13 = "9780143039563", ImageName = "tomsawyer.jpg", ImageUrl = "https://example.com/tomsawyer.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 244, PublicationDate = new DateTime(1876, 1, 1), CategoryId = categoryDict["Adventure"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Prince and the Pauper", IBSN13 = "9780140367492", ImageName = "princepauper.jpg", ImageUrl = "https://example.com/princepauper.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 224, PublicationDate = new DateTime(1881, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "A Connecticut Yankee in King Arthur's Court", IBSN13 = "9780140430646", ImageName = "connecticutyankee.jpg", ImageUrl = "https://example.com/connecticutyankee.jpg", LanguageId = languageDict["EN"], Price = 6, NumPages = 416, PublicationDate = new DateTime(1889, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Tell-Tale Heart", IBSN13 = "9780141397269", ImageName = "telltaleheart.jpg", ImageUrl = "https://example.com/telltaleheart.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 64, PublicationDate = new DateTime(1843, 1, 1), CategoryId = categoryDict["Horror"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Raven", IBSN13 = "9780146001109", ImageName = "raven.jpg", ImageUrl = "https://example.com/raven.jpg", LanguageId = languageDict["EN"], Price = 7, NumPages = 64, PublicationDate = new DateTime(1845, 1, 1), CategoryId = categoryDict["Poetry"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Fall of the House of Usher", IBSN13 = "9780140390032", ImageName = "houseofusher.jpg", ImageUrl = "https://example.com/houseofusher.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 64, PublicationDate = new DateTime(1839, 1, 1), CategoryId = categoryDict["Horror"], PublisherId = publisherDict["Scholastic"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Pit and the Pendulum", IBSN13 = "9780146000119", ImageName = "pitpendulum.jpg", ImageUrl = "https://example.com/pitpendulum.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 64, PublicationDate = new DateTime(1842, 1, 1), CategoryId = categoryDict["Horror"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Masque of the Red Death", IBSN13 = "9780140390032", ImageName = "masquereddeath.jpg", ImageUrl = "https://example.com/masquereddeath.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 64, PublicationDate = new DateTime(1842, 1, 1), CategoryId = categoryDict["Horror"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Plague", IBSN13 = "9780679720218", ImageName = "plague.jpg", ImageUrl = "https://example.com/plague.jpg", LanguageId = languageDict["FR"], Price = 8, NumPages = 308, PublicationDate = new DateTime(1947, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Norwegian Wood", IBSN13 = "9780375704024", ImageName = "norwegianwood.jpg", ImageUrl = "https://example.com/norwegianwood.jpg", LanguageId = languageDict["JP"], Price = 9, NumPages = 296, PublicationDate = new DateTime(1987, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Kafka on the Shore", IBSN13 = "9781400079278", ImageName = "kafkaontheshore.jpg", ImageUrl = "https://example.com/kafkaontheshore.jpg", LanguageId = languageDict["JP"], Price = 10, NumPages = 467, PublicationDate = new DateTime(2002, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Bell Jar", IBSN13 = "9780060837020", ImageName = "belljar.jpg", ImageUrl = "https://example.com/belljar.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 294, PublicationDate = new DateTime(1963, 1, 14), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Their Eyes Were Watching God", IBSN13 = "9780061120060", ImageName = "theireyes.jpg", ImageUrl = "https://example.com/theireyes.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 219, PublicationDate = new DateTime(1937, 9, 18), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Beloved", IBSN13 = "9781400033416", ImageName = "beloved.jpg", ImageUrl = "https://example.com/beloved.jpg", LanguageId = languageDict["EN"], Price = 6, NumPages = 324, PublicationDate = new DateTime(1987, 9, 2), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Invisible Man", IBSN13 = "9780679732761", ImageName = "invisibleman2.jpg", ImageUrl = "https://example.com/invisibleman2.jpg", LanguageId = languageDict["EN"], Price = 12, NumPages = 581, PublicationDate = new DateTime(1952, 4, 14), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Things Fall Apart", IBSN13 = "9780385474542", ImageName = "thingsfallapart.jpg", ImageUrl = "https://example.com/thingsfallapart.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 209, PublicationDate = new DateTime(1958, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Scholastic"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Color Purple", IBSN13 = "9780156028356", ImageName = "colorpurple.jpg", ImageUrl = "https://example.com/colorpurple.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 295, PublicationDate = new DateTime(1982, 1, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "I Know Why the Caged Bird Sings", IBSN13 = "9780812980028", ImageName = "cagedbird.jpg", ImageUrl = "https://example.com/cagedbird.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 289, PublicationDate = new DateTime(1969, 1, 1), CategoryId = categoryDict["Biography"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Brief Wondrous Life of Oscar Wao", IBSN13 = "9781594483295", ImageName = "oscarwao.jpg", ImageUrl = "https://example.com/oscarwao.jpg", LanguageId = languageDict["EN"], Price = 12, NumPages = 335, PublicationDate = new DateTime(2007, 9, 6), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Love in the Time of Cholera", IBSN13 = "9780307389732", ImageName = "cholera.jpg", ImageUrl = "https://example.com/cholera.jpg", LanguageId = languageDict["ES"], Price = 6, NumPages = 348, PublicationDate = new DateTime(1985, 1, 1), CategoryId = categoryDict["Romance"], PublisherId = publisherDict["HarperCollins"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Remains of the Day", IBSN13 = "9780679731726", ImageName = "remainsday.jpg", ImageUrl = "https://example.com/remainsday.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 245, PublicationDate = new DateTime(1989, 5, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Simon & Schuster"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Atonement", IBSN13 = "9780385721790", ImageName = "atonement.jpg", ImageUrl = "https://example.com/atonement.jpg", LanguageId = languageDict["EN"], Price = 12, NumPages = 351, PublicationDate = new DateTime(2001, 9, 1), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Hachette Livre"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Never Let Me Go", IBSN13 = "9781400078776", ImageName = "neverletmego.jpg", ImageUrl = "https://example.com/neverletmego.jpg", LanguageId = languageDict["EN"], Price = 8, NumPages = 288, PublicationDate = new DateTime(2005, 3, 1), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Macmillan"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Night Circus", IBSN13 = "9780307744432", ImageName = "nightcircus.jpg", ImageUrl = "https://example.com/nightcircus.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 387, PublicationDate = new DateTime(2011, 9, 13), CategoryId = categoryDict["Fantasy"], PublisherId = publisherDict["Oxford University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Station Eleven", IBSN13 = "9780385353304", ImageName = "stationeleven.jpg", ImageUrl = "https://example.com/stationeleven.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 333, PublicationDate = new DateTime(2014, 9, 9), CategoryId = categoryDict["Science Fiction"], PublisherId = publisherDict["Wiley"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Goldfinch", IBSN13 = "9780316055444", ImageName = "goldfinch.jpg", ImageUrl = "https://example.com/goldfinch.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 771, PublicationDate = new DateTime(2013, 10, 22), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Scholastic"] },
                    new Book { BookId = Guid.NewGuid(), Title = "All the Light We Cannot See", IBSN13 = "9781476746586", ImageName = "allthelight.jpg", ImageUrl = "https://example.com/allthelight.jpg", LanguageId = languageDict["EN"], Price = 9, NumPages = 531, PublicationDate = new DateTime(2014, 5, 6), CategoryId = categoryDict["Historical Fiction"], PublisherId = publisherDict["Cambridge University Press"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Where the Crawdads Sing", IBSN13 = "9780735219090", ImageName = "crawdads.jpg", ImageUrl = "https://example.com/crawdads.jpg", LanguageId = languageDict["EN"], Price = 7, NumPages = 368, PublicationDate = new DateTime(2018, 8, 14), CategoryId = categoryDict["Fiction"], PublisherId = publisherDict["Pearson"] },
                    new Book { BookId = Guid.NewGuid(), Title = "Circe", IBSN13 = "9780316556347", ImageName = "circe.jpg", ImageUrl = "https://example.com/circe.jpg", LanguageId = languageDict["EN"], Price = 12, NumPages = 393, PublicationDate = new DateTime(2018, 4, 10), CategoryId = categoryDict["Fantasy"], PublisherId = publisherDict["Penguin Random House"] },
                    new Book { BookId = Guid.NewGuid(), Title = "The Song of Achilles", IBSN13 = "9780062060624", ImageName = "songofachilles.jpg", ImageUrl = "https://example.com/songofachilles.jpg", LanguageId = languageDict["EN"], Price = 10, NumPages = 369, PublicationDate = new DateTime(2011, 9, 20), CategoryId = categoryDict["Historical Fiction"], PublisherId = publisherDict["HarperCollins"] }
                );
                context.SaveChanges();
            }
            if (!context.BookAuthors.Any())
            {
                var bookDict = context.Books.ToDictionary(b => b.Title, b => b.BookId);
                var authorDict = context.Authors.ToDictionary(a => a.AuthorName, a => a.AuthorId);
                //var listBookAuthors = new List<BookAuthor> {
                //    };
                context.BookAuthors.AddRange(
                    //listBookAuthors
                    new BookAuthor { BookId = bookDict["The Great Gatsby"], AuthorId = authorDict["F. Scott Fitzgerald"] },
                    new BookAuthor { BookId = bookDict["1984"], AuthorId = authorDict["George Orwell"] },
                    new BookAuthor { BookId = bookDict["To Kill a Mockingbird"], AuthorId = authorDict["Harper Lee"] },
                    new BookAuthor { BookId = bookDict["Pride and Prejudice"], AuthorId = authorDict["Jane Austen"] },
                    new BookAuthor { BookId = bookDict["Moby Dick"], AuthorId = authorDict["Herman Melville"] },
                    new BookAuthor { BookId = bookDict["The Hobbit"], AuthorId = authorDict["J.R.R. Tolkien"] },
                    new BookAuthor { BookId = bookDict["War and Peace"], AuthorId = authorDict["Leo Tolstoy"] },
                    new BookAuthor { BookId = bookDict["Crime and Punishment"], AuthorId = authorDict["Fyodor Dostoevsky"] },
                    new BookAuthor { BookId = bookDict["Brave New World"], AuthorId = authorDict["Aldous Huxley"] },
                    new BookAuthor { BookId = bookDict["The Catcher in the Rye"], AuthorId = authorDict["J.D. Salinger"] },
                    new BookAuthor { BookId = bookDict["Fahrenheit 451"], AuthorId = authorDict["Ray Bradbury"] },
                    new BookAuthor { BookId = bookDict["Jane Eyre"], AuthorId = authorDict["Charlotte Brontë"] },
                    new BookAuthor { BookId = bookDict["Animal Farm"], AuthorId = authorDict["George Orwell"] },
                    new BookAuthor { BookId = bookDict["The Odyssey"], AuthorId = authorDict["Homer"] },
                    new BookAuthor { BookId = bookDict["Lord of the Flies"], AuthorId = authorDict["William Golding"] },
                    new BookAuthor { BookId = bookDict["The Lord of the Rings"], AuthorId = authorDict["J.R.R. Tolkien"] },
                    new BookAuthor { BookId = bookDict["A Tale of Two Cities"], AuthorId = authorDict["Charles Dickens"] },
                    new BookAuthor { BookId = bookDict["The Brothers Karamazov"], AuthorId = authorDict["Fyodor Dostoevsky"] },
                    new BookAuthor { BookId = bookDict["Catch-22"], AuthorId = authorDict["Joseph Heller"] },
                    new BookAuthor { BookId = bookDict["The Grapes of Wrath"], AuthorId = authorDict["John Steinbeck"] },
                    new BookAuthor { BookId = bookDict["One Hundred Years of Solitude"], AuthorId = authorDict["Gabriel García Márquez"] },
                    new BookAuthor { BookId = bookDict["Slaughterhouse-Five"], AuthorId = authorDict["Kurt Vonnegut"] },
                    new BookAuthor { BookId = bookDict["Wuthering Heights"], AuthorId = authorDict["Emily Brontë"] },
                    new BookAuthor { BookId = bookDict["The Stranger"], AuthorId = authorDict["Albert Camus"] },
                    new BookAuthor { BookId = bookDict["The Old Man and the Sea"], AuthorId = authorDict["Ernest Hemingway"] },
                    new BookAuthor { BookId = bookDict["Dune"], AuthorId = authorDict["Frank Herbert"] },
                    new BookAuthor { BookId = bookDict["Les Misérables"], AuthorId = authorDict["Victor Hugo"] },
                    new BookAuthor { BookId = bookDict["The Metamorphosis"], AuthorId = authorDict["Franz Kafka"] },
                    new BookAuthor { BookId = bookDict["The Sun Also Rises"], AuthorId = authorDict["Ernest Hemingway"] },
                    new BookAuthor { BookId = bookDict["A Farewell to Arms"], AuthorId = authorDict["Ernest Hemingway"] },
                    new BookAuthor { BookId = bookDict["The Divine Comedy"], AuthorId = authorDict["Dante Alighieri"] },
                    new BookAuthor { BookId = bookDict["Don Quixote"], AuthorId = authorDict["Miguel de Cervantes"] },
                    new BookAuthor { BookId = bookDict["The Iliad"], AuthorId = authorDict["Homer"] },
                    new BookAuthor { BookId = bookDict["Great Expectations"], AuthorId = authorDict["Charles Dickens"] },
                    new BookAuthor { BookId = bookDict["The Count of Monte Cristo"], AuthorId = authorDict["Alexandre Dumas"] },
                    new BookAuthor { BookId = bookDict["The Trial"], AuthorId = authorDict["Franz Kafka"] },
                    new BookAuthor { BookId = bookDict["Anna Karenina"], AuthorId = authorDict["Leo Tolstoy"] },
                    new BookAuthor { BookId = bookDict["The Picture of Dorian Gray"], AuthorId = authorDict["Oscar Wilde"] },
                    new BookAuthor { BookId = bookDict["The Sound and the Fury"], AuthorId = authorDict["William Faulkner"] },
                    new BookAuthor { BookId = bookDict["Of Mice and Men"], AuthorId = authorDict["John Steinbeck"] },
                    new BookAuthor { BookId = bookDict["Madame Bovary"], AuthorId = authorDict["Gustave Flaubert"] },
                    new BookAuthor { BookId = bookDict["The Adventures of Huckleberry Finn"], AuthorId = authorDict["Mark Twain"] },
                    new BookAuthor { BookId = bookDict["The Scarlet Letter"], AuthorId = authorDict["Nathaniel Hawthorne"] },
                    new BookAuthor { BookId = bookDict["Dracula"], AuthorId = authorDict["Bram Stoker"] },
                    new BookAuthor { BookId = bookDict["Frankenstein"], AuthorId = authorDict["Mary Shelley"] },
                    new BookAuthor { BookId = bookDict["The Time Machine"], AuthorId = authorDict["H.G. Wells"] },
                    new BookAuthor { BookId = bookDict["Treasure Island"], AuthorId = authorDict["Robert Louis Stevenson"] },
                    new BookAuthor { BookId = bookDict["The War of the Worlds"], AuthorId = authorDict["H.G. Wells"] },
                    new BookAuthor { BookId = bookDict["A Clockwork Orange"], AuthorId = authorDict["Anthony Burgess"] },
                    new BookAuthor { BookId = bookDict["The Invisible Man"], AuthorId = authorDict["H.G. Wells"] },
                    new BookAuthor { BookId = bookDict["Siddhartha"], AuthorId = authorDict["Hermann Hesse"] },
                    new BookAuthor { BookId = bookDict["The Jungle Book"], AuthorId = authorDict["Rudyard Kipling"] },
                    new BookAuthor { BookId = bookDict["Alice's Adventures in Wonderland"], AuthorId = authorDict["Lewis Carroll"] },
                    new BookAuthor { BookId = bookDict["The Wind in the Willows"], AuthorId = authorDict["Kenneth Grahame"] },
                    new BookAuthor { BookId = bookDict["Peter Pan"], AuthorId = authorDict["J.M. Barrie"] },
                    new BookAuthor { BookId = bookDict["Charlotte's Web"], AuthorId = authorDict["E.B. White"] },
                    new BookAuthor { BookId = bookDict["The Lion, the Witch and the Wardrobe"], AuthorId = authorDict["C.S. Lewis"] },
                    new BookAuthor { BookId = bookDict["Matilda"], AuthorId = authorDict["Roald Dahl"] },
                    new BookAuthor { BookId = bookDict["Harry Potter and the Sorcerer's Stone"], AuthorId = authorDict["J.K. Rowling"] },
                    new BookAuthor { BookId = bookDict["The Diary of a Young Girl"], AuthorId = authorDict["Anne Frank"] },
                    new BookAuthor { BookId = bookDict["The Alchemist"], AuthorId = authorDict["Paulo Coelho"] },
                    new BookAuthor { BookId = bookDict["The Road"], AuthorId = authorDict["Cormac McCarthy"] },
                    new BookAuthor { BookId = bookDict["Life of Pi"], AuthorId = authorDict["Yann Martel"] },
                    new BookAuthor { BookId = bookDict["The Kite Runner"], AuthorId = authorDict["Khaled Hosseini"] },
                    new BookAuthor { BookId = bookDict["The Book Thief"], AuthorId = authorDict["Markus Zusak"] },
                    new BookAuthor { BookId = bookDict["The Girl with the Dragon Tattoo"], AuthorId = authorDict["Stieg Larsson"] },
                    new BookAuthor { BookId = bookDict["Gone Girl"], AuthorId = authorDict["Gillian Flynn"] },
                    new BookAuthor { BookId = bookDict["The Fault in Our Stars"], AuthorId = authorDict["John Green"] },
                    new BookAuthor { BookId = bookDict["The Hunger Games"], AuthorId = authorDict["Suzanne Collins"] },
                    new BookAuthor { BookId = bookDict["Divergent"], AuthorId = authorDict["Veronica Roth"] },
                    new BookAuthor { BookId = bookDict["The Martian"], AuthorId = authorDict["Andy Weir"] },
                    new BookAuthor { BookId = bookDict["Ready Player One"], AuthorId = authorDict["Ernest Cline"] },
                    new BookAuthor { BookId = bookDict["The Handmaid's Tale"], AuthorId = authorDict["Margaret Atwood"] },
                    new BookAuthor { BookId = bookDict["The Name of the Wind"], AuthorId = authorDict["Patrick Rothfuss"] },
                    new BookAuthor { BookId = bookDict["A Game of Thrones"], AuthorId = authorDict["George R.R. Martin"] },
                    new BookAuthor { BookId = bookDict["The Da Vinci Code"], AuthorId = authorDict["Dan Brown"] },
                    new BookAuthor { BookId = bookDict["The Shining"], AuthorId = authorDict["Stephen King"] },
                    new BookAuthor { BookId = bookDict["The Stand"], AuthorId = authorDict["Stephen King"] },
                    new BookAuthor { BookId = bookDict["Misery"], AuthorId = authorDict["Stephen King"] },
                    new BookAuthor { BookId = bookDict["The Outsiders"], AuthorId = authorDict["S.E. Hinton"] },
                    new BookAuthor { BookId = bookDict["The Giver"], AuthorId = authorDict["Lois Lowry"] },
                    new BookAuthor { BookId = bookDict["Holes"], AuthorId = authorDict["Louis Sachar"] },
                    new BookAuthor { BookId = bookDict["Percy Jackson & The Lightning Thief"], AuthorId = authorDict["Rick Riordan"] },
                    new BookAuthor { BookId = bookDict["The Chronicles of Narnia"], AuthorId = authorDict["C.S. Lewis"] },
                    new BookAuthor { BookId = bookDict["The Secret Garden"], AuthorId = authorDict["Frances Hodgson Burnett"] },
                    new BookAuthor { BookId = bookDict["Little Women"], AuthorId = authorDict["Louisa May Alcott"] },
                    new BookAuthor { BookId = bookDict["A Wrinkle in Time"], AuthorId = authorDict["Madeleine L'Engle"] },
                    new BookAuthor { BookId = bookDict["Bridge to Terabithia"], AuthorId = authorDict["Katherine Paterson"] },
                    new BookAuthor { BookId = bookDict["The Phantom Tollbooth"], AuthorId = authorDict["Norton Juster"] },
                    new BookAuthor { BookId = bookDict["The Call of the Wild"], AuthorId = authorDict["Jack London"] },
                    new BookAuthor { BookId = bookDict["White Fang"], AuthorId = authorDict["Jack London"] },
                    new BookAuthor { BookId = bookDict["The Three Musketeers"], AuthorId = authorDict["Alexandre Dumas"] },
                    new BookAuthor { BookId = bookDict["Journey to the Center of the Earth"], AuthorId = authorDict["Jules Verne"] },
                    new BookAuthor { BookId = bookDict["Twenty Thousand Leagues Under the Sea"], AuthorId = authorDict["Jules Verne"] },
                    new BookAuthor { BookId = bookDict["Around the World in Eighty Days"], AuthorId = authorDict["Jules Verne"] },
                    new BookAuthor { BookId = bookDict["The Mysterious Island"], AuthorId = authorDict["Jules Verne"] },
                    new BookAuthor { BookId = bookDict["The Island of Doctor Moreau"], AuthorId = authorDict["H.G. Wells"] },
                    new BookAuthor { BookId = bookDict["The Strange Case of Dr Jekyll and Mr Hyde"], AuthorId = authorDict["Robert Louis Stevenson"] },
                    new BookAuthor { BookId = bookDict["Heart of Darkness"], AuthorId = authorDict["Joseph Conrad"] },
                    new BookAuthor { BookId = bookDict["Gulliver's Travels"], AuthorId = authorDict["Jonathan Swift"] },
                    new BookAuthor { BookId = bookDict["Robinson Crusoe"], AuthorId = authorDict["Daniel Defoe"] },
                    new BookAuthor { BookId = bookDict["The Adventures of Tom Sawyer"], AuthorId = authorDict["Mark Twain"] },
                    new BookAuthor { BookId = bookDict["The Prince and the Pauper"], AuthorId = authorDict["Mark Twain"] },
                    new BookAuthor { BookId = bookDict["A Connecticut Yankee in King Arthur's Court"], AuthorId = authorDict["Mark Twain"] },
                    new BookAuthor { BookId = bookDict["The Tell-Tale Heart"], AuthorId = authorDict["Edgar Allan Poe"] },
                    new BookAuthor { BookId = bookDict["The Raven"], AuthorId = authorDict["Edgar Allan Poe"] },
                    new BookAuthor { BookId = bookDict["The Fall of the House of Usher"], AuthorId = authorDict["Edgar Allan Poe"] },
                    new BookAuthor { BookId = bookDict["The Pit and the Pendulum"], AuthorId = authorDict["Edgar Allan Poe"] },
                    new BookAuthor { BookId = bookDict["The Masque of the Red Death"], AuthorId = authorDict["Edgar Allan Poe"] },
                    new BookAuthor { BookId = bookDict["The Plague"], AuthorId = authorDict["Albert Camus"] },
                    new BookAuthor { BookId = bookDict["Norwegian Wood"], AuthorId = authorDict["Haruki Murakami"] },
                    new BookAuthor { BookId = bookDict["Kafka on the Shore"], AuthorId = authorDict["Haruki Murakami"] },
                    new BookAuthor { BookId = bookDict["The Bell Jar"], AuthorId = authorDict["Sylvia Plath"] },
                    new BookAuthor { BookId = bookDict["Their Eyes Were Watching God"], AuthorId = authorDict["Zora Neale Hurston"] },
                    new BookAuthor { BookId = bookDict["Beloved"], AuthorId = authorDict["Toni Morrison"] },
                    new BookAuthor { BookId = bookDict["Invisible Man"], AuthorId = authorDict["Ralph Ellison"] },
                    new BookAuthor { BookId = bookDict["Things Fall Apart"], AuthorId = authorDict["Chinua Achebe"] },
                    new BookAuthor { BookId = bookDict["The Color Purple"], AuthorId = authorDict["Alice Walker"] },
                    new BookAuthor { BookId = bookDict["I Know Why the Caged Bird Sings"], AuthorId = authorDict["Maya Angelou"] },
                    new BookAuthor { BookId = bookDict["The Brief Wondrous Life of Oscar Wao"], AuthorId = authorDict["Junot Díaz"] },
                    new BookAuthor { BookId = bookDict["Love in the Time of Cholera"], AuthorId = authorDict["Gabriel García Márquez"] },
                    new BookAuthor { BookId = bookDict["The Remains of the Day"], AuthorId = authorDict["Kazuo Ishiguro"] },
                    new BookAuthor { BookId = bookDict["Atonement"], AuthorId = authorDict["Ian McEwan"] },
                    new BookAuthor { BookId = bookDict["Never Let Me Go"], AuthorId = authorDict["Kazuo Ishiguro"] },
                    new BookAuthor { BookId = bookDict["The Night Circus"], AuthorId = authorDict["Erin Morgenstern"] },
                    new BookAuthor { BookId = bookDict["Station Eleven"], AuthorId = authorDict["Emily St. John Mandel"] },
                    new BookAuthor { BookId = bookDict["The Goldfinch"], AuthorId = authorDict["Donna Tartt"] },
                    new BookAuthor { BookId = bookDict["All the Light We Cannot See"], AuthorId = authorDict["Anthony Doerr"] },
                    new BookAuthor { BookId = bookDict["Where the Crawdads Sing"], AuthorId = authorDict["Delia Owens"] },
                    new BookAuthor { BookId = bookDict["Circe"], AuthorId = authorDict["Madeline Miller"] },
                    new BookAuthor { BookId = bookDict["The Song of Achilles"], AuthorId = authorDict["Madeline Miller"] }
                );
                context.SaveChanges();
            }
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" },
                    //new Customer { CustomerId = Guid.NewGuid(), FirstName = "Admin", LastName = "User", Email = "admin.user@example.com" },
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "Mary", LastName = "Jones", Email = "mary.jones@example.com" },
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "Peter", LastName = "Parker", Email = "peter.parker@example.com" },
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "Susan", LastName = "Brown", Email = "susan.brown@example.com" },
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "David", LastName = "Wilson", Email = "david.wilson@example.com" },
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "Linda", LastName = "Moore", Email = "linda.moore@example.com" },
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "Michael", LastName = "Taylor", Email = "michael.taylor@example.com" },
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com" },
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "Chris", LastName = "Evans", Email = "chris.evans@example.com" },
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "Anna", LastName = "White", Email = "anna.white@example.com" },
                    //new Customer { CustomerId = Guid.NewGuid(), FirstName = "Guest", LastName = "User", Email = "guest.user@example.com" },
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "Tom", LastName = "Hardy", Email = "tom.hardy@example.com" },
                    new Customer { CustomerId = Guid.NewGuid(), FirstName = "Laura", LastName = "Martin", Email = "laura.martin@example.com" }
                );
                context.SaveChanges();
            }
            //if (!context.Accounts.Any())
            //{
            //    var customerDict = context.Customers.ToDictionary(c => c.FirstName + " " + c.LastName, c => c.CustomerId);

            //    context.Accounts.AddRange(
            //        new Account { AccountId = Guid.NewGuid(), Username = "john_doe", PasswordHash = "hashed_password_1", Role = "Customer", CustomerId = customerDict["John Doe"] },
            //        new Account { AccountId = Guid.NewGuid(), Username = "jane_smith", PasswordHash = "hashed_password_2", Role = "Customer", CustomerId = customerDict["Jane Smith"] },
            //        //new Account { AccountId = Guid.NewGuid(), Username = "admin_user", PasswordHash = "hashed_password_3", Role = "Admin", CustomerId = customerDict["Admin User"] },
            //        new Account { AccountId = Guid.NewGuid(), Username = "mary_jones", PasswordHash = "hashed_password_4", Role = "Customer", CustomerId = customerDict["Mary Jones"] },
            //        new Account { AccountId = Guid.NewGuid(), Username = "peter_parker", PasswordHash = "hashed_password_5", Role = "Customer", CustomerId = customerDict["Peter Parker"] },
            //        new Account { AccountId = Guid.NewGuid(), Username = "susan_brown", PasswordHash = "hashed_password_6", Role = "Customer", CustomerId = customerDict["Susan Brown"] },
            //        new Account { AccountId = Guid.NewGuid(), Username = "david_wilson", PasswordHash = "hashed_password_7", Role = "Customer", CustomerId = customerDict["David Wilson"] },
            //        new Account { AccountId = Guid.NewGuid(), Username = "linda_moore", PasswordHash = "hashed_password_8", Role = "Customer", CustomerId = customerDict["Linda Moore"] },
            //        new Account { AccountId = Guid.NewGuid(), Username = "michael_taylor", PasswordHash = "hashed_password_9", Role = "Customer", CustomerId = customerDict["Michael Taylor"] },
            //        new Account { AccountId = Guid.NewGuid(), Username = "emily_davis", PasswordHash = "hashed_password_10", Role = "Customer", CustomerId = customerDict["Emily Davis"] },
            //        new Account { AccountId = Guid.NewGuid(), Username = "chris_evans", PasswordHash = "hashed_password_11", Role = "Customer", CustomerId = customerDict["Chris Evans"] },
            //        //new Account { AccountId = Guid.NewGuid(), Username = "guest_user", PasswordHash = "hashed_password_15", Role = "Guest", CustomerId = customerDict["Guest User"] },
            //        new Account { AccountId = Guid.NewGuid(), Username = "tom_hardy", PasswordHash = "hashed_password_13", Role = "Customer", CustomerId = customerDict["Tom Hardy"] },
            //        new Account { AccountId = Guid.NewGuid(), Username = "laura_martin", PasswordHash = "hashed_password_14", Role = "Customer", CustomerId = customerDict["Laura Martin"] }
            //    );
            //    context.SaveChanges();
            //}
            if (!context.AddressStatuses.Any())
            {
                context.AddressStatuses.AddRange(
                    new AddressStatus { StatusId = Guid.NewGuid(), AddressStatusName = "Active" },
                    new AddressStatus { StatusId = Guid.NewGuid(), AddressStatusName = "Inactive" },
                    new AddressStatus { StatusId = Guid.NewGuid(), AddressStatusName = "Pending" },
                    new AddressStatus { StatusId = Guid.NewGuid(), AddressStatusName = "Archived" },
                    new AddressStatus { StatusId = Guid.NewGuid(), AddressStatusName = "Deleted" }
                );
                context.SaveChanges();
            }
            if (!context.CustomerAddresses.Any())
            {
                context.CustomerAddresses.AddRange(
                    new CustomerAddress { AddressId = context.Addresses.First().AddressId, CustomerId = context.Customers.First().CustomerId, StatusId = context.AddressStatuses.First().StatusId },
                    new CustomerAddress { AddressId = context.Addresses.Skip(1).First().AddressId, CustomerId = context.Customers.Skip(1).First().CustomerId, StatusId = context.AddressStatuses.Skip(1).First().StatusId },
                    new CustomerAddress { AddressId = context.Addresses.Skip(2).First().AddressId, CustomerId = context.Customers.Skip(2).First().CustomerId, StatusId = context.AddressStatuses.Skip(2).First().StatusId }
                );
                context.SaveChanges();
            }
            if (!context.CustomerOrders.Any())
            {
                context.CustomerOrders.AddRange(
                    new CustomerOrder { OrderId = Guid.NewGuid(), CustomerId = context.Customers.First().CustomerId, OrderDate = DateTime.Now, DestAddressId = context.Addresses.First().AddressId, ShippingMethodId = context.ShippingMethods.First().MethodId },
                    new CustomerOrder { OrderId = Guid.NewGuid(), CustomerId = context.Customers.Skip(1).First().CustomerId, OrderDate = DateTime.Now, DestAddressId = context.Addresses.Skip(1).First().AddressId, ShippingMethodId = context.ShippingMethods.Skip(1).First().MethodId },
                    new CustomerOrder { OrderId = Guid.NewGuid(), CustomerId = context.Customers.Skip(2).First().CustomerId, OrderDate = DateTime.Now, DestAddressId = context.Addresses.Skip(2).First().AddressId, ShippingMethodId = context.ShippingMethods.Skip(2).First().MethodId }
                );
                context.SaveChanges();
            }
            if (!context.OrderHistories.Any())
            {
                context.OrderHistories.AddRange(
                    new OrderHistory { HistoryId = Guid.NewGuid(), OrderId = context.CustomerOrders.First().OrderId, StatusId = context.OrderStatuses.First().StatusId, StatusDate = DateTime.Now },
                    new OrderHistory { HistoryId = Guid.NewGuid(), OrderId = context.CustomerOrders.Skip(1).First().OrderId, StatusId = context.OrderStatuses.First().StatusId, StatusDate = DateTime.Now },
                    new OrderHistory { HistoryId = Guid.NewGuid(), OrderId = context.CustomerOrders.Skip(2).First().OrderId, StatusId = context.OrderStatuses.First().StatusId, StatusDate = DateTime.Now }
                );
                context.SaveChanges();
            }
            if (!context.OrderLines.Any())
            {
                context.OrderLines.AddRange(
                    new OrderLine { LineId = Guid.NewGuid(), OrderId = context.CustomerOrders.First().OrderId, BookId = context.Books.First().BookId, Quantity = 1, Price = 19.99m },
                    new OrderLine { LineId = Guid.NewGuid(), OrderId = context.CustomerOrders.Skip(1).First().OrderId, BookId = context.Books.Skip(1).First().BookId, Quantity = 2, Price = 29.99m },
                    new OrderLine { LineId = Guid.NewGuid(), OrderId = context.CustomerOrders.Skip(2).First().OrderId, BookId = context.Books.Skip(2).First().BookId, Quantity = 1, Price = 39.99m },
                    new OrderLine { LineId = Guid.NewGuid(), OrderId = context.CustomerOrders.Skip(2).First().OrderId, BookId = context.Books.Skip(3).First().BookId, Quantity = 1, Price = 49.99m }
                );
                context.SaveChanges();
            }
        }
    }
}