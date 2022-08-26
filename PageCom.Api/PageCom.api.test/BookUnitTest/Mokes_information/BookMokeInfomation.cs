using Microsoft.OpenApi.Writers;
using Moq;
using PageCom.Api.Application.Contract.BookContract;
using PageCome.Api.Demain;

namespace PageCom.api.test.BookUnitTest.Mokes_information;

public static class BookMokeInfomation
{
    public static Mock<IBookRepository> GetBookMockInfo()
    {

        var testingDate = DateTime.Today; // fake time information
        List<Book> books = new() // [temp :database]
        {

            new Book()
            {
                Id = 1,
                Name = "load of the ring",
                Description = "Mock info",
                Price = 100,
                AddDateTime = testingDate.AddDays(-1)

            },
            new Book()
            {
                Id = 2,
                Name = "harry potter",
                Description = "magical world ",
                Price = 100,
                AddDateTime = testingDate.AddDays(-2)

            },
            new Book()
            {
                Id = 3,
                Name = "captain marvel",
                Description = "Marvel stories",
                Price = 150,
                AddDateTime = testingDate.AddDays(-3)

            }
        };

        var mokeRepo = new Mock<IBookRepository>();
        mokeRepo.Setup(a => a.GetAll()).ReturnsAsync(books); // [get all]
        mokeRepo.Setup(a => a.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>  
        {
            return books.FirstOrDefault(b => b.Id == id);
        }); // [get id]

        // mokeRepo.Setup(a => a.Delete(It.IsAny<Book>())).Returns((Book obj) =>
        // {
        //     var existingBook = books.FirstOrDefault(b => b.Id == obj.Id);
        //     if (existingBook != null)
        //     {
        //         books.Remove(existingBook);
        //     }
        //
        //     return;
        // }); // [ delete ]

        mokeRepo.Setup(a => a.Create(It.IsAny<Book>())).ReturnsAsync((Book obj) =>
        {
            books.Add(obj);
            return obj;
        }); // [create]

        mokeRepo.Setup(a => a.Update(It.IsAny<Book>())).ReturnsAsync((Book obj) =>
        {
            var existingBook = books.FirstOrDefault(b => b.Id == obj.Id);
            if (existingBook != null)
            {
                existingBook.Name = obj.Name;
                existingBook.Description = obj.Description;
                existingBook.Price = obj.Price;
            }

            return obj;
        }); // [ update ]


        return mokeRepo;

    }
}