namespace Business.Concrete
{
    public class UniversityManager : IUniversityService
    {
        private readonly IUniversityDal _universityDal;
        private readonly IFacadeService _facadeService;

        public UniversityManager(IUniversityDal universityDal)
        {
            _universityDal = universityDal;
        }

        [ValidationAspect(typeof(University), Priority = 1)]
        public IResult Add(University university)
        {
            IResult result = BusinessRules.Run(_facadeService.AddressService().GetById(university.Address.Id), _facadeService.BranchService().GetById(university.Branch.Id), UniversityChecker(university));
            if (result != null)
                return result;

            university.IsDeleted = false;
            _universityDal.Add(university);
            return new SuccessResult(UniversityConstants.UpdateSuccess);
        }

        public IResult Delete(Guid id)
        {
            University university = _universityDal.Get(u => u.Id == id);
            if (university == null)
                return new ErrorResult(UniversityConstants.NotMatch);

            _universityDal.Delete(university);
            return new SuccessResult(UniversityConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            University university = _universityDal.Get(u => u.Id == id && !u.IsDeleted);
            if (university == null)
                return new ErrorResult(UniversityConstants.NotMatch);

            university.IsDeleted = true;
            _universityDal.Update(university);
            return new SuccessResult(UniversityConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(University), Priority = 1)]
        public IResult Update(University university)
        {
            IResult result = BusinessRules.Run(_facadeService.AddressService().GetById(university.Address.Id), _facadeService.BranchService().GetById(university.Branch.Id), UniversityChecker(university));
            if (result != null)
                return result;

            _universityDal.Update(university);
            return new SuccessResult(UniversityConstants.UpdateSuccess);
        }

        public IDataResult<University> GetById(Guid id)
        {
            University university = _universityDal.Get(u => u.Id == id);

            return university == null
                ? new ErrorDataResult<University>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<University>(university, UniversityConstants.DataGet);
        }

        public IDataResult<IList<University>> GetAllByIds(Guid[] ids)
        {
            IList<University> universities = _universityDal.GetAll(u => ids.Contains(u.Id) && !u.IsDeleted);

            return universities == null
                ? new ErrorDataResult<IList<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<IList<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<University> GetByAddressId(Guid id)
        {
            IDataResult<Address> address = _facadeService.AddressService().GetById(id);
            if (!address.Success)
                return new ErrorDataResult<University>(address.Message);

            University university = _universityDal.Get(u => u.Address == address && !u.IsDeleted);
            return university == null
                ? new ErrorDataResult<University>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<University>(university, UniversityConstants.DataGet);
        }

        public IDataResult<IList<University>> GetAllByName(string name)
        {
            IList<University> universities = _universityDal.GetAll(u => u.Name.Contains(name) && !u.IsDeleted);

            return universities == null
                ? new ErrorDataResult<IList<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<IList<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<IList<University>> GetAllByInstituteName(string instituteName)
        {
            IList<University> universities = _universityDal.GetAll(u => u.Institute.Contains(instituteName) && !u.IsDeleted);

            return universities == null
                ? new ErrorDataResult<IList<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<IList<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<IList<University>> GetAllByBranchName(string branchName)
        {
            IList<University> universities = _universityDal.GetAll(u => u.Branch.Name.Contains(branchName) && !u.IsDeleted);

            return universities == null
                ? new ErrorDataResult<IList<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<IList<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<IList<University>> GetAllByBranchId(int branchId)
        {
            IDataResult<Branch> branch = _facadeService.BranchService().GetById(branchId);
            if (!branch.Success)
                return new ErrorDataResult<IList<University>>(branch.Message);

            IList<University> universities = _universityDal.GetAll(u => u.Branch == branch && !u.IsDeleted);

            return universities == null
                ? new ErrorDataResult<IList<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<IList<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<IList<University>> GetAllByCityName(string cityName)
        {
            IList<University> universities = _universityDal.GetAll(u => u.Address.City.Name.Contains(cityName) && !u.IsDeleted);
            return universities == null
                ? new ErrorDataResult<IList<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<IList<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<IList<University>> GetAllByCityId(int cityId)
        {
            IList<University> universities = _universityDal.GetAll(u => u.Address.City.Id == cityId && !u.IsDeleted);
            return universities == null
                ? new ErrorDataResult<IList<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<IList<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<IList<University>> GetAllByCountryName(string countryName)
        {
            IList<University> universities = _universityDal.GetAll(u => u.Address.Country.Name.Contains(countryName) && !u.IsDeleted);

            return universities == null
                ? new ErrorDataResult<IList<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<IList<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<IList<University>> GetAllByCountryId(int countryId)
        {
            IList<University> universities = _universityDal.GetAll(u => u.Address.Country.Id == countryId && !u.IsDeleted);

            return universities == null
                ? new ErrorDataResult<IList<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<IList<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<IList<University>> GetAllByFilter(Expression<Func<University, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<University>>(_universityDal.GetAll(filter), UniversityConstants.DataGet);
        }

        public IDataResult<IList<University>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<University>>(_universityDal.GetAll(u => u.IsDeleted), UniversityConstants.DataGet);
        }
        public IDataResult<IList<University>> GetAll()
        {
            return new SuccessDataResult<IList<University>>(_universityDal.GetAll(u => !u.IsDeleted), UniversityConstants.DataGet);
        }

        private IResult UniversityChecker(University university)
        {
            bool findUni = _universityDal.GetAll(u =>
               u.Name.Contains(university.Name)
           && u.Institute.Contains(university.Institute)
           && u.Address.Id == university.Address.Id
           && u.Branch.Id == university.Branch.Id
           && !u.IsDeleted).Any();

            if (findUni)
                return new ErrorResult(UniversityConstants.UniversityExist);

            return new SuccessResult();
        }
    }
}
