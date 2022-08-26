using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using MediatR;
using PageCom.Api.Application.Contract.BookContract;
using PageCom.Api.Application.DTO.BookDTO;
using PageCom.Api.Application.Features.BookFeatures.Handler.baseInfomaiton;
using PageCom.Api.Application.Features.BookFeatures.Request.Query;
using PageCome.Api.Demain.BaseDomain;

namespace PageCom.Api.Application.Features.BookFeatures.Handler.QueryHandler;

public class BookGetFromIdQueryHandler : BaseRequesthandlingInfo , IRequestHandler<BookGetFromIdQuery,BookViewDTO>
{

    public BookGetFromIdQueryHandler(IBookRepository service,IMapper mapper) : base(service,mapper)
    {
            
    }
    
    public async Task<BookViewDTO> Handle(BookGetFromIdQuery request, CancellationToken cancellationToken)
    {
        var bookinfo = await this.Service.Get(request.id);
        return Mapper.Map<BookViewDTO>(bookinfo);
    }
}