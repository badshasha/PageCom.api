
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentValidation;
using MediatR;
using PageCom.Api.Application.Contract.BookContract;
using PageCom.Api.Application.DTO.BookDTO;
using PageCom.Api.Application.Features.BookFeatures.Handler.baseInfomaiton;
using PageCom.Api.Application.Features.BookFeatures.Request.command;
using PageCome.Api.Demain;
using ValidationException = FluentValidation.ValidationException; // todo need to check this [book update function issues]

namespace PageCom.Api.Application.Features.BookFeatures.Handler.CommandHandler;

public class BookUpdateRequestCommandHandler : BaseRequesthandlingInfo , IRequestHandler<BookUpdateRequestCommand, BookViewDTO>
{
    private readonly IValidator<BookViewDTO> _validator;

    public BookUpdateRequestCommandHandler(IBookRepository service, IMapper mapper,IValidator<BookViewDTO> validator) : base(service, mapper)
    {
        _validator = validator;
    }

    public async Task<BookViewDTO> Handle(BookUpdateRequestCommand request, CancellationToken cancellationToken)
    {
        Book? updateBookInfo = null;
        var requestUpdateBook = await this.Service.Get(request.requestedbook_id);
        if (requestUpdateBook != null) throw new Exception("invalid input");
        var validateResult = await _validator.ValidateAsync(request.bookinfo);
        if (!validateResult.IsValid) throw new ValidationException(validateResult.ToString());
        try
        {
            this.Mapper.Map(request.bookinfo, requestUpdateBook);
            updateBookInfo = await this.Service.Update(requestUpdateBook!);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        if (updateBookInfo != null)  return this.Mapper.Map<BookViewDTO>(updateBookInfo);
        return new BookViewDTO(); // todo not good [warning in update function]
    }
}