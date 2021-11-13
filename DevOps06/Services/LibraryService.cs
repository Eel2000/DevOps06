using DevOps06.Contexts;
using DevOps06.DTOs;
using DevOps06.Interfaces;
using DevOps06.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps06.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ApplicationDbContext _dbContext;
        public LibraryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddNew(BookDto bookDto)
        {
            var book = new Book
            {
                ID = Guid.NewGuid().ToString(),
                Title = bookDto.Title,
                Author = bookDto.Author,
                PublicationDate = bookDto.PublicationDate,
                PageCount = bookDto.PageCount
            };

            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return book?.ID;
        }

        public async Task<IReadOnlyList<BookDto>> GetBooks()
        {
            var books = await _dbContext.Books.ToListAsync();
            var booksDTOs = new List<BookDto>();
            books.ForEach(b =>
            {
                booksDTOs.Add(new BookDto
                {
                    Title = b.Title,
                    Author = b.Author,
                    PublicationDate = b.PublicationDate,
                    PageCount = b.PageCount
                });
            });

            return booksDTOs;
        }
    }
}
