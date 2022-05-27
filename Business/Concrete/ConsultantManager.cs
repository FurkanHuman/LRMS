using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ConsultantManager : IConsultantService
    {
        private readonly IConsultantDal _consultantDal;
        private readonly IThesisDal _thesisDal;

        public ConsultantManager(IConsultantDal consultantDal, IThesisDal thesisDal)
        {
            _consultantDal = consultantDal;
            _thesisDal = thesisDal;
        }

        [ValidationAspect(typeof(Consultant), Priority = 1)]
        public IResult Add(Consultant entity)
        {
            IResult result = BusinessRules.Run(ConsultantExist(entity));
            if (result != null)
                return result;

            _consultantDal.Add(entity);
            return new SuccessResult(ConsultantConstants.AddSuccess);
        }

        public IResult ShadowDelete(Guid guid)
        {
            Consultant consultant = _consultantDal.Get(c => c.Id == guid && !c.IsDeleted);
            if (consultant == null)
                return new ErrorResult(ConsultantConstants.NotMatch);
            consultant.IsDeleted = true;

            _consultantDal.Update(consultant);
            return new SuccessResult(ConsultantConstants.ShadowDeleteSuccess);
        }

        public IResult Delete(Consultant entity)
        {
            Consultant consultant = _consultantDal.Get(c => c == entity);
            if (consultant == null)
                return new ErrorResult(ConsultantConstants.DataNotGet);

            _consultantDal.Delete(entity);
            return new SuccessResult(ConsultantConstants.DeleteSuccess);
        }

        public IDataResult<List<Consultant>> GetByFilterList(Expression<Func<Consultant, bool>>? filter = null)
        {
            List<Consultant> consultants = _consultantDal.GetAll(filter).ToList();

            if (consultants == null)
                return new ErrorDataResult<List<Consultant>>(ConsultantConstants.DataNotGet);
            return new SuccessDataResult<List<Consultant>>(consultants, ConsultantConstants.DataGet);
        }

        public IDataResult<Consultant> GetById(Guid id)
        {
            Consultant consultant = _consultantDal.Get(c => c.Id == id && !c.IsDeleted);
            if (consultant == null)
                return new ErrorDataResult<Consultant>(ConsultantConstants.NotMatch);
            return new SuccessDataResult<Consultant>(consultant, ConsultantConstants.NotMatch);
        }

        public IDataResult<List<Consultant>> GetByNames(string name)
        {
            List<Consultant> consultants = _consultantDal.GetAll(c => c.Name.ToLowerInvariant() == name.ToLowerInvariant() && !c.IsDeleted).ToList();

            if (consultants == null)
                return new ErrorDataResult<List<Consultant>>(ConsultantConstants.DataNotGet);
            return new SuccessDataResult<List<Consultant>>(consultants, ConsultantConstants.DataGet);
        }

        public IDataResult<List<Consultant>> GetBySurnames(string surname)
        {
            List<Consultant> consultants = _consultantDal.GetAll(c => c.SurName.ToLowerInvariant() == surname.ToLowerInvariant() && !c.IsDeleted).ToList();

            if (consultants == null)
                return new ErrorDataResult<List<Consultant>>(ConsultantConstants.DataNotGet);
            return new SuccessDataResult<List<Consultant>>(consultants, ConsultantConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetByThesisInConsultant(Guid gId)
        {
            List<Thesis> theses = _thesisDal.GetAll(t => t.Consultant.Id == gId && !t.IsSecret).ToList();
            if (theses == null)
                return new ErrorDataResult<List<Thesis>>(ConsultantConstants.NotMatch);
            return new SuccessDataResult<List<Thesis>>(theses, ConsultantConstants.DataGet);

        }

        public IDataResult<List<Consultant>> GetList()
        {
            return new SuccessDataResult<List<Consultant>>(_consultantDal.GetAll(c => !c.IsDeleted).ToList(), ConsultantConstants.DataGet);
        }

        [ValidationAspect(typeof(Consultant), Priority = 1)]
        public IResult Update(Consultant entity)
        {
            IResult result = BusinessRules.Run(ConsultantExist(entity));
            if (result != null)
                return result;

            _consultantDal.Update(entity);
            return new SuccessResult(ConsultantConstants.UpdateSuccess);
        }

        private IResult ConsultantExist(Consultant entity)
        {
            Consultant consultant = _consultantDal.Get(c => c.Name.ToLowerInvariant() == entity.Name.ToLowerInvariant()
            && c.SurName.ToLowerInvariant() == entity.SurName.ToLowerInvariant()
            && c.NamePreAttachment.ToLowerInvariant() == entity.NamePreAttachment.ToLowerInvariant());

            if (consultant == null)
                return new SuccessResult();
            return new ErrorResult(ConsultantConstants.AlreadyExists);
        }
    }
}
