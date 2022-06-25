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

            entity.IsDeleted = false;
            _graphicDirectorDal.Add(entity);
            return new SuccessResult(GraphicDirectorConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            GraphicDirector graphicDirector = _graphicDirectorDal.Get(g => g.Id == id);
            if (graphicDirector == null)
                return new ErrorResult(GraphicDirectorConstants.NotMatch);

            _graphicDirectorDal.Delete(graphicDirector);
            return new SuccessResult(GraphicDirectorConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            GraphicDirector graphicDirector = _graphicDirectorDal.Get(g => g.Id == id && !g.IsDeleted);
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

        public IDataResult<GraphicDirector> GetById(Guid id)
        {
            GraphicDirector graphicDirector = _graphicDirectorDal.Get(i => i.Id == id);

            return graphicDirector == null
                ? new ErrorDataResult<GraphicDirector>(GraphicDirectorConstants.NotMatch)
                : new SuccessDataResult<GraphicDirector>(GraphicDirectorConstants.DataGet);
        }

        public IDataResult<List<GraphicDirector>> GetByIds(Guid[] ids)
        {
            List<GraphicDirector> graphicDirectors = _graphicDirectorDal.GetAll(n => ids.Contains(n.Id) && !n.IsDeleted).ToList();
            return graphicDirectors == null
                ? new ErrorDataResult<List<GraphicDirector>>(GraphicDirectorConstants.GraphicDirectorNull)
                : new SuccessDataResult<List<GraphicDirector>>(graphicDirectors, GraphicDirectorConstants.DataGet);
        }
        public IDataResult<List<GraphicDirector>> GetByNames(string name)
        {
            List<GraphicDirector> graphicDirectors = _graphicDirectorDal.GetAll(n => n.Name.Contains(name) && !n.IsDeleted).ToList();
            return graphicDirectors == null
                ? new ErrorDataResult<List<GraphicDirector>>(GraphicDirectorConstants.DataNotGet)
                : new SuccessDataResult<List<GraphicDirector>>(graphicDirectors, GraphicDirectorConstants.DataGet);
        }

        public IDataResult<List<GraphicDirector>> GetBySurnames(string surname)
        {
            List<GraphicDirector> graphicDirectors = _graphicDirectorDal.GetAll(n => n.SurName.Contains(surname) && !n.IsDeleted).ToList();
            return graphicDirectors == null
                ? new ErrorDataResult<List<GraphicDirector>>(GraphicDirectorConstants.DataNotGet)
                : new SuccessDataResult<List<GraphicDirector>>(graphicDirectors, GraphicDirectorConstants.DataGet);
        }

        public IDataResult<List<GraphicDirector>> GetAllByFilter(Expression<Func<GraphicDirector, bool>>? filter = null)
        {
            return new SuccessDataResult<List<GraphicDirector>>(_graphicDirectorDal.GetAll(filter).ToList(), GraphicDirectorConstants.DataGet);
        }

        public IDataResult<List<GraphicDirector>> GetAll()
        {
            return new SuccessDataResult<List<GraphicDirector>>(_graphicDirectorDal.GetAll(gd => !gd.IsDeleted).ToList(), GraphicDirectorConstants.DataGet);
        }

        public IDataResult<List<GraphicDirector>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<GraphicDirector>>(_graphicDirectorDal.GetAll(gd => gd.IsDeleted).ToList(), GraphicDirectorConstants.DataGet);
        }

        private IResult GraphicDirectorNameOrSurnameExist(GraphicDirector entity)
        {
            bool result = _graphicDirectorDal.GetAll(w => w.Name.Equals(entity.Name)
             && w.SurName.Equals(entity.SurName)).Any();
            return result
                ? new ErrorResult(GraphicDirectorConstants.NameOrSurnameExists)
                : new SuccessResult(GraphicDirectorConstants.DataGet);
        }
    }
}
