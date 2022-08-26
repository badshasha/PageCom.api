using AutoMapper;
using MediatR;
using PageCom.Api.Application.Contract.BookContract;
using PageCom.Api.Application.Features.BookFeatures.Handler.baseInfomaiton;
using PageCom.Api.Application.Features.BookFeatures.Request.command;

namespace PageCom.Api.Application.Features.BookFeatures.Handler.CommandHandler;

public class BookDeletRequestCommandHandler : BaseRequesthandlingInfo , IRequestHandler<BookDeletRequestCommand,bool>
{
    public BookDeletRequestCommandHandler(IBookRepository service, IMapper mapper) : base(service, mapper)
    {
    }

    // todo not satisfied with the delete handler
    public async Task<bool> Handle(BookDeletRequestCommand request, CancellationToken cancellationToken)
    {
        var book = await this.Service.Get(request.id);
        if (book != null)
        {
            try
            {
                await this.Service.Delete(book);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return true;
        }

        throw new Exception("invalid input");
    }
}