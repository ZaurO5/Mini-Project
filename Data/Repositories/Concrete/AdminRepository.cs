using Core.Entities;
using Data.Repositories.Abstract;
using Data.Repositories.Base;
using System;

namespace Data.Repository.Concrete;

public class AdminRepository : Repository<Admin>, IAdminRepository
{
    private readonly ApplicationDbContext _context;
    public AdminRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public Admin GetAdminByEmail(string email)
    {
        return _context.Admins.FirstOrDefault(a => a.Email == email);
    }
}