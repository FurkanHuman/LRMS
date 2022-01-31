using Business.Abstract;
using Business.Constants;
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
        private static int namelength = 3;
        private static int surnameNamelength = 2;

        public EditorManager(IEditorDal editorDal)
        {
            _editorDal = editorDal;
        }

        public IResult Add(Editor entity)
        {
            IResult result = BusinessRules.Run(EditorControl(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _editorDal.Add(entity);
            return new SuccessResult(EditorConstants.AddSucces);
        }

        public IResult Delete(Editor entity)
        {
            IResult result = BusinessRules.Run(EditorControl(entity));
            if (result != null)
                return result;

            entity.IsDeleted = true;
            _editorDal.Update(entity);
            return new SuccessResult(EditorConstants.EfDeletedSuccsess);
        }

        public IResult Update(Editor entity)
        {
            IResult result = BusinessRules.Run(EditorControl(entity), UpdateControl(entity));
            if (result != null)
                return result;

            _editorDal.Update(entity);
            return new SuccessResult(EditorConstants.EfDeletedSuccsess);
        }

        public IDataResult<Editor> GetById(int id)
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

        private static IResult EditorControl(Editor entity)
        {
            if (entity == null)
                return new ErrorResult(EditorConstants.EditorNull);
            if (entity.Name.Equals(null) || entity.Name.Equals(string.Empty) || entity.Name.Length >= namelength)
                return new ErrorResult(EditorConstants.EditorNameLengthNotEnough);
            if (entity.SurName.Equals(null) || entity.SurName.Equals(string.Empty) || entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(EditorConstants.EditorNameLengthNotEnough);

            return new SuccessResult();
        }

        private IResult UpdateControl(Editor entity)
        {
            Editor updateEditor = _editorDal.Get(i => i == entity);

            if (updateEditor == null)
                return new ErrorResult(EditorConstants.EditorNull);
            if (entity.Name.Equals(updateEditor.Name) || entity.SurName.Equals(updateEditor.SurName)
                || entity.Name.Length >= namelength && entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(EditorConstants.EditorEquals);

            return new SuccessResult();
        }
    }
}
