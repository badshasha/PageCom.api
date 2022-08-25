using AutoMapper;
using MediatR;
using PageCom.Api.Application.Contract.BookContract;
using PageCom.Api.Application.DTO.BookDTO;
using PageCom.Api.Application.Features.BookFeatures.Request.Query;

namespace PageCom.Api.Application.Features.BookFeatures.Handler.QueryHandler;

public class BookGetAllRequestQueryHandler : IRequestHandler<BookGetAllRequestQuery,List<BookViewDTO>> 
{
    private readonly IBookRepository _service;
    private readonly IMapper _mapper;

    public BookGetAllRequestQueryHandler(IBookRepository service,IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    
    public async Task<List<BookViewDTO>> Handle(BookGetAllRequestQuery request, CancellationToken cancellationToken)
    {
        var booklist = await this._service.GetAll();
        return this._mapper.Map<List<BookViewDTO>>(booklist);
    }
}