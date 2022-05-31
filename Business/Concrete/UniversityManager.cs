﻿using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class UniversityManager : IUniversityService
    {
        private readonly IUniversityDal _universityDal;
        private readonly IAddressService _addressService;
        private readonly IBranchService _branchService;

        public UniversityManager(IUniversityDal universityDal, IAddressService addressService, IBranchService branchService)
        {
            _universityDal = universityDal;
            _addressService = addressService;
            _branchService = branchService;
        }

        [ValidationAspect(typeof(University), Priority = 1)]
        public IResult Add(University university)
        {
            IResult result = BusinessRules.Run(_addressService.GetById(university.Address.Id), _branchService.Get(university.Branch.Id), UniversityChecker(university));
            if (result != null)
                return result;

            _universityDal.Add(university);
            return new SuccessResult(UniversityConstants.UpdateSuccess);
        }

        public IResult Delete(University university)
        {
            _universityDal.Delete(university);
            return new SuccessResult(UniversityConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid guid)
        {
            University university = _universityDal.Get(u => u.Id == guid && !u.IsDeleted);
            if (university == null)
                return new ErrorResult(UniversityConstants.NotMatch);

            university.IsDeleted = true;
            _universityDal.Update(university);
            return new SuccessResult(UniversityConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(University), Priority = 1)]
        public IResult Update(University university)
        {
            IResult result = BusinessRules.Run(_addressService.GetById(university.Address.Id), _branchService.Get(university.Branch.Id), UniversityChecker(university));
            if (result != null)
                return result;

            _universityDal.Update(university);
            return new SuccessResult(UniversityConstants.UpdateSuccess);
        }

        public IDataResult<University> GetById(Guid guid)
        {
            University university = _universityDal.Get(u => u.Id == guid && !u.IsDeleted);

            return university == null
                ? new ErrorDataResult<University>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<University>(university, UniversityConstants.DataGet);
        }

        public IDataResult<University> GetByAddressId(Guid guid)
        {
            University university = _universityDal.Get(u => u.Address.Id == guid && !u.IsDeleted);

            return university == null
                ? new ErrorDataResult<University>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<University>(university, UniversityConstants.DataGet);
        }

        public IDataResult<List<University>> GetByUniversityNames(string universityName)
        {
            List<University> universities = _universityDal.GetAll(u => u.UniversityName.Contains(universityName, StringComparison.CurrentCultureIgnoreCase) && !u.IsDeleted).ToList();

            return universities == null
                ? new ErrorDataResult<List<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<List<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<List<University>> GetByInstituteNames(string instituteName)
        {
            List<University> universities = _universityDal.GetAll(u => u.Institute.Contains(instituteName, StringComparison.CurrentCultureIgnoreCase) && !u.IsDeleted).ToList();

            return universities == null
                ? new ErrorDataResult<List<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<List<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<List<University>> GetByBranchNames(string branchName)
        {
            List<University> universities = _universityDal.GetAll(u => u.Branch.Name.Contains(branchName, StringComparison.CurrentCultureIgnoreCase) && !u.IsDeleted).ToList();

            return universities == null
                ? new ErrorDataResult<List<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<List<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<List<University>> GetByBranchId(int branchId)
        {
            List<University> universities = _universityDal.GetAll(u => u.Branch.Id == branchId && !u.IsDeleted).ToList();

            return universities == null
                ? new ErrorDataResult<List<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<List<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<List<University>> GetByCityNames(string cityName)
        {
            List<University> universities = _universityDal.GetAll(u => u.Address.City.CityName.Contains(cityName, StringComparison.CurrentCultureIgnoreCase) && !u.IsDeleted).ToList();

            return universities == null
                ? new ErrorDataResult<List<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<List<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<List<University>> GetByCityId(int cityId)
        {
            List<University> universities = _universityDal.GetAll(u => u.Address.City.Id == cityId && !u.IsDeleted).ToList();

            return universities == null
                ? new ErrorDataResult<List<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<List<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<List<University>> GetByCountryNames(string countryName)
        {
            List<University> universities = _universityDal.GetAll(u => u.Address.Country.CountryName.Contains(countryName, StringComparison.CurrentCultureIgnoreCase) && !u.IsDeleted).ToList();

            return universities == null
                ? new ErrorDataResult<List<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<List<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<List<University>> GetByCountryId(int countryId)
        {
            List<University> universities = _universityDal.GetAll(u => u.Address.Country.Id == countryId && !u.IsDeleted).ToList();

            return universities == null
                ? new ErrorDataResult<List<University>>(UniversityConstants.DataNotGet)
                : new SuccessDataResult<List<University>>(universities, UniversityConstants.DataGet);
        }

        public IDataResult<List<University>> GetAllByFilter(Expression<Func<University, bool>>? filter = null)
        {
            return new SuccessDataResult<List<University>>(_universityDal.GetAll(filter).ToList(), UniversityConstants.DataGet);
        }

        public IDataResult<List<University>> GetAll()
        {
            return new SuccessDataResult<List<University>>(_universityDal.GetAll(u => !u.IsDeleted).ToList(), UniversityConstants.DataGet);
        }

        private IResult UniversityChecker(University university)
        {
            bool findUni = _universityDal.GetAll(u =>
               u.UniversityName.Contains(university.UniversityName, StringComparison.CurrentCultureIgnoreCase)
           && u.Institute.Contains(university.Institute, StringComparison.CurrentCultureIgnoreCase)
           && u.Address.Id == university.Address.Id
           && u.Branch.Id == university.Branch.Id
           && !u.IsDeleted).Any();

            if (findUni)
                return new ErrorResult(UniversityConstants.UniversityExist);

            return new SuccessResult();
        }
    }
}