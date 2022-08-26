using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PageCom.Api.Application.DTO.BookDTO;
using PageCom.Api.Application.DTO.BookDTO.validator;
using MediatR;

namespace PageCom.Api.Application.ExtendClasses;

public static class PageComApiApplicationExtender
{
    public static IServiceCollection ApplicationExtendService(this IServiceCollection service)
    {
        // auto mapper 
        service.AddAutoMapper(Assembly.GetExecutingAssembly());
        service.AddMediatR(Assembly.GetExecutingAssembly());

        
        // validator 
        service.AddScoped<IValidator<BookViewDTO>, BookViewDTOValidator>();
        
        // return 
        return service;
    }
}