using DevOps06.DTOs;
using DevOps06.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps06.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("list-of-books")]
        public async Task<IActionResult> ListOfBooks()
        {
            try
            {
                var books = await _libraryService.GetBooks();
                if (books.Any())
                {
                    return Ok(new
                    {
                        status = "SUCCESS",
                        message = $"Books available {books.Count}",
                        data = books
                    });
                }

                return NotFound(new
                {
                    status = "WARNING",
                    message = "There is not books in this library."
                });
            }
            catch (Exception e)
            {
                var error = new
                {
                    status = "ERROR",
                    message = e.Message
                };
                return BadRequest(error);
            }
        }

        [HttpPost("add-book")]
        public async Task<IActionResult> CreateBook([FromBody] BookDto book)
        {
            try
            {
                var process = await _libraryService.AddNew(book);
                if (!string.IsNullOrWhiteSpace(process))
                {
                    return Ok(new
                    {
                        status = "SUCCESS",
                        message = $"A book has been added to the library.",
                        data = process
                    });
                }

                return BadRequest(new
                {
                    status = "WARNING",
                    message = "It's seems like there were an error while adding the book."
                });
            }
            catch (Exception e)
            {
                var error = new
                {
                    status = "FAILED",
                    message = e.Message
                };
                return BadRequest(error);
            }
        }
    }
}
