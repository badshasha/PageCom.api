using PageCom.Api.Application.Contract.BookContract;
using PageCom.Api.Application.DTO.BookDTO;
using pageCom.api.Data.DataBase;
using pageCom.api.Data.Repository.BaseRepository;
using PageCome.Api.Demain;

namespace pageCom.api.Data.Repository.BookRepositoryImplimentation;

public class BookRepository : BaseRepositioryInmplimentation<Book> , IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }
}