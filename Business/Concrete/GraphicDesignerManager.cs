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
    public class GraphicDesignerManager : IGraphicDesignerService
    {
        private readonly IGraphicDesignerDal _graphicDesignDal;

        public GraphicDesignerManager(IGraphicDesignerDal graphicDesignDal)
        {
            _graphicDesignDal = graphicDesignDal;
        }

        [ValidationAspect(typeof(GraphicDesignerValidator), Priority = 1)]
        public IResult Add(GraphicDesigner entity)
        {
            IResult result = BusinessRules.Run(GraphicDesignNameOrSurnameExist(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _graphicDesignDal.Add(entity);
            return new SuccessResult(GraphicDesignerConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            GraphicDesigner graphicDesign = _graphicDesignDal.Get(gd => gd.Id == id);
            if (graphicDesign == null)
                return new ErrorResult(GraphicDesignerConstants.NotMatch);

            _graphicDesignDal.Delete(graphicDesign);
            return new SuccessResult(GraphicDesignerConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            GraphicDesigner graphicDesign = _graphicDesignDal.Get(g => g.Id == id);
            if (graphicDesign == null)
                return new ErrorResult(GraphicDesignerConstants.NotMatch);

            graphicDesign.IsDeleted = true;
            _graphicDesignDal.Update(graphicDesign);
            return new SuccessResult(GraphicDesignerConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(GraphicDesignerValidator), Priority = 1)]
        public IResult Update(GraphicDesigner entity)
        {
            _graphicDesignDal.Update(entity);
            return new SuccessResult(GraphicDesignerConstants.UpdateSuccess);
        }

        public IDataResult<List<GraphicDesigner>> GetAllByFilter(Expression<Func<GraphicDesigner, bool>>? filter = null)
        {
            return new SuccessDataResult<List<GraphicDesigner>>(_graphicDesignDal.GetAll(filter).ToList(), GraphicDesignerConstants.DataGet);
        }

        public IDataResult<GraphicDesigner> GetById(Guid id)
        {
            GraphicDesigner graphicDesigner = _graphicDesignDal.Get(g => g.Id == id);
            return graphicDesigner == null
                ? new ErrorDataResult<GraphicDesigner>(GraphicDesignerConstants.NotMatch)
                : new SuccessDataResult<GraphicDesigner>(graphicDesigner, GraphicDesignerConstants.DataGet);
        }

        public IDataResult<List<GraphicDesigner>> GetAllByIds(Guid[] ids)
        {
            List<GraphicDesigner> graphicDesigns = _graphicDesignDal.GetAll(n => ids.Contains(n.Id) && !n.IsDeleted).ToList();

            return graphicDesigns == null
                ? new ErrorDataResult<List<GraphicDesigner>>(GraphicDesignerConstants.DataNotGet)
                : new SuccessDataResult<List<GraphicDesigner>>(graphicDesigns, GraphicDesignerConstants.DataGet);
        }

        public IDataResult<List<GraphicDesigner>> GetAllByName(string name)
        {
            List<GraphicDesigner> graphicDesigns = _graphicDesignDal.GetAll(n => n.Name.Contains(name) && !n.IsDeleted).ToList();

            return graphicDesigns == null
                ? new ErrorDataResult<List<GraphicDesigner>>(GraphicDesignerConstants.DataNotGet)
                : new SuccessDataResult<List<GraphicDesigner>>(graphicDesigns, GraphicDesignerConstants.DataGet);
        }

        public IDataResult<List<GraphicDesigner>> GetAllBySurname(string surname)
        {
            List<GraphicDesigner> graphicDesigns = _graphicDesignDal.GetAll(n => n.SurName.Contains(surname) && !n.IsDeleted).ToList();
            return graphicDesigns == null
                ? new ErrorDataResult<List<GraphicDesigner>>(GraphicDesignerConstants.DataNotGet)
                : new SuccessDataResult<List<GraphicDesigner>>(graphicDesigns, GraphicDesignerConstants.DataGet);
        }

        public IDataResult<List<GraphicDesigner>> GetAll()
        {
            return new SuccessDataResult<List<GraphicDesigner>>(_graphicDesignDal.GetAll(gd => !gd.IsDeleted).ToList(), GraphicDesignerConstants.DataGet);
        }
        public IDataResult<List<GraphicDesigner>> GetAllBySecret()
        {
            return new SuccessDataResult<List<GraphicDesigner>>(_graphicDesignDal.GetAll(gd => gd.IsDeleted).ToList(), GraphicDesignerConstants.DataGet);
        }

        private IResult GraphicDesignNameOrSurnameExist(GraphicDesigner entity)
        {
            bool result = _graphicDesignDal.GetAll(w => w.Name.Equals(entity.Name)
            && w.SurName.Equals(entity.SurName)).Any();
            return result
                ? new ErrorResult(GraphicDesignerConstants.NameOrSurnameExists)
                : new SuccessResult(GraphicDesignerConstants.DataGet);
        }
    }
}
