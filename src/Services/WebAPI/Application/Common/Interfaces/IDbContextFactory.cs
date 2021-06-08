using System;
namespace WebAPI.Application.Common.Interfaces
{
    public interface IDbContextFactory
    {
        IApplicationDbContext GetGenericContext();
        IApplicationDbContext TryFindContextByType(Type type);
    }
}
