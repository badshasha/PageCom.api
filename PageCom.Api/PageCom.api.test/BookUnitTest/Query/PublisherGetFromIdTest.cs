using AutoMapper;
using Moq;
using PageCom.Api.Application.Contract.BookContract;
using PageCom.Api.Application.DTO.BookDTO;
using PageCom.Api.Application.Features.BookFeatures.Handler.QueryHandler;
using PageCom.Api.Application.Features.BookFeatures.Request.Query;
using PageCom.Api.Application.MappingProfile;
using PageCom.api.test.BookUnitTest.Mokes_information;

namespace PageCom.api.test.BookUnitTest.Query;

[TestFixture]
public class PublisherGetFromIdTest
{
    private readonly Mock<IBookRepository> _mockRepo;
    private readonly IMapper _mapper;
    private BookGetFromIdQueryHandler _handler;

    public PublisherGetFromIdTest()
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
        _handler = new BookGetFromIdQueryHandler(_mockRepo.Object, _mapper);
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public async Task BookGetFromIdRequestHandler_ValidIdRequest_ReturnBookDTOInfo(int id)
    {
        var result = await _handler.Handle(new BookGetFromIdQuery(id), CancellationToken.None);
        
        Assert.That(result , Is.TypeOf<BookViewDTO>());
        Assert.That(result.Id , Is.EqualTo(id));
        Assert.That(result.Name, !Is.Null);
    }
}