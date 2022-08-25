using MediatR;
using Microsoft.AspNetCore.Mvc;
using PageCom.Api.Application.DTO.BookDTO;
using PageCom.Api.Application.Features.BookFeatures.Request.command;
using PageCom.Api.Application.Features.BookFeatures.Request.Query;
using PageCom.Api.Application.Models;
using PageCom.api.infastructure;

namespace PageCom.api.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : Controller
{
   private readonly IMediator _mediator;
   private ResponseDTO _response;


   public BookController(IMediator mediator)
   {
      _mediator = mediator;
      _response = new ResponseDTO();
   }
   
   
   [HttpGet]
   public async Task<ResponseDTO> GetAll()
   {
      try
      {
         var booklist = await this._mediator.Send(new BookGetAllRequestQuery());
         this._response  = ResponseCreating.GetResponse(booklist);
      }
      catch (Exception ex)
      {
         this._response = ResponseCreating.GetResponse(null, new List<string>() { ex.ToString() });
      }
      return this._response;
   }
   
   
   [HttpGet("{id}")]
   public async Task<ResponseDTO> Get(int id)
   {
      try
      {
         var booklist = await this._mediator.Send(new BookGetFromIdQuery(id));
         this._response  = ResponseCreating.GetResponse(booklist);
      }
      catch (Exception ex)
      {
         this._response = ResponseCreating.GetResponse(null, new List<string>() { ex.ToString() });
      }
      return this._response;
   }
   
   
   [HttpDelete("{id}")]
   public async Task<ResponseDTO> Delete(int id)
   {
      try
      {
         var booklist = await this._mediator.Send(new BookDeletRequestCommand(id));
         this._response  = ResponseCreating.GetResponse(booklist);
      }
      catch (Exception ex)
      {
         this._response = ResponseCreating.GetResponse(null, new List<string>() { ex.ToString() });
      }
      return this._response;
   }
   
   
   
   [HttpPost]
   public async Task<ResponseDTO> Create([FromBody] BookViewDTO bookObj)
   {
      try
      {
         var booklist = await this._mediator.Send(new BookCreateRequestCommand(bookObj));
         this._response  = ResponseCreating.GetResponse(booklist);
      }
      catch (Exception ex)
      {
         this._response = ResponseCreating.GetResponse(null, new List<string>() { ex.ToString() });
      }
      return this._response;
   }

   [HttpPut("{id}")]
   public async Task<ResponseDTO> Update(int id, [FromBody] BookViewDTO dto)
   {
      try
      {
         var booklist = await this._mediator.Send(new BookUpdateRequestCommand(id,dto));
         this._response  = ResponseCreating.GetResponse(booklist);
      }
      catch (Exception ex)
      {
         this._response = ResponseCreating.GetResponse(null, new List<string>() { ex.ToString() });
      }
      return this._response;
   }
}