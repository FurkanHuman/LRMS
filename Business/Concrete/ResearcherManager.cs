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

        public IDataResult<List<Researcher>> GetByFilterLists(Expression<Func<Researcher, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Researcher>>(_researcherDal.GetAll(filter).ToList(), ResearcherConstants.DataGet);
        }

        public IDataResult<Researcher> GetById(Guid id)
        {
            return new SuccessDataResult<Researcher>(_researcherDal.Get(i => i.Id == id && !i.IsDeleted), ResearcherConstants.DataGet);
        }

        public IDataResult<List<Researcher>> GetByNames(string name)
        {
            List<Researcher> researchers = _researcherDal.GetAll(n => n.Name .Contains(name )).ToList();
            return researchers == null
                ? new ErrorDataResult<List<Researcher>>(ResearcherConstants.DataNotGet)
                : new SuccessDataResult<List<Researcher>>(researchers, ResearcherConstants.DataGet);
        }

        public IDataResult<List<Researcher>> GetBySurnames(string surname)
        {
            List<Researcher> researchers = _researcherDal.GetAll(n => n.SurName .Contains(surname )).ToList();
            return researchers == null
                ? new ErrorDataResult<List<Researcher>>(ResearcherConstants.DataNotGet)
                : new SuccessDataResult<List<Researcher>>(researchers, ResearcherConstants.DataGet);
        }

        public IDataResult<List<Researcher>> GetNamePreAttachmentList(string namePreAttachment)
        {
            List<Researcher> researchers = _researcherDal.GetAll(n => n.NamePreAttachment.Contains(namePreAttachment ) && !n.IsDeleted).ToList();
            return researchers == null
                   ? new ErrorDataResult<List<Researcher>>(ResearcherConstants.DataNotGet)
                   : new SuccessDataResult<List<Researcher>>(researchers, ResearcherConstants.DataGet);
        }

        public IDataResult<List<Researcher>> GetSpecialtyList(string Specialty)
        {
            List<Researcher> researchers = _researcherDal.GetAll(n => n.Specialty .Contains(Specialty ) && !n.IsDeleted).ToList();
            return researchers == null
                   ? new ErrorDataResult<List<Researcher>>(ResearcherConstants.DataNotGet)
                   : new SuccessDataResult<List<Researcher>>(researchers, ResearcherConstants.DataGet);
        }

        public IDataResult<List<Researcher>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Researcher>>(_researcherDal.GetAll(r => !r.IsDeleted).ToList(), ResearcherConstants.DataGet);
        }

        public IDataResult<List<Researcher>> GetAll()
        {
            return new SuccessDataResult<List<Researcher>>(_researcherDal.GetAll(r => !r.IsDeleted).ToList(), ResearcherConstants.DataGet);
        }

        private IResult ResearcherNameOrSurnameExist(Researcher entity)
        {
            bool result = _researcherDal.GetAll(r =>
               r.Name.Equals(entity.Name )
            && r.SurName.Equals(entity.SurName )
            && r.NamePreAttachment.Equals(null)
            && entity.NamePreAttachment != null
            && r.Specialty.Equals(entity.Specialty )).Any();
            return result
                ? new ErrorResult(ResearcherConstants.NameOrSurnameExists)
                : new SuccessResult(ResearcherConstants.DataGet);
        }
    }
}
