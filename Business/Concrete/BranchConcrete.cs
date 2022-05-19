using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;

namespace Business.Concrete
{
    public class BranchConcrete : IBranchService
    {
        private readonly IBranchDal _branchDal;

        public BranchConcrete(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        [ValidationAspect(typeof(BranchValidator), Priority = 1)]
        public IResult Add(string branchName)
        {
            IResult result = BusinessRules.Run(BranchNameControl(branchName));
            if (result != null)
                return result;

            Branch branch = new() { Name = branchName };

            _branchDal.Add(branch);

            return new SuccessResult(BranchConstants.AddSuccess);
        }

        public IResult Delete(int bId)
        {
            Branch branch = _branchDal.Get(i => i.Id == bId && !i.IsDeleted);
            if (branch == null)
                return new ErrorResult(BranchConstants.DataNotGet);
            _branchDal.Delete(branch);
            return new SuccessResult(BranchConstants.DeleteSuccess);
        }

        public IDataResult<Branch> Get(int bId)
        {
            Branch branch = _branchDal.Get(i => i.Id == bId && !i.IsDeleted);
            return branch != null
                ? new SuccessDataResult<Branch>(branch, BranchConstants.DataGet)
                : new ErrorDataResult<Branch>(BranchConstants.DataNotGet);
        }

        public IResult ShadowDelete(int bId)
        {
            Branch branch = _branchDal.Get(i => i.Id == bId && !i.IsDeleted);
            if (branch == null)
                return new ErrorResult(BranchConstants.DataNotGet);
            branch.IsDeleted = true;
            _branchDal.Update(branch);
            return new SuccessResult(BranchConstants.ShadowDeleteSuccess);
        }

        public IDataResult<List<Branch>> GetAll()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(b => !b.IsDeleted).ToList(), BranchConstants.DataGet);
        }

        [ValidationAspect(typeof(ImageValidator), Priority = 1)]
        public IResult Update(int oldBId, string newBranchName)
        {
            Branch branch = _branchDal.Get(i => i.Id == oldBId && !i.IsDeleted);
            if (branch == null)
                return new ErrorResult(BranchConstants.DataNotGet);
            branch.Name = newBranchName;
            _branchDal.Update(branch);
            return new SuccessResult(BranchConstants.ShadowDeleteSuccess);
        }

        private IResult BranchNameControl(string branchName)
        {
            Branch? branch = _branchDal.Get(b => b.Name.ToLowerInvariant().Contains(branchName.ToLowerInvariant()));
            return branch == null
                ? new SuccessResult()
                : new ErrorResult(BranchConstants.BranchExist);
        }

    }
}
