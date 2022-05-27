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

            _graphicDesignDal.Add(entity);
            return new SuccessResult(GraphicDesignConstants.AddSuccess);
        }

        public IResult Delete(GraphicDesign entity)
        {
            _graphicDesignDal.Delete(entity);
            return new SuccessResult(GraphicDesignConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid guid)
        {
            GraphicDesign graphicDesign = _graphicDesignDal.Get(g => g.Id == guid && !g.IsDeleted);
            if (graphicDesign == null)
                return new ErrorResult(GraphicDesignConstants.NotMatch);

            graphicDesign.IsDeleted = true;
            _graphicDesignDal.Update(graphicDesign);
            return new SuccessResult(GraphicDesignConstants.ShadowDeleteSuccess);
        }

        public IResult Update(GraphicDesign entity)
        {
            _graphicDesignDal.Update(entity);
            return new SuccessResult(GraphicDesignConstants.UpdateSuccess);
        }

        public IDataResult<List<GraphicDesign>> GetByFilterList(Expression<Func<GraphicDesign, bool>>? filter = null)
        {
            return new SuccessDataResult<List<GraphicDesign>>(_graphicDesignDal.GetAll(filter).ToList(), GraphicDesignConstants.DataGet);
        }

        public IDataResult<GraphicDesign> GetById(Guid id)
        {
            return new SuccessDataResult<GraphicDesign>(_graphicDesignDal.Get(i => i.Id == id && !i.IsDeleted), GraphicDesignConstants.DataGet);
        }

        public IDataResult<List<GraphicDesign>> GetByNames(string name)
        {
            List<GraphicDesign> graphicDesigns = _graphicDesignDal.GetAll(n => n.Name.ToLower().Contains(name.ToLower()) && !n.IsDeleted).ToList();

            return graphicDesigns == null
                ? new ErrorDataResult<List<GraphicDesign>>(GraphicDesignConstants.DataNotGet)
                : new SuccessDataResult<List<GraphicDesign>>(graphicDesigns, GraphicDesignConstants.DataGet);
        }

        public IDataResult<List<GraphicDesign>> GetBySurnames(string surname)
        {
            List<GraphicDesign> graphicDesigns = _graphicDesignDal.GetAll(n => n.SurName.ToLower().Contains(surname.ToLower()) && !n.IsDeleted).ToList();
            return graphicDesigns == null
                ? new ErrorDataResult<List<GraphicDesign>>(GraphicDesignConstants.DataNotGet)
                : new SuccessDataResult<List<GraphicDesign>>(graphicDesigns, GraphicDesignConstants.DataGet);
        }

        public IDataResult<List<GraphicDesign>> GetList()
        {
            return new SuccessDataResult<List<GraphicDesign>>(_graphicDesignDal.GetAll().ToList(), GraphicDesignConstants.DataGet);
        }

        private IResult GraphicDesignNameOrSurnameExist(GraphicDesign entity)
        {
            bool result = _graphicDesignDal.GetAll(w => w.Name.ToUpperInvariant().Equals(entity.Name.ToUpperInvariant())
            && w.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())).Any();
            return result
                ? new ErrorResult(GraphicDesignConstants.NameOrSurnameExists)
                : new SuccessResult(GraphicDesignConstants.DataGet);
        }
    }
}
