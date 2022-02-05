using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class GraphicDirectorManager : IGraphicDirectorService
    {

        private readonly IGraphicDirectorDal _graphicDirectorDal;

        public GraphicDirectorManager(IGraphicDirectorDal graphicDirectorDal)
        {
            _graphicDirectorDal = graphicDirectorDal;
        }

        [ValidationAspect(typeof(GraphicDirectorValidator), Priority = 1)]
        public IResult Add(GraphicDirector entity)
        {
            IResult result = BusinessRules.Run(GraphicDirectorNameOrSurnameExist(entity));
            if (result != null)
                return result;
            _graphicDirectorDal.Add(entity);
            return new SuccessResult(GraphicDirectorConstants.AddSucces);
        }

        public IResult Delete(GraphicDirector entity)
        {
            _graphicDirectorDal.Delete(entity);
            return new SuccessResult(GraphicDirectorConstants.DeleteSucces);
        }

        public IResult Update(GraphicDirector entity)
        {
            _graphicDirectorDal.Update(entity);
            return new SuccessResult(GraphicDirectorConstants.UpdateSucces);
        }

        public IDataResult<List<GraphicDirector>> GetByFilterList(Expression<Func<GraphicDirector, bool>>? filter = null)
        {
            return new SuccessDataResult<List<GraphicDirector>>(_graphicDirectorDal.GetAll(filter).ToList(), GraphicDirectorConstants.DataGet);
        }

        public IDataResult<GraphicDirector> GetById(int id)
        {
            return new SuccessDataResult<GraphicDirector>(_graphicDirectorDal.Get(i => i.Id == id && !i.IsDeleted),GraphicDirectorConstants.DataGet);
        }

        public IDataResult<GraphicDirector> GetByName(string name)
        {
            GraphicDirector graphicDirector = _graphicDirectorDal.Get(n => n.Name.ToLower().Contains(name.ToLower()) && !n.IsDeleted);
            return graphicDirector == null
                ? new ErrorDataResult<GraphicDirector>(GraphicDirectorConstants.DataNotGet)
                : new SuccessDataResult<GraphicDirector>(graphicDirector, GraphicDirectorConstants.DataGet);
        }

        public IDataResult<GraphicDirector> GetBySurname(string surname)
        {
            GraphicDirector graphicDirector = _graphicDirectorDal.Get(n => n.SurName.ToLower().Contains(surname.ToLower()) && !n.IsDeleted);
            return graphicDirector == null
                ? new ErrorDataResult<GraphicDirector>(GraphicDirectorConstants.DataNotGet)
                : new SuccessDataResult<GraphicDirector>(graphicDirector, GraphicDirectorConstants.DataGet);
        }

        public IDataResult<List<GraphicDirector>> GetList()
        {
            return new SuccessDataResult<List<GraphicDirector>>(_graphicDirectorDal.GetAll().ToList(), GraphicDirectorConstants.DataGet);
        }

        private  IResult GraphicDirectorNameOrSurnameExist(GraphicDirector entity)
        {

            bool result =_graphicDirectorDal.GetAll(w => w.Name.ToUpperInvariant().Equals(entity.Name.ToUpperInvariant())
            && w.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())).Any();
            return !result
                ? new ErrorResult(GraphicDirectorConstants.NameOrSurnameExist)
                : new SuccessResult(GraphicDirectorConstants.DataGet);

        }

    }
}
