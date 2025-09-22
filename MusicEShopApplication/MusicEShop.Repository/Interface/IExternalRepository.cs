using MusicEShop.Domain.DomainModels;

namespace MusicEShop.Repository.Interface
{
    public interface IExternalRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
    }
}
