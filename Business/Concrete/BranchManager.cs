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


        [ValidationAspect(typeof(BranchValidator), Priority = 1)]
        public IDataResult<BranchAddDto> DtoAdd(BranchAddDto addDto)
        {
            Branch branch = new MapperConfiguration(cfg => cfg.CreateMap<BranchAddDto, Branch>()).CreateMapper().Map<Branch>(addDto);

            IResult result = BusinessRules.Run(BranchNameControl(branch.Name));
            if (result != null)
                return new ErrorDataResult<BranchAddDto>(result.Message);
            
            branch.IsDeleted = false;

            Branch returnBranch = _branchDal.Add(branch);
            return returnBranch != null
                ? new SuccessDataResult<BranchAddDto>(addDto, BranchConstants.UpdateSuccess)
                : new ErrorDataResult<BranchAddDto>(addDto, BranchConstants.UpdateFailed);
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

            _branchDal.Update(branch);
            return new SuccessResult(BranchConstants.UpdateSuccess);
        }


        [ValidationAspect(typeof(BranchValidator), Priority = 1)]
        public IDataResult<BranchUpdateDto> DtoUpdate(BranchUpdateDto updateDto)
        {
            Branch branch = new MapperConfiguration(cfg => cfg.CreateMap<BranchUpdateDto, Branch>()).CreateMapper().Map<Branch>(updateDto);

            IResult result = BusinessRules.Run(BranchNameControl(branch.Name));
            if (result != null)
                return new ErrorDataResult<BranchUpdateDto>(result.Message);

            Branch returnBranch = _branchDal.Add(branch);
            return returnBranch != null
                ? new SuccessDataResult<BranchUpdateDto>(updateDto, BranchConstants.UpdateSuccess)
                : new ErrorDataResult<BranchUpdateDto>(updateDto, BranchConstants.UpdateFailed);
        }

        public IDataResult<Branch> GetById(int id)
        {
            Branch branch = _branchDal.Get(i => i.Id == id);
            return branch != null
                ? new SuccessDataResult<Branch>(branch, BranchConstants.DataGet)
                : new ErrorDataResult<Branch>(BranchConstants.DataNotGet);
        }

        public IDataResult<BranchDto> DtoGetById(int id)
        {
            BranchDto branchDto = _branchDal.DtoGet(i => i.Id == id);
            return branchDto != null
                ? new SuccessDataResult<BranchDto>(branchDto, BranchConstants.DataGet)
                : new ErrorDataResult<BranchDto>(BranchConstants.DataNotGet);
        }

        public IDataResult<IList<Branch>> GetAllByIds(int[] ids)
        {
            IList<Branch> branchs = _branchDal.GetAll(b => ids.Contains(b.Id) && !b.IsDeleted);
            return branchs != null
                ? new SuccessDataResult<IList<Branch>>(branchs, BranchConstants.DataGet)
                : new ErrorDataResult<IList<Branch>>(BranchConstants.DataNotGet);
        }

        public IDataResult<IList<BranchDto>> DtoGetAllByIds(int[] ids)
        {
            IList<BranchDto> branchDtos = _branchDal.DtoGetAll(b => ids.Contains(b.Id) && !b.IsDeleted);
            return branchDtos != null
                ? new SuccessDataResult<IList<BranchDto>>(branchDtos, BranchConstants.DataGet)
                : new ErrorDataResult<IList<BranchDto>>(BranchConstants.DataNotGet);
        }

        public IDataResult<IList<Branch>> GetAllByName(string name)
        {
            IList<Branch> branchs = _branchDal.GetAll(b => b.Name.Contains(name) && !b.IsDeleted);
            return branchs != null
                ? new SuccessDataResult<IList<Branch>>(branchs, BranchConstants.DataGet)
                : new ErrorDataResult<IList<Branch>>(BranchConstants.DataNotGet);
        }

        public IDataResult<IList<BranchDto>> DtoGetAllByName(string name)
        {
            IList<BranchDto> branchDtos = _branchDal.DtoGetAll(b => b.Name.Contains(name) && !b.IsDeleted);
            return branchDtos != null
                ? new SuccessDataResult<IList<BranchDto>>(branchDtos, BranchConstants.DataGet)
                : new ErrorDataResult<IList<BranchDto>>(BranchConstants.DataNotGet);
        }

        public IDataResult<IList<Branch>> GetAllByFilter(Expression<Func<Branch, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Branch>>(_branchDal.GetAll(filter), BranchConstants.DataGet);
        }

        public IDataResult<IList<BranchDto>> DtoGetAllByFilter(Expression<Func<Branch, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<BranchDto>>(_branchDal.DtoGetAll(filter), BranchConstants.DataGet);
        }

        public IDataResult<IList<Branch>> GetAll()
        {
            return new SuccessDataResult<IList<Branch>>(_branchDal.GetAll(b => !b.IsDeleted), BranchConstants.DataGet);
        }

        public IDataResult<IList<BranchDto>> DtoGetAll()
        {
            return new SuccessDataResult<IList<BranchDto>>(_branchDal.DtoGetAll(b => !b.IsDeleted), BranchConstants.DataGet);
        }

        public IDataResult<IList<Branch>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Branch>>(_branchDal.GetAll(b => b.IsDeleted), BranchConstants.DataGet);
        }

        public IDataResult<IList<BranchDto>> DtoGetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<BranchDto>>(_branchDal.DtoGetAll(b => b.IsDeleted), BranchConstants.DataGet);
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
