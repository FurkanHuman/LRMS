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
    public class EditionManager : IEditionService
    {
        private readonly IEditionDal _editionDal;
        private const byte addressSearchLength = 5;

        public EditionManager(IEditionDal editionDal)
        {
            _editionDal = editionDal;
        }

        [ValidationAspect(typeof(EditionValidator), Priority = 1)]
        public IResult Add(Edition edition)
        {
            IResult result = BusinessRules.Run(EditionControl(edition));
            if (result != null)
                return result;

            _editionDal.Add(edition);
            return new SuccessResult(EditionConstants.AddSuccess);
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

        public IResult Update(Edition edition)
        {
            _editionDal.Update(edition);
            return new SuccessResult(EditionConstants.UpdateSuccess);
        }

        public IDataResult<List<Edition>> GetByAdress(string address)
        {

            return new ErrorDataResult<List<Edition>>(EditionConstants.Disabled);
            //  List<Edition> editions = _editionDal.GetAll(a => a.Address.ToLower().Contains(address.ToLower()) && a.Address.Length >= addressSearchLength && !a.IsDeleted).ToList();
            //  return editions == null
            //    ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound + ", " + EditionConstants.AddressLengthLess)
            //    : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionNumber(int editionNumber)
        {
            List<Edition> editions = _editionDal.GetAll(a => a.EditionNumber == editionNumber && !a.IsDeleted).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.EditionNumberNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.EditionNumberFound);
        }

        public IDataResult<Edition?> GetByFaxNumber(string faxNumber)
        {
            return new ErrorDataResult<Edition?>(EditionConstants.Disabled);

            //Edition? edition = _editionDal.Get(a => a.FaxNumber.Equals(faxNumber) && !a.IsDeleted);
            //return edition == null
            //    ? new ErrorDataResult<Edition?>(EditionConstants.FaxNotFound)
            //    : new SuccessDataResult<Edition?>(edition, EditionConstants.FaxFound);
        }

        public IDataResult<Edition> GetById(Guid id)
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

        public IDataResult<Edition> GetByPhoneNumber(string phoneNumber)
        {
            return new ErrorDataResult<Edition>(EditionConstants.Disabled);
            //Edition edition = _editionDal.Get(f => f.PhoneNumber.Equals(phoneNumber) && !f.IsDeleted);
            //return edition == null
            //    ? new ErrorDataResult<Edition>(EditionConstants.DataNotGet)
            //    : new SuccessDataResult<Edition>(edition, EditionConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetByWebsites(string webSite)
        {
            //    List<Edition> editions = _editionDal.GetAll(f => f.WebSite.ToLower().Contains(webSite)
            //    && f.WebSite.ToLower().Length >= addressSearchLength && !f.IsDeleted).ToList();
            //    return editions == null
            //        ? new ErrorDataResult<List<Edition>>(EditionConstants.DataNotGetWebSites)
            //        : new SuccessDataResult<List<Edition>>(editions, EditionConstants.DataGetWebSites);

            return new ErrorDataResult<List<Edition>>(EditionConstants.Disabled);
        }

        public IDataResult<List<Edition>> GetList()
        {
            return new SuccessDataResult<List<Edition>>((List<Edition>)_editionDal.GetAll(f => !f.IsDeleted), EditionConstants.AllDataGet);
        }

        private IResult EditionControl(Edition edition)
        {
            // fix it Todo
            bool result = _editionDal.GetAll(e =>
               e.Name.ToLowerInvariant().Equals(edition.Name.ToLowerInvariant())
            && e.Address.Equals(edition.Address)
            && e.DateOfPublication.Equals(edition.DateOfPublication)
            && e.EditionNumber.Equals(edition.EditionNumber)).Any();

            return result
                ? new ErrorResult(EditionConstants.EditionEquals)
                : new SuccessResult(PublisherConstants.AllDataGet);
        }
    }
}
