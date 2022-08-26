using System.Net.NetworkInformation;
using AutoMapper;
using Moq;
using PageCom.Api.Application.Contract.BookContract;
using PageCom.Api.Application.DTO.BookDTO;
using PageCom.Api.Application.DTO.BookDTO.validator;
using PageCom.Api.Application.Features.BookFeatures.Handler.CommandHandler;
using PageCom.Api.Application.Features.BookFeatures.Request.command;
using PageCom.Api.Application.MappingProfile;
using PageCom.api.test.BookUnitTest.Mokes_information;
using PageCome.Api.Demain;

namespace PageCom.api.test.BookUnitTest.Commands;

[TestFixture]
public class BookAddUnittest
{
    private readonly Mock<IBookRepository> _mockRepo;
    private readonly IMapper _mapper;
    private readonly BookViewDTOValidator _validator;
    private BookCreateRequestCommandHander _hander;

    public BookAddUnittest()
    {
        _mockRepo = BookMokeInfomation.GetBookMockInfo();
        var mapperConfig = new MapperConfiguration(c => // i am not clear about this code 
        {
            c.AddProfile<MappingProfileInfo>();
        });
        _mapper = mapperConfig.CreateMapper();
        _validator = new BookViewDTOValidator();
    }

    [SetUp]
    public void Setup()
    {
        _hander = new BookCreateRequestCommandHander(_mockRepo.Object, _mapper, _validator);
    }

    [Test]
    [TestCase(1,"testonename","test_one_descrition",100)]
    [TestCase(1,"testtwoname","test_two_description",200)]
    public async Task BookCreateRequestCommand_AddValidBookObj_ReturnCreatedBookDtoView(int id, string name , string description, Double price)
    {
        var newCreateBook = new BookViewDTO()
        {
            Id = id,
            Name = name,
            Description = description,
            Price = price
        };
    
        var result = await _hander.Handle(new BookCreateRequestCommand(newCreateBook), CancellationToken.None);
        
        // testing 
        Assert.That(result , Is.TypeOf<BookViewDTO>());
        Assert.That(result.Id, Is.EqualTo(id));
        Assert.That(result.Name, Is.EqualTo(name));
        Assert.That(result.Description, Is.EqualTo(description));
        Assert.That(result.Price, Is.EqualTo(price));
    }

    [Test]
    [TestCase(1,"wrong@Name","test_one_descrition",100)]
    public async Task BookCreateRequest_InvalidInput_ReturnException(int id, string name , string description, Double price)
    {
        var newCreateBook = new BookViewDTO()
        {
            Id = id,
            Name = name,
            Description = description,
            Price = price
        };
        
        Assert.That( () => _hander.Handle(new BookCreateRequestCommand(newCreateBook) , CancellationToken.None) , Throws.Exception.TypeOf<Exception>() );
    }
}