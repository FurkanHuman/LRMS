using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class LibraryManager : ILibraryService
    {
        private readonly ILibraryDal _libraryDal;

        public LibraryManager(ILibraryDal libraryDal)
        {
            _libraryDal = libraryDal;
        }

        [ValidationAspect(typeof(LibraryValidator), Priority = 1)]
        public IResult Add(Library library)
        {
            IResult result = BusinessRules.Run(LibraryExistControl(library));
            if (result != null)
                return result;

            _libraryDal.Add(library);
            return new SuccessResult(LibraryConstants.AddSuccess);
        }

        public IResult Delete(Library library)
        {
            _libraryDal.Delete(library);
            return new SuccessResult(LibraryConstants.DeleteSuccess);
        }

        public IResult Update(Library library)
        {
            _libraryDal.Update(library);
            return new SuccessResult(LibraryConstants.UpdateSuccess);
        }

        public IDataResult<Library> GetById(int id)
        {
            return new SuccessDataResult<Library>(_libraryDal.Get(l => l.Id.Equals(id) && !l.IsDeleted), LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByName(string name)
        {
            List<Library> libraries = _libraryDal.GetAll(l => l.Name.ToLowerInvariant().Equals(name.ToLowerInvariant()) && !l.IsDeleted).ToList();
            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByAddress(string address)
        {
            List<Library> libraries = _libraryDal.GetAll(l => l.Address.ToLowerInvariant().Equals(address.ToLowerInvariant()) && !l.IsDeleted).ToList();
            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetAll()
        {
            return new SuccessDataResult<List<Library>>(_libraryDal.GetAll().ToList(), LibraryConstants.DataGet);
        }

        private IResult LibraryExistControl(Library library)
        {
            bool resul = _libraryDal.GetAll(l=>
            l.Name.ToLowerInvariant().Contains(library.Name.ToLowerInvariant())
            && l.Address.ToLowerInvariant().Contains(library.Address.ToLowerInvariant())).Any();

            return !resul
                ? new SuccessResult()
                : new ErrorResult(LibraryConstants.LibraryExist);
        }
    }
}
