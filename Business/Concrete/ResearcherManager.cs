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
            _researcherDal.Add(entity);
            return new SuccessResult(ResearcherConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Researcher researcher = _researcherDal.Get(r => r.Id == id);
            if (researcher == null)
                return new ErrorResult(ResearcherConstants.DataNotGet);

            _researcherDal.Delete(researcher);
            return new SuccessResult(ResearcherConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Researcher researcher = _researcherDal.Get(r => r.Id == id && !r.IsDeleted);
            if (researcher == null)
                return new ErrorResult(ResearcherConstants.NotMatch);

            researcher.IsDeleted = true;
            _researcherDal.Update(researcher);
            return new SuccessResult(ResearcherConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(ResearcherValidator), Priority = 1)]
        public IResult Update(Researcher entity)
        {
            _researcherDal.Update(entity);
            return new SuccessResult(ResearcherConstants.UpdateSuccess);
        }

        public IDataResult<IList<Researcher>> GetAllByFilter(Expression<Func<Researcher, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Researcher>>(_researcherDal.GetAll(filter), ResearcherConstants.DataGet);
        }

        public IDataResult<Researcher> GetById(Guid id)
        {
            Researcher researcher = _researcherDal.Get(i => i.Id == id && !i.IsDeleted);

            return researcher == null
                ? new ErrorDataResult<Researcher>(ResearcherConstants.NotMatch)
                : new SuccessDataResult<Researcher>(researcher, ResearcherConstants.DataGet);
        }

        public IDataResult<IList<Researcher>> GetAllByIds(Guid[] ids)
        {
            IList<Researcher> researchers = _researcherDal.GetAll(n => ids.Contains(n.Id));
            return researchers == null
                ? new ErrorDataResult<IList<Researcher>>(ResearcherConstants.DataNotGet)
                : new SuccessDataResult<IList<Researcher>>(researchers, ResearcherConstants.DataGet);
        }

        public IDataResult<IList<Researcher>> GetAllByName(string name)
        {
            IList<Researcher> researchers = _researcherDal.GetAll(n => n.Name.Contains(name));
            return researchers == null
                ? new ErrorDataResult<IList<Researcher>>(ResearcherConstants.DataNotGet)
                : new SuccessDataResult<IList<Researcher>>(researchers, ResearcherConstants.DataGet);
        }

        public IDataResult<IList<Researcher>> GetAllBySurname(string surname)
        {
            IList<Researcher> researchers = _researcherDal.GetAll(n => n.SurName.Contains(surname));
            return researchers == null
                ? new ErrorDataResult<IList<Researcher>>(ResearcherConstants.DataNotGet)
                : new SuccessDataResult<IList<Researcher>>(researchers, ResearcherConstants.DataGet);
        }

        public IDataResult<IList<Researcher>> GetAllNamePreAttachment(string namePreAttachment)
        {
            IList<Researcher> researchers = _researcherDal.GetAll(n => n.NamePreAttachment.Contains(namePreAttachment) && !n.IsDeleted);
            return researchers == null
                   ? new ErrorDataResult<IList<Researcher>>(ResearcherConstants.DataNotGet)
                   : new SuccessDataResult<IList<Researcher>>(researchers, ResearcherConstants.DataGet);
        }

        public IDataResult<IList<Researcher>> GetAllSpecialty(string Specialty)
        {
            IList<Researcher> researchers = _researcherDal.GetAll(n => n.Specialty.Contains(Specialty) && !n.IsDeleted);
            return researchers == null
                   ? new ErrorDataResult<IList<Researcher>>(ResearcherConstants.DataNotGet)
                   : new SuccessDataResult<IList<Researcher>>(researchers, ResearcherConstants.DataGet);
        }

        public IDataResult<IList<Researcher>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Researcher>>(_researcherDal.GetAll(r => !r.IsDeleted), ResearcherConstants.DataGet);
        }

        public IDataResult<IList<Researcher>> GetAll()
        {
            return new SuccessDataResult<IList<Researcher>>(_researcherDal.GetAll(r => !r.IsDeleted), ResearcherConstants.DataGet);
        }

        private IResult ResearcherNameOrSurnameExist(Researcher entity)
        {
            bool result = _researcherDal.GetAll(r =>
               r.Name.Equals(entity.Name)
            && r.SurName.Equals(entity.SurName)
            && r.NamePreAttachment.Equals(null)
            && entity.NamePreAttachment != null
            && r.Specialty.Equals(entity.Specialty)).Any();
            return result
                ? new ErrorResult(ResearcherConstants.NameOrSurnameExists)
                : new SuccessResult(ResearcherConstants.DataGet);
        }
    }
}
