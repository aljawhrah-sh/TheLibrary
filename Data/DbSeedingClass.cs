﻿using System;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Models.Domain;
namespace TheLibrary.Data
{
   /* public static class DbSeedingClass
    {
        public static void SeedDataContext(this LibraryDbContext context)
        {
            var booksAuthors = new List<BookAuthor>()
            {
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        ISBN = "123",
                        Title = "The Call Of The Wild",
                        PublishDate = new DateTime(1903,1,1),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Action"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { HeadLine = "Awesome Book", ReviewText = "Reviewing Call of the Wild and it is awesome beyond words", Rating = 5,
                             Reviewer = new Reviewer(){ FirstName = "John", LastName = "Smith" } },
                            new Review { HeadLine = "Terrible Book", ReviewText = "Reviewing Call of the Wild and it is terrrible book", Rating = 1,
                             Reviewer = new Reviewer(){ FirstName = "Peter", LastName = "Griffin" } },
                            new Review { HeadLine = "Decent Book", ReviewText = "Not a bad read, I kind of liked it", Rating = 3,
                             Reviewer = new Reviewer(){ FirstName = "Paul", LastName = "Griffin" } }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Jack",
                        LastName = "London",
                        Country = new Country()
                        {
                            Name = "USA"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        ISBN = "1234",
                        Title = "Winnetou",
                        PublishDate = new DateTime(1978,10,1),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Western"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { HeadLine = "Awesome Western Book", ReviewText = "Reviewing Winnetou and it is awesome book", Rating = 4,
                             Reviewer = new Reviewer(){ FirstName = "Frank", LastName = "Gnocci" } }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Karl",
                        LastName = "May",
                        Country = new Country()
                        {
                            Name = "Germany"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        ISBN = "12345",
                        Title = "Pavols Best Book",
                        PublishDate = new DateTime(2019,2,2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Educational"}},
                            new BookCategory { Category = new Category() { Name = "Computer Programming"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { HeadLine = "Awesome Programming Book", ReviewText = "Reviewing Pavols Best Book and it is awesome beyond words", Rating = 5,
                             Reviewer = new Reviewer(){ FirstName = "Pavol2", LastName = "Almasi2" } }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Pavol",
                        LastName = "Almasi",
                        Country = new Country()
                        {
                            Name = "Slovakia"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        ISBN = "123456",
                        Title = "Three Musketeers",
                        PublishDate = new DateTime(2019,2,2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Action"}},
                            new BookCategory { Category = new Category() { Name = "History"}}
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Alexander",
                        LastName = "Dumas",
                        Country = new Country()
                        {
                            Name = "France"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        ISBN = "1234567",
                        Title = "Big Romantic Book",
                        PublishDate = new DateTime(1979,3,2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Romance"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { HeadLine = "Good Romantic Book", ReviewText = "This book made me cry a few times", Rating = 5,
                             Reviewer = new Reviewer(){ FirstName = "Allison", LastName = "Kutz" } },
                            new Review { HeadLine = "Horrible Romantic Book", ReviewText = "My wife made me read it and I hated it", Rating = 1,
                             Reviewer = new Reviewer(){ FirstName = "Kyle", LastName = "Kutz" } }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Anita",
                        LastName = "Powers",
                        Country = new Country()
                        {
                            Name = "Canada"
                        }
                    }
                }
            };

            context.BookAuthors.AddRange(booksAuthors);
            context.SaveChanges();
        }
    }*/

}

