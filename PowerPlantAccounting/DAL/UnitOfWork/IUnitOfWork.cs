namespace DAL.UnitOfWork;

using Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IRolesRepository Roles { get; }
    Task SaveAsync();
}