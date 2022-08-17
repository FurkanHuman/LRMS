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

        public IDataResult<IList<Branch>> GetAllByIds(int[] ids)
        {
            IList<Branch> branchs = _branchDal.GetAll(b => ids.Contains(b.Id) && !b.IsDeleted);
            return branchs != null
                ? new SuccessDataResult<IList<Branch>>(branchs, BranchConstants.DataGet)
                : new ErrorDataResult<IList<Branch>>(BranchConstants.DataNotGet);
        }

        public IDataResult<IList<Branch>> GetAllByName(string name)
        {
            IList<Branch> branchs = _branchDal.GetAll(b => b.Name.Contains(name) && !b.IsDeleted);
            return branchs != null
                ? new SuccessDataResult<IList<Branch>>(branchs, BranchConstants.DataGet)
                : new ErrorDataResult<IList<Branch>>(BranchConstants.DataNotGet);
        }

        public IDataResult<IList<Branch>> GetAllByFilter(Expression<Func<Branch, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Branch>>(_branchDal.GetAll(filter), BranchConstants.DataGet);
        }

        public IDataResult<IList<Branch>> GetAll()
        {
            return new SuccessDataResult<IList<Branch>>(_branchDal.GetAll(b => !b.IsDeleted), BranchConstants.DataGet);
        }

        public IDataResult<IList<Branch>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Branch>>(_branchDal.GetAll(b => b.IsDeleted), BranchConstants.DataGet);
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
