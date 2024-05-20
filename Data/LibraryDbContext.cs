using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Models.Domain;

namespace TheLibrary.Data
{
    public class LibraryDbContext : DbContext
    {

        public LibraryDbContext()
        {

        }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<BookAuthor> BookAuthors { get; set; } = default!;
        public DbSet<BookCategory> BookCategories { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<Reviewer> Reviewers { get; set; } = default!;
        public DbSet<Country> Countries { get; set; } = default!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=LibraryDb;User=sa;Password=TestTest123!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookCategory>().HasKey(k => new { k.BookId, k.CategoryId });
            modelBuilder.Entity<BookCategory>().HasOne(b => b.Book).WithMany(c => c.BookCategories).HasForeignKey(f => f.BookId);
            modelBuilder.Entity<BookCategory>().HasOne(c => c.Category).WithMany(b => b.BookCategories).HasForeignKey(f => f.CategoryId);

            modelBuilder.Entity<BookAuthor>().HasKey(k => new { k.BookId, k.AuthorId });
            modelBuilder.Entity<BookAuthor>().HasOne(b => b.Book).WithMany(a => a.BookAuthors).HasForeignKey(f => f.BookId);
            modelBuilder.Entity<BookAuthor>().HasOne(a => a.Author).WithMany(b => b.BookAuthors).HasForeignKey(f => f.AuthorId);

                 
            // Define Authors
            var authors = new[]
            {
        new Author {Id = 1,  FirstName = "Jack", LastName = "London", CountryId = 1 },
        new Author { Id = 2, FirstName = "Karl", LastName = "May",CountryId = 2  },
        new Author { Id = 3,  FirstName = "Pavol", LastName = "Almasi", CountryId = 3 },
        new Author { Id = 4, FirstName = "Alexander", LastName = "Dumas",CountryId = 4 },
        new Author { Id = 5, FirstName = "Alexander", LastName = "Dumas",CountryId = 5 },
       
    };

            // Define Countries
            var countries = new[]
            {
        new Country {  Id = 1, Name = "USA" },
        new Country {  Id = 2,Name = "Germany" },
        new Country {Id = 3, Name = "Slovakia" },
        new Country { Id = 4, Name = "France" },
        new Country { Id = 5, Name = "Canada" }
    };

            // Define Books
            var books = new[]
            {
        new Book { Id = 1, ISBN = "123", Title = "The Call Of The Wild", PublishDate = new DateTime(1903, 1, 1) },
        new Book {  Id = 2,ISBN = "1234", Title = "Winnetou", PublishDate = new DateTime(1878, 10, 1) },
        new Book { Id = 3, ISBN = "12345", Title = "Pavols Best Book", PublishDate = new DateTime(2019, 2, 2) },
        new Book { Id = 4, ISBN = "123456", Title = "Three Musketeers", PublishDate = new DateTime(1844, 1, 1) }, // Adjusted for accurate date
        new Book { Id = 5, ISBN = "1234567", Title = "Big Romantic Book", PublishDate = new DateTime(1879, 3, 2) }
    };

            // Define Categories
            var categories = new[]
            {
        new Category {  Id = 1,Name = "Action" },
        new Category {   Id = 2,Name = "Western" },
        new Category {  Id = 3, Name = "Educational" },
        new Category {  Id = 4, Name = "Computer Programming" },
        new Category {   Id = 5,Name = "History" },
        new Category {  Id = 6, Name = "Romance" }
    };

            // Seed data into tables
            //modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<Category>().HasData(categories);

            // Assume relational and more complex data setup is handled either via fluent API or annotations
        }

    }
                 
}

