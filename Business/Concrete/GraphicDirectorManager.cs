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
            return new SuccessResult(GraphicDirectorConstants.AddSuccess);
        }

        public IResult Delete(GraphicDirector entity)
        {
            _graphicDirectorDal.Delete(entity);
            return new SuccessResult(GraphicDirectorConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid guid)
        {
            GraphicDirector graphicDirector = _graphicDirectorDal.Get(g => g.Id == guid && !g.IsDeleted);
            if (graphicDirector == null)
                return new ErrorResult(GraphicDirectorConstants.NotMatch);

            graphicDirector.IsDeleted = true;
            _graphicDirectorDal.Update(graphicDirector);
            return new SuccessResult(GraphicDirectorConstants.DataGet);
        }
        public IResult Update(GraphicDirector entity)
        {
            _graphicDirectorDal.Update(entity);
            return new SuccessResult(GraphicDirectorConstants.UpdateSuccess);
        }

        public IDataResult<List<GraphicDirector>> GetByFilterList(Expression<Func<GraphicDirector, bool>>? filter = null)
        {
            return new SuccessDataResult<List<GraphicDirector>>(_graphicDirectorDal.GetAll(filter).ToList(), GraphicDirectorConstants.DataGet);
        }

        public IDataResult<GraphicDirector> GetById(Guid guid)
        {
            return new SuccessDataResult<GraphicDirector>(_graphicDirectorDal.Get(i => i.Id == guid && !i.IsDeleted), GraphicDirectorConstants.DataGet);
        }

        public IDataResult<List<GraphicDirector>> GetByNames(string name)
        {
            List<GraphicDirector> graphicDirectors = _graphicDirectorDal.GetAll(n => n.Name.ToLower().Contains(name.ToLower()) && !n.IsDeleted).ToList();
            return graphicDirectors == null
                ? new ErrorDataResult<List<GraphicDirector>>(GraphicDirectorConstants.DataNotGet)
                : new SuccessDataResult<List<GraphicDirector>>(graphicDirectors, GraphicDirectorConstants.DataGet);
        }

        public IDataResult<List<GraphicDirector>> GetBySurnames(string surname)
        {
            List<GraphicDirector> graphicDirectors = _graphicDirectorDal.GetAll(n => n.SurName.ToLower().Contains(surname.ToLower()) && !n.IsDeleted).ToList();
            return graphicDirectors == null
                ? new ErrorDataResult<List<GraphicDirector>>(GraphicDirectorConstants.DataNotGet)
                : new SuccessDataResult<List<GraphicDirector>>(graphicDirectors, GraphicDirectorConstants.DataGet);
        }

        public IDataResult<List<GraphicDirector>> GetList()
        {
            return new SuccessDataResult<List<GraphicDirector>>(_graphicDirectorDal.GetAll().ToList(), GraphicDirectorConstants.DataGet);
        }

        private IResult GraphicDirectorNameOrSurnameExist(GraphicDirector entity)
        {
            bool result = _graphicDirectorDal.GetAll(w => w.Name.ToUpperInvariant().Equals(entity.Name.ToUpperInvariant())
             && w.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())).Any();
            return result
                ? new ErrorResult(GraphicDirectorConstants.NameOrSurnameExists)
                : new SuccessResult(GraphicDirectorConstants.DataGet);
        }
    }
}
