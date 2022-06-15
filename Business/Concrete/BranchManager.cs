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
    public class BranchManager : IBranchService
    {
        private readonly IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        [ValidationAspect(typeof(BranchValidator), Priority = 1)]
        public IResult Add(Branch branch)
        {
            IResult result = BusinessRules.Run(BranchNameControl(branch.Name));
            if (result != null)
                return result;

            branch.IsDeleted = false;
            _branchDal.Add(branch);

            return new SuccessResult(BranchConstants.AddSuccess);
        }

        public IResult Delete(int id)
        {
            Branch branch = _branchDal.Get(i => i.Id == id && !i.IsDeleted);
            if (branch == null)
                return new ErrorResult(BranchConstants.DataNotGet);
            _branchDal.Delete(branch);
            return new SuccessResult(BranchConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(int id)
        {
            Branch branch = _branchDal.Get(i => i.Id == id && !i.IsDeleted);
            if (branch == null)
                return new ErrorResult(BranchConstants.DataNotGet);

            branch.IsDeleted = true;
            _branchDal.Update(branch);
            return new SuccessResult(BranchConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(ImageValidator), Priority = 1)]
        public IResult Update(Branch branch)
        {
            IResult result = BusinessRules.Run(BranchNameControl(branch.Name));
            if (result != null)
                return result;

            branch.IsDeleted = false;
            _branchDal.Update(branch);
            return new SuccessResult(BranchConstants.UpdateSuccess);
        }

        public IDataResult<Branch> GetById(int id)
        {
            Branch branch = _branchDal.Get(i => i.Id == id);
            return branch != null
                ? new SuccessDataResult<Branch>(branch, BranchConstants.DataGet)
                : new ErrorDataResult<Branch>(BranchConstants.DataNotGet);
        }

        public IDataResult<List<Branch>> GetByNames(string name)
        {
            List<Branch> branchs = _branchDal.GetAll(b => b.Name.Contains(name) && !b.IsDeleted).ToList();
            return branchs != null
                ? new SuccessDataResult<List<Branch>>(branchs, BranchConstants.DataGet)
                : new ErrorDataResult<List<Branch>>(BranchConstants.DataNotGet);
        }

        public IDataResult<List<Branch>> GetAllByFilter(Expression<Func<Branch, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(filter).ToList(), BranchConstants.DataGet);
        }

        public IDataResult<List<Branch>> GetAll()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(b => !b.IsDeleted).ToList(), BranchConstants.DataGet);
        }

        public IDataResult<List<Branch>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(b => b.IsDeleted).ToList(), BranchConstants.DataGet);
        }

        private IResult BranchNameControl(string branchName)
        {
            Branch branch = _branchDal.Get(b => b.Name.Contains(branchName));
            return branch == null
                ? new SuccessResult()
                : new ErrorResult(BranchConstants.BranchExist);
        }
    }
}
