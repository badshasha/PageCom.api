using MediatR;
using PageCom.Api.Application.DTO.BookDTO;

namespace PageCom.Api.Application.Features.BookFeatures.Request.Query;

public record BookGetAllRequestQuery() : IRequest<List<BookViewDTO>>;