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

        public ConsultantManager(IConsultantDal consultantDal)
        {
            _consultantDal = consultantDal;
        }

        [ValidationAspect(typeof(Consultant), Priority = 1)]
        public IResult Add(Consultant entity)
        {
            IResult result = BusinessRules.Run(ConsultantExist(entity));
            if (result != null)
                return result;
            entity.IsDeleted = false;
            _consultantDal.Add(entity);
            return new SuccessResult(ConsultantConstants.AddSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Consultant consultant = _consultantDal.Get(c => c.Id == id && !c.IsDeleted);
            if (consultant == null)
                return new ErrorResult(ConsultantConstants.NotMatch);

            consultant.IsDeleted = true;
            _consultantDal.Update(consultant);
            return new SuccessResult(ConsultantConstants.ShadowDeleteSuccess);
        }

        public IResult Delete(Guid id)
        {
            Consultant consultant = _consultantDal.Get(c => c.Id == id);
            if (consultant == null)
                return new ErrorResult(ConsultantConstants.DataNotGet);

            _consultantDal.Delete(consultant);
            return new SuccessResult(ConsultantConstants.DeleteSuccess);
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

        public IDataResult<List<Consultant>> GetByFilterLists(Expression<Func<Consultant, bool>>? filter = null)
        {
            List<Consultant> consultants = _consultantDal.GetAll(filter).ToList();

            if (consultants == null)
                return new ErrorDataResult<List<Consultant>>(ConsultantConstants.DataNotGet);
            return new SuccessDataResult<List<Consultant>>(consultants, ConsultantConstants.DataGet);
        }

        public IDataResult<Consultant> GetById(Guid id)
        {
            Consultant consultant = _consultantDal.Get(c => c.Id == id);
            if (consultant == null)
                return new ErrorDataResult<Consultant>(ConsultantConstants.NotMatch);
            return new SuccessDataResult<Consultant>(consultant, ConsultantConstants.NotMatch);
        }

        public IDataResult<List<Consultant>> GetByNames(string name)
        {
            List<Consultant> consultants = _consultantDal.GetAll(c => c.Name.Contains(name)&& !c.IsDeleted).ToList();

            if (consultants == null)
                return new ErrorDataResult<List<Consultant>>(ConsultantConstants.DataNotGet);
            return new SuccessDataResult<List<Consultant>>(consultants, ConsultantConstants.DataGet);
        }

        public IDataResult<List<Consultant>> GetBySurnames(string surname)
        {
            List<Consultant> consultants = _consultantDal.GetAll(c => c.SurName.Contains(surname) && !c.IsDeleted).ToList();

            if (consultants == null)
                return new ErrorDataResult<List<Consultant>>(ConsultantConstants.DataNotGet);
            return new SuccessDataResult<List<Consultant>>(consultants, ConsultantConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetByThesisInConsultants(Guid id)
        {

            return new ErrorDataResult<List<Thesis>>(ConsultantConstants.Maintenance);
            //List<Thesis> theses = _thesisDal.GetAll(t => t.FirstPagePersonBases.Consultant.Id == id && !t.IsSecret).ToList();
            //if (theses == null)
            //    return new ErrorDataResult<List<Thesis>>(ConsultantConstants.NotMatch);
            //return new SuccessDataResult<List<Thesis>>(theses, ConsultantConstants.DataGet);

        }

        public IDataResult<List<Consultant>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Consultant>>(_consultantDal.GetAll(c => !c.IsDeleted).ToList(), ConsultantConstants.DataGet);
        }

        public IDataResult<List<Consultant>> GetAll()
        {
            return new SuccessDataResult<List<Consultant>>(_consultantDal.GetAll(c => !c.IsDeleted).ToList(), ConsultantConstants.DataGet);
        }

        private IResult ConsultantExist(Consultant entity)
        {
            Consultant consultant = _consultantDal.Get(c => c.Name == entity.Name
            && c.SurName == entity.SurName
            && c.NamePreAttachment == entity.NamePreAttachment);

            if (consultant == null)
                return new SuccessResult();
            return new ErrorResult(ConsultantConstants.AlreadyExists);
        }
    }
}
