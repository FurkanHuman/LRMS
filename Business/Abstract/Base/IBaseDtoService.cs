using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using System.Linq.Expressions;

namespace Business.Abstract.Base
{
    public interface IBaseDtoService<G, S, I> where G : IDto //Remake Todo
                                              where S : IDto
                                              where I : struct
    {
        IResult Add(G entity);
        IResult Update(G entity);
        IDataResult<S> GetById(I id);
        IDataResult<List<S>> GetByNames(string name);
        IDataResult<List<S>> GetByFilterLists(Expression<Func<G, bool>>? filter = null);
        IDataResult<List<S>> GetAllBySecrets();
        IDataResult<List<S>> GetAll();

    }
}
