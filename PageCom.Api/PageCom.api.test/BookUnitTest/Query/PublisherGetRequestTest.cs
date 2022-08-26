using AutoMapper;
using Moq;
using PageCom.Api.Application.Contract.BookContract;
using PageCom.Api.Application.Features.BookFeatures.Handler.QueryHandler;
using PageCom.Api.Application.Features.BookFeatures.Request.Query;
using PageCom.Api.Application.MappingProfile;
using PageCom.api.test.BookUnitTest.Mokes_information;

namespace PageCom.api.test.BookUnitTest.Query;

[TestFixture]
public class PublisherGetRequestTest
{
    private readonly Mock<IBookRepository> _mockRepo;
    private readonly IMapper _mapper;
    private BookGetAllRequestQueryHandler _handler;

    public PublisherGetRequestTest()
    {
        _mockRepo = BookMokeInfomation.GetBookMockInfo();
        var mapperConfig = new MapperConfiguration(c => // i am not clear about this code 
        {
            c.AddProfile<MappingProfileInfo>();
        });

        _mapper = mapperConfig.CreateMapper();  
    }


    [SetUp]
    public void Setup()
    {
       _handler = new BookGetAllRequestQueryHandler(_mockRepo.Object, _mapper);
    }

    [Test]
    public async Task BookGetAllRequestHandler_WhenCall_ReturnAllBooksOnTheTable()
    {
        var result = await _handler.Handle(new BookGetAllRequestQuery(), CancellationToken.None);
        
        Assert.That( result.Count , Is.EqualTo(3));
    }

}