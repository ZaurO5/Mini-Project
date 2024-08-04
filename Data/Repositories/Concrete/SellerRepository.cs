using Core.Entities;
using Data.Repositories.Abstract;
using Data.Repositories.Base;
using Data;

public class SellerRepository : Repository<Seller>, ISellerRepository
{
    private readonly ApplicationDbContext _context;

    public SellerRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public Seller GetSellerByEmail(string email)
    {
        return _context.Sellers.FirstOrDefault(s => s.Email == email);
    }
}
