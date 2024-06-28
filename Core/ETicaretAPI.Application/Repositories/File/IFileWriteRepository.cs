using F = ETicaretAPI.Domain.Entities;//tür yolunu değişkene atadım

namespace ETicaretAPI.Application.Repositories
{
    public interface IFileWriteRepository : IWriteRepository<F::File>
    {
    }
}