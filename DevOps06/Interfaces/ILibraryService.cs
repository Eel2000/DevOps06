using DevOps06.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps06.Interfaces
{
    public interface ILibraryService
    {
        Task<string> AddNew(BookDto bookDto);
        Task<IReadOnlyList<BookDto>> GetBooks();
    }
}
