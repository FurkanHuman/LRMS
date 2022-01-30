using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EditionManager : IEditionService
    {
        private readonly IEditionDal _editionDal;
        private const byte addressSearchLength = 5;

        public EditionManager(IEditionDal editionDal)
        {
            _editionDal = editionDal;
        }

        public IResult Add(Edition edition)
        {
            IResult result = BusinessRules.Run(EditionControl(edition));
            if (result != null)
                return result;

            _editionDal.Add(edition);
            return new SuccessResult(EditionConstants.AddSucces);
        }

        public IResult Delete(Edition edition)
        {
            IResult result = BusinessRules.Run(EditionControl(edition));
            if (result != null)
                return result;

            Edition delEdition = _editionDal.Get(u => u.IsDeleted);
            _editionDal.Delete(delEdition);
            return new SuccessResult(EditionConstants.DeleteSuccess);
        }

        public IResult Update(Edition oldEdition, Edition newEdition)
        {
            IResult result = BusinessRules.Run(EditionUpdateControl(oldEdition, newEdition));
            if (result != null)
                return result;
            oldEdition = newEdition;
            _editionDal.Update(oldEdition);
            return new SuccessResult(EditionConstants.UpdateSuccess);
        }

        public IDataResult<List<Edition>> GetByAdress(string address)
        {
            List<Edition> editions = _editionDal.GetAll(a => a.Address.ToLower().Contains(address.ToLower()) && a.Address.Length >= addressSearchLength && !a.IsDeleted).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound + ", " + EditionConstants.AddressLengthLess)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionNumber(int editionNumber)
        {
            List<Edition> editions = _editionDal.GetAll(a => a.EditionNumber == editionNumber && !a.IsDeleted).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.EditionNumberNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.EditionNumberFound);
        }

        public IDataResult<Edition?> GetByFaxNumber(ulong faxNumber)
        {
            Edition? edition = _editionDal.Get(a => a.FaxNumber == faxNumber && !a.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition?>(EditionConstants.FaxNotFound)
                : new SuccessDataResult<Edition?>(edition, EditionConstants.FaxFound);
        }

        public IDataResult<Edition> GetById(int id)
        {
            Edition edition = _editionDal.Get(f => f.Id == id && !f.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.DataNotGet)
                : new SuccessDataResult<Edition>(edition, EditionConstants.DataGet);
        }

        public IDataResult<Edition> GetByName(string name)
        {
            Edition edition = _editionDal.Get(f => f.Name.ToLower() == name.ToLower() && !f.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.DataNotGet)
                : new SuccessDataResult<Edition>(edition, EditionConstants.DataGet);
        }

        public IDataResult<Edition> GetByPhoneNumber(ulong phoneNumber)
        {
            Edition edition = _editionDal.Get(f => f.PhoneNumber == phoneNumber && !f.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.DataNotGet)
                : new SuccessDataResult<Edition>(edition, EditionConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetByWebsites(string webSite)
        {
            List<Edition> editions = _editionDal.GetAll(f => f.WebSite.ToLower().Contains(webSite)
            && f.WebSite.ToLower().Length >= addressSearchLength && !f.IsDeleted).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.DataNotGetWebSites)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.DataGetWebSites);
        }

        public IDataResult<List<Edition>> GetList()
        {
            return new SuccessDataResult<List<Edition>>((List<Edition>)_editionDal.GetAll(f => !f.IsDeleted), EditionConstants.AllDataGet);
        }

        private static IResult EditionUpdateControl(Edition oldEdition, Edition newEdition)
        {
            return oldEdition == newEdition
                ? new ErrorResult(EditionConstants.EditionEquals) 
                :new SuccessResult();
        }

        private static IResult EditionControl(Edition edition)
        {
            if (edition == null)
                return new ErrorResult(EditionConstants.EditionNotNull);
            if (edition.Name.Equals(null) || edition.Name.Equals(string.Empty))
                return new ErrorResult(EditionConstants.EditionNameNotNull);
            if (edition.Address.Equals(null) || edition.Address.Equals(string.Empty))
                return new ErrorResult(EditionConstants.EditionAddressNotNull);
            if (edition.WebSite.Equals(null) || edition.WebSite.Equals(String.Empty))
                return new ErrorResult(EditionConstants.EditionWebAddressNotNull);
            if (((char)edition.PhoneNumber).Equals(null) || ((char)edition.PhoneNumber).Equals(string.Empty))
                return new ErrorResult(EditionConstants.EditionPhoneNotNull);
            if (edition.EditionNumber.Equals(null) || edition.EditionNumber.Equals(string.Empty))
                return new ErrorResult(EditionConstants.EditionNumberNull);

            return new SuccessResult();
        }
    }
}
