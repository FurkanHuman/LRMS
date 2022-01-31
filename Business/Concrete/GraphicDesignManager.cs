using Business.Abstract;
using Business.Constants;
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

        private static int namelength = 3;
        private static int surnameNamelength = 2;

        public GraphicDesignManager(IGraphicDesignDal graphicDesignDal)
        {
            _graphicDesignDal = graphicDesignDal;
        }

        public IResult Add(GraphicDesign entity)
        {
            IResult result = BusinessRules.Run(GraphicDesignControl(entity));
            if (result != null)
                return result;
            _graphicDesignDal.Add(entity);
            return new SuccessResult(GraphicDesignConstants.AddSucces);
        }

        public IResult Delete(GraphicDesign entity)
        {
            IResult result = BusinessRules.Run(GraphicDesignControl(entity));
            if (result != null)
                return result;
            entity.IsDeleted = true;
            _graphicDesignDal.Update(entity);
            return new SuccessResult(GraphicDesignConstants.AddSucces);
        }

        public IResult Update(GraphicDesign entity)
        {
            IResult result = BusinessRules.Run(GraphicDesignControl(entity), UpdateControl(entity));
            if (result != null)
                return result;
            _graphicDesignDal.Update(entity);
            return new SuccessResult(GraphicDesignConstants.AddSucces);
        }

        public IDataResult<List<GraphicDesign>> GetByFilterList(Expression<Func<GraphicDesign, bool>>? filter = null)
        {
            return new SuccessDataResult<List<GraphicDesign>>(_graphicDesignDal.GetAll(filter).ToList(), GraphicDesignConstants.DataGet);
        }

        public IDataResult<GraphicDesign> GetById(int id)
        {
            return new SuccessDataResult<GraphicDesign>(_graphicDesignDal.Get(i => i.Id == id && !i.IsDeleted));
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

        private static IResult GraphicDesignControl(GraphicDesign entity)
        {
            if (entity == null)
                return new ErrorResult(GraphicDesignConstants.GraphicDesignNull);
            if (entity.Name.Equals(null) || entity.Name.Equals(string.Empty) || entity.Name.Length >= namelength)
                return new ErrorResult(GraphicDesignConstants.GraphicDesignNameLengthNotEnough);
            if (entity.SurName.Equals(null) || entity.SurName.Equals(string.Empty) || entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(GraphicDesignConstants.GraphicDesignNameLengthNotEnough);

            return new SuccessResult();
        }

        private IResult UpdateControl(GraphicDesign entity)
        {
            GraphicDesign updateGraphicDesign = _graphicDesignDal.Get(i => i == entity);

            if (updateGraphicDesign == null)
                return new ErrorResult(GraphicDesignConstants.GraphicDesignNull);
            if (entity.Name.Equals(updateGraphicDesign.Name) || entity.SurName.Equals(updateGraphicDesign.SurName)
                || entity.Name.Length >= namelength && entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(GraphicDesignConstants.GraphicDesignEquals);

            return new SuccessResult();
        }
    }
}
