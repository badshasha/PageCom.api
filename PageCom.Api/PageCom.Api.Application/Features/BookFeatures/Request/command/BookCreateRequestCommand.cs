using MediatR;
using PageCom.Api.Application.DTO.BookDTO;

namespace PageCom.Api.Application.Features.BookFeatures.Request.command;

public record BookCreateRequestCommand(BookViewDTO bookobj) : IRequest<BookViewDTO>;