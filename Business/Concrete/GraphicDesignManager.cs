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
            return new SuccessResult(GraphicDesignConstants.AddSucces);
        }

        public IResult Delete(GraphicDesign entity)
        {
            _graphicDesignDal.Delete(entity);
            return new SuccessResult(GraphicDesignConstants.DeleteSucces);
        }

        public IResult Update(GraphicDesign entity)
        {
            _graphicDesignDal.Update(entity);
            return new SuccessResult(GraphicDesignConstants.UpdateSucces);
        }

        public IDataResult<List<GraphicDesign>> GetByFilterList(Expression<Func<GraphicDesign, bool>>? filter = null)
        {
            return new SuccessDataResult<List<GraphicDesign>>(_graphicDesignDal.GetAll(filter).ToList(), GraphicDesignConstants.DataGet);
        }

        public IDataResult<GraphicDesign> GetById(int id)
        {
            return new SuccessDataResult<GraphicDesign>(_graphicDesignDal.Get(i => i.Id == id && !i.IsDeleted),GraphicDesignConstants.DataGet);
        }

        public IDataResult<GraphicDesign> GetByName(string name)
        {
            GraphicDesign graphicDesign = _graphicDesignDal.Get(n => n.Name.ToLower().Contains(name.ToLower()) && !n.IsDeleted);
            return graphicDesign == null
                ? new ErrorDataResult<GraphicDesign>(GraphicDesignConstants.DataNotGet)
                : new SuccessDataResult<GraphicDesign>(graphicDesign, GraphicDesignConstants.DataGet);
        }

        public IDataResult<GraphicDesign> GetBySurname(string surname)
        {
            GraphicDesign graphicDesign = _graphicDesignDal.Get(n => n.SurName.ToLower().Contains(surname.ToLower()) && !n.IsDeleted);
            return graphicDesign == null
                ? new ErrorDataResult<GraphicDesign>(GraphicDesignConstants.DataNotGet)
                : new SuccessDataResult<GraphicDesign>(graphicDesign, GraphicDesignConstants.DataGet);
        }

        public IDataResult<List<GraphicDesign>> GetList()
        {
            return new SuccessDataResult<List<GraphicDesign>>(_graphicDesignDal.GetAll().ToList(), GraphicDesignConstants.DataGet);
        }

        private IResult GraphicDesignNameOrSurnameExist(GraphicDesign entity)
        {
            bool result = _graphicDesignDal.GetAll(w => w.Name.ToUpperInvariant().Equals(entity.Name.ToUpperInvariant())
            && w.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())).Any();
            return !result
                ? new ErrorResult(GraphicDesignConstants.NameOrSurnameExist)
                : new SuccessResult(GraphicDesignConstants.DataGet);
        }
    }
}
