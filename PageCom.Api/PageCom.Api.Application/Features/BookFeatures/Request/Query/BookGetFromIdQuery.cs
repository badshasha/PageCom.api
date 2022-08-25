using MediatR;
using PageCom.Api.Application.DTO.BookDTO;

namespace PageCom.Api.Application.Features.BookFeatures.Request.Query;

public record BookGetFromIdQuery(int id) : IRequest<BookViewDTO>;