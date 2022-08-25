using MediatR;

namespace PageCom.Api.Application.Features.BookFeatures.Request.command;

public record BookDeletRequestCommand(int id): IRequest<bool> ;