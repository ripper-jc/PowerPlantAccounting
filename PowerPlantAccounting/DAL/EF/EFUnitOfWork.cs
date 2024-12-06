namespace DAL.UnitOfWork;

using Repositories.Impl;
using Repositories.Interfaces;
using UnitOfWork;

public class EFUnitOfWork : IUnitOfWork
{
    private readonly DBContext _dbContext;
    private RoleREpository _rolesRepository;
    private UserRepository _userRepository;

    public EFUnitOfWork(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IRolesRepository Menus
    {
        get
        {
            if (_rolesRepository == null)
            {
                _rolesRepository = new RoleREpository(_dbContext);
            }
            return _rolesRepository;
        }
    }

    public IUserRepository Meals
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(_dbContext);
            }
            return _userRepository;
        }
    }



    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}