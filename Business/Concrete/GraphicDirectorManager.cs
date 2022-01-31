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
    public class GraphicDirectorManager : IGraphicDirectorService
    {

        private readonly IGraphicDirectorDal _graphicDirectorDal;

        private static int namelength = 3;
        private static int surnameNamelength = 2;

        public GraphicDirectorManager(IGraphicDirectorDal graphicDirectorDal)
        {
            _graphicDirectorDal = graphicDirectorDal;
        }

        public IResult Add(GraphicDirector entity)
        {
            IResult result = BusinessRules.Run(GraphicDirectorControl(entity));
            if (result != null)
                return result;
            _graphicDirectorDal.Add(entity);
            return new SuccessResult(GraphicDirectorConstants.AddSucces);
        }

        public IResult Delete(GraphicDirector entity)
        {
            IResult result = BusinessRules.Run(GraphicDirectorControl(entity));
            if (result != null)
                return result;
            entity.IsDeleted = true;
            _graphicDirectorDal.Update(entity);
            return new SuccessResult(GraphicDirectorConstants.AddSucces);
        }

        public IResult Update(GraphicDirector entity)
        {
            IResult result = BusinessRules.Run(GraphicDirectorControl(entity), UpdateControl(entity));
            if (result != null)
                return result;
            _graphicDirectorDal.Update(entity);
            return new SuccessResult(GraphicDirectorConstants.AddSucces);
        }

        public IDataResult<List<GraphicDirector>> GetByFilterList(Expression<Func<GraphicDirector, bool>>? filter = null)
        {
            return new SuccessDataResult<List<GraphicDirector>>(_graphicDirectorDal.GetAll(filter).ToList(), GraphicDirectorConstants.DataGet);
        }

        public IDataResult<GraphicDirector> GetById(int id)
        {
            return new SuccessDataResult<GraphicDirector>(_graphicDirectorDal.Get(i => i.Id == id && !i.IsDeleted));
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

        private static IResult GraphicDirectorControl(GraphicDirector entity)
        {
            if (entity == null)
                return new ErrorResult(GraphicDirectorConstants.GraphicDirectorNull);
            if (entity.Name.Equals(null) || entity.Name.Equals(string.Empty) || entity.Name.Length >= namelength)
                return new ErrorResult(GraphicDirectorConstants.GraphicDirectorNameLengthNotEnough);
            if (entity.SurName.Equals(null) || entity.SurName.Equals(string.Empty) || entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(GraphicDirectorConstants.GraphicDirectorNameLengthNotEnough);

            return new SuccessResult();
        }

        private IResult UpdateControl(GraphicDirector entity)
        {
            GraphicDirector updateGraphicDirector = _graphicDirectorDal.Get(i => i == entity);

            if (updateGraphicDirector == null)
                return new ErrorResult(GraphicDirectorConstants.GraphicDirectorNull);
            if (entity.Name.Equals(updateGraphicDirector.Name) || entity.SurName.Equals(updateGraphicDirector.SurName)
                || entity.Name.Length >= namelength && entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(GraphicDirectorConstants.GraphicDirectorEquals);

            return new SuccessResult();
        }
    }
}
