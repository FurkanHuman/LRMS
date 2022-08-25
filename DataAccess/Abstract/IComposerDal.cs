namespace DataAccess.Abstract
{
    public interface IComposerDal : IEntityRepository<Composer>, IDtoRepository<Composer, ComposerDto>
    {
    }
}
