using MediatR;
using PageCom.Api.Application.DTO.BookDTO;

namespace PageCom.Api.Application.Features.BookFeatures.Request.command;

public record BookUpdateRequestCommand(int requestedbook_id, BookViewDTO bookinfo) : IRequest<BookViewDTO>;

    
