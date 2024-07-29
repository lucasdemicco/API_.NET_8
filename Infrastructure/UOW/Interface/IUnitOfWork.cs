using Infrastructure.Repository.Interface;

namespace Infrastructure.UOW.Interface
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
