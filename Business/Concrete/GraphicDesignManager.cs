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
    public class GraphicDesignManager : IGraphicDesignService
    {
        private readonly IGraphicDesignDal _graphicDesignDal;

        public GraphicDesignManager(IGraphicDesignDal graphicDesignDal)
        {
            _graphicDesignDal = graphicDesignDal;
        }

        [ValidationAspect(typeof(GraphicDesignValidator), Priority = 1)]
        public IResult Add(GraphicDesign entity)
        {
            IResult result = BusinessRules.Run(GraphicDesignNameOrSurnameExist(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _graphicDesignDal.Add(entity);
            return new SuccessResult(GraphicDesignConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            GraphicDesign graphicDesign = _graphicDesignDal.Get(gd => gd.Id == id);
            if (graphicDesign == null)
                return new ErrorResult(GraphicDesignConstants.NotMatch);

            _graphicDesignDal.Delete(graphicDesign);
            return new SuccessResult(GraphicDesignConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            GraphicDesign graphicDesign = _graphicDesignDal.Get(g => g.Id == id);
            if (graphicDesign == null)
                return new ErrorResult(GraphicDesignConstants.NotMatch);

            graphicDesign.IsDeleted = true;
            _graphicDesignDal.Update(graphicDesign);
            return new SuccessResult(GraphicDesignConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(GraphicDesignValidator), Priority = 1)]
        public IResult Update(GraphicDesign entity)
        {
            _graphicDesignDal.Update(entity);
            return new SuccessResult(GraphicDesignConstants.UpdateSuccess);
        }

        public IDataResult<List<GraphicDesign>> GetByFilterLists(Expression<Func<GraphicDesign, bool>>? filter = null)
        {
            return new SuccessDataResult<List<GraphicDesign>>(_graphicDesignDal.GetAll(filter).ToList(), GraphicDesignConstants.DataGet);
        }

        public IDataResult<GraphicDesign> GetById(Guid id)
        {
            return new SuccessDataResult<GraphicDesign>(_graphicDesignDal.Get(i => i.Id == id && !i.IsDeleted), GraphicDesignConstants.DataGet);
        }

        public IDataResult<List<GraphicDesign>> GetByNames(string name)
        {
            List<GraphicDesign> graphicDesigns = _graphicDesignDal.GetAll(n => n.Name.Contains(name ) && !n.IsDeleted).ToList();

            return graphicDesigns == null
                ? new ErrorDataResult<List<GraphicDesign>>(GraphicDesignConstants.DataNotGet)
                : new SuccessDataResult<List<GraphicDesign>>(graphicDesigns, GraphicDesignConstants.DataGet);
        }

        public IDataResult<List<GraphicDesign>> GetBySurnames(string surname)
        {
            List<GraphicDesign> graphicDesigns = _graphicDesignDal.GetAll(n => n.SurName.Contains(surname ) && !n.IsDeleted).ToList();
            return graphicDesigns == null
                ? new ErrorDataResult<List<GraphicDesign>>(GraphicDesignConstants.DataNotGet)
                : new SuccessDataResult<List<GraphicDesign>>(graphicDesigns, GraphicDesignConstants.DataGet);
        }

        public IDataResult<List<GraphicDesign>> GetAll()
        {
            return new SuccessDataResult<List<GraphicDesign>>(_graphicDesignDal.GetAll(gd => !gd.IsDeleted).ToList(), GraphicDesignConstants.DataGet);
        }
        public IDataResult<List<GraphicDesign>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<GraphicDesign>>(_graphicDesignDal.GetAll(gd => gd.IsDeleted).ToList(), GraphicDesignConstants.DataGet);
        }

        private IResult GraphicDesignNameOrSurnameExist(GraphicDesign entity)
        {
            bool result = _graphicDesignDal.GetAll(w => w.Name .Equals(entity.Name )
            && w.SurName .Equals(entity.SurName )).Any();
            return result
                ? new ErrorResult(GraphicDesignConstants.NameOrSurnameExists)
                : new SuccessResult(GraphicDesignConstants.DataGet);
        }
    }
}
