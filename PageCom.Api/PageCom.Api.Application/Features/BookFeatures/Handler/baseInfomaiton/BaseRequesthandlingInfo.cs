using AutoMapper;
using PageCom.Api.Application.Contract.BookContract;

namespace PageCom.Api.Application.Features.BookFeatures.Handler.baseInfomaiton;

public abstract class BaseRequesthandlingInfo
{
    protected readonly IBookRepository Service;
    protected readonly IMapper Mapper;

    public BaseRequesthandlingInfo(IBookRepository service , IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }
}