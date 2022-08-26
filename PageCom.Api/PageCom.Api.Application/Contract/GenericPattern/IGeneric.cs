using System.Formats.Asn1;

namespace PageCom.Api.Application.Contract.GenericPattern;

public interface IGeneric<T> where  T : class
{
    Task<List<T>> GetAll();
    Task<T> Get(int id);
    Task<T> Update(T objectInformation);
    Task<T> Create(T objectInformation);
    Task Delete(T objectInformation);
}