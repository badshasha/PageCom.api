using AutoMapper;
using FluentValidation;
using MediatR;
using PageCom.Api.Application.Contract.BookContract;
using PageCom.Api.Application.DTO.BookDTO;
using PageCom.Api.Application.DTO.BookDTO.validator;
using PageCom.Api.Application.Features.BookFeatures.Handler.baseInfomaiton;
using PageCom.Api.Application.Features.BookFeatures.Request.command;
using PageCome.Api.Demain;

namespace PageCom.Api.Application.Features.BookFeatures.Handler.CommandHandler;

public class BookCreateRequestCommandHander : BaseRequesthandlingInfo , IRequestHandler<BookCreateRequestCommand,BookViewDTO>
{
    private readonly IValidator<BookViewDTO> _validator;

    public BookCreateRequestCommandHander(IBookRepository service, IMapper mapper,IValidator<BookViewDTO> validator) : base(service, mapper)
    {
        _validator = validator;
    }

    public async Task<BookViewDTO> Handle(BookCreateRequestCommand request, CancellationToken cancellationToken)
    {

        var validateResult = await _validator.ValidateAsync(request.bookobj, cancellationToken);
        if (!validateResult.IsValid) throw new Exception(validateResult.ToString());
        var bookobj = this.Mapper.Map<Book>(request.bookobj);
        
        try
        {
            bookobj = await this.Service.Create(bookobj); // [-] i am not use another variable but it's the best way to use it 
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString());
        }

        return this.Mapper.Map<BookViewDTO>(bookobj);

    }
}