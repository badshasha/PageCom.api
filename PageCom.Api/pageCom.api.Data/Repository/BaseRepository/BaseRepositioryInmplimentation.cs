using MediatR;
using Microsoft.EntityFrameworkCore;
using PageCom.Api.Application.Contract.GenericPattern;


namespace pageCom.api.Data.Repository.BaseRepository;

public class BaseRepositioryInmplimentation<T> : IGeneric<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public BaseRepositioryInmplimentation(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // get all entities on the table 
    public async Task<List<T>> GetAll()
    {
        return await this._context.Set<T>().ToListAsync();
    }

    public async Task<T> Get(int id)
    {
        return await this._context.Set<T>().FindAsync(id); // todo [null value check requried in BaseRepository implimentaion]
    }

    public async Task<T> Update(T objectInformation)
    {
        this._context.Entry(objectInformation).State = EntityState.Modified; // [special coed]
        await this._context.SaveChangesAsync();
        return objectInformation;
    }

    public async Task<T> Create(T objectInformation)
    {
        await this._context.Set<T>().AddAsync(objectInformation);
        await this._context.SaveChangesAsync();
        return objectInformation;
    }

    public async Task Delete(T objectInformation)
    {
        this._context.Set<T>().Remove(objectInformation);
        await this._context.SaveChangesAsync();
    }
}