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
    public class EditorManager : IEditorService
    {
        private readonly IEditorDal _editorDal;

        public EditorManager(IEditorDal editorDal)
        {
            _editorDal = editorDal;
        }

        [ValidationAspect(typeof(EditorValidator), Priority = 1)]
        public IResult Add(Editor entity)
        {
            IResult result = BusinessRules.Run(EditorNameOrSurnameExist(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _editorDal.Add(entity);
            return new SuccessResult(EditorConstants.AddSuccess);
        }

        public IResult Delete(Editor entity)
        {
            _editorDal.Delete(entity);
            return new SuccessResult(EditorConstants.DeleteSuccess);
        }

        public IResult Update(Editor entity)
        {
            _editorDal.Update(entity);
            return new SuccessResult(EditorConstants.UpdateSuccess);
        }

        public IDataResult<Editor> GetById(Guid id)
        {
            Editor editor = _editorDal.Get(i => i.Id == id && !i.IsDeleted);
            return editor == null ?
                new ErrorDataResult<Editor>(EditorConstants.DataNotGet) :
                new SuccessDataResult<Editor>(EditorConstants.DataGet);
        }

        public IDataResult<Editor> GetByName(string name)
        {
            Editor editor = _editorDal.Get(n => n.Name.ToLower().Contains(name.ToLower()) && !n.IsDeleted);
            return editor == null
                ? new ErrorDataResult<Editor>(editor, EditorConstants.EditorNull)
                : new SuccessDataResult<Editor>(editor, EditionConstants.DataGet);
        }

        public IDataResult<Editor> GetBySurname(string surname)
        {
            Editor editor = _editorDal.Get(n => n.SurName.ToLower().Contains(surname.ToLower()) && !n.IsDeleted);
            return editor == null
                ? new ErrorDataResult<Editor>(editor, EditorConstants.EditorNull)
                : new SuccessDataResult<Editor>(editor, EditionConstants.DataGet);
        }

        public IDataResult<List<Editor>> GetList()
        {
            return new SuccessDataResult<List<Editor>>(_editorDal.GetAll(n => !n.IsDeleted).ToList(), EditionConstants.DataGet);
        }

        public IDataResult<List<Editor>> GetByFilterList(Expression<Func<Editor, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Editor>>(_editorDal.GetAll(filter).ToList(), EditionConstants.DataGet);
        }

        private IResult EditorNameOrSurnameExist(Editor entity)
        {

            bool result = _editorDal.GetAll(w => w.Name.ToUpperInvariant().Equals(entity.Name.ToUpperInvariant())
            && w.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())).Any();
            return result
                ? new ErrorResult(EditorConstants.NameOrSurnameExists)
                : new SuccessResult(EditorConstants.DataGet);

        }

    }
}
