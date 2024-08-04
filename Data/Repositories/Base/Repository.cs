using ConsoleCommerceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Base;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbTable;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbTable = _context.Set<T>();

    }
    public List<T> GetAll()
    {
        return _dbTable.ToList();
    }

    public T GetById(int id)
    {
        return _dbTable.Find(id);
    }
    public void Add(T item)
    {
        item.CreatedAt = DateTime.Now;
        _dbTable.Add(item);
    }
    public void Update(T item)
    {
        item.ModifiedAt = DateTime.Now;
        _dbTable.Update(item);
    }

    public void Delete(T item)
    {
        _dbTable.Remove(item);
    }

    public void Commit()
    {
        try
        {
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }
}

