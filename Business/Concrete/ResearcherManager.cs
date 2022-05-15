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
    public class ResearcherManager : IResearcherService
    {
        private readonly IResearcherDal _researcherDal;

        public ResearcherManager(IResearcherDal researcherDal)
        {
            _researcherDal = researcherDal;
        }

        [ValidationAspect(typeof(ResearcherValidator), Priority = 1)]
        public IResult Add(Researcher entity)
        {
            IResult result = BusinessRules.Run(ResearcherNameOrSurnameExist(entity));
            if (result != null)
                return result;
            entity.IsDeleted = false;
            _researcherDal.Delete(entity);
            return new SuccessResult(ResearcherConstants.AddSuccess);
        }

        public IResult Delete(Researcher entity)
        {
            _researcherDal.Delete(entity);
            return new SuccessResult(ResearcherConstants.DeleteSuccess);
        }

        public IResult Update(Researcher entity)
        {
            _researcherDal.Update(entity);
            return new SuccessResult(ResearcherConstants.UpdateSuccess);
        }

        public IDataResult<List<Researcher>> GetByFilterList(Expression<Func<Researcher, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Researcher>>(_researcherDal.GetAll(filter).ToList(), ResearcherConstants.DataGet);
        }

        public IDataResult<Researcher> GetById(Guid id)
        {
            return new SuccessDataResult<Researcher>(_researcherDal.Get(i => i.Id == id && !i.IsDeleted), ResearcherConstants.DataGet);
        }

        public IDataResult<Researcher> GetByName(string name)
        {
            Researcher researcher = _researcherDal.Get(n => n.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            return researcher == null
                ? new ErrorDataResult<Researcher>(ResearcherConstants.DataNotGet)
                : new SuccessDataResult<Researcher>(researcher, ResearcherConstants.DataGet);
        }

        public IDataResult<Researcher> GetBySurname(string surname)
        {
            Researcher researcher = _researcherDal.Get(n => n.SurName.ToLowerInvariant().Contains(surname.ToLowerInvariant()));
            return researcher == null
                ? new ErrorDataResult<Researcher>(ResearcherConstants.DataNotGet)
                : new SuccessDataResult<Researcher>(researcher, ResearcherConstants.DataGet);
        }

        public IDataResult<List<Researcher>> GetNamePreAttachmentList(string namePreAttachment)
        {
            List<Researcher> researchers = _researcherDal.GetAll(n => n.NamePreAttachment.ToLowerInvariant().Contains(namePreAttachment.ToLowerInvariant()) && !n.IsDeleted).ToList();
            return researchers == null
                   ? new ErrorDataResult<List<Researcher>>(ResearcherConstants.DataNotGet)
                   : new SuccessDataResult<List<Researcher>>(researchers, ResearcherConstants.DataGet);
        }

        public IDataResult<List<Researcher>> GetSpecialtyList(string Specialty)
        {
            List<Researcher> researchers = _researcherDal.GetAll(n => n.Specialty.ToLowerInvariant().Contains(Specialty.ToLowerInvariant()) && !n.IsDeleted).ToList();
            return researchers == null
                   ? new ErrorDataResult<List<Researcher>>(ResearcherConstants.DataNotGet)
                   : new SuccessDataResult<List<Researcher>>(researchers, ResearcherConstants.DataGet);
        }

        public IDataResult<List<Researcher>> GetList()
        {
            return new SuccessDataResult<List<Researcher>>(_researcherDal.GetAll().ToList(), ResearcherConstants.DataGet);

        }

        private IResult ResearcherNameOrSurnameExist(Researcher entity)
        {
            bool result = _researcherDal.GetAll(r =>
               r.Name.ToUpperInvariant().Equals(entity.Name.ToUpperInvariant())
            && r.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())
            && r.NamePreAttachment.Equals(null)
            && entity.NamePreAttachment != null
            && r.Specialty.ToLowerInvariant().Equals(entity.Specialty.ToLowerInvariant())).Any();
            return result
                ? new ErrorResult(ResearcherConstants.NameOrSurnameExists)
                : new SuccessResult(ResearcherConstants.DataGet);
        }
    }
}
