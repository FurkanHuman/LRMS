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
    public class EditorManager : IEditorService // Todo ReWrite
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

        public IResult ShadowDelete(Guid guid)
        {
            Editor editor = _editorDal.Get(g => g.Id == guid && !g.IsDeleted);
            if (editor == null)
                return new ErrorResult(EditorConstants.NotMatch);

            editor.IsDeleted = true;
            _editorDal.Update(editor);
            return new SuccessResult(EditorConstants.ShadowDeleteSuccess);
        }

        public IResult Update(Editor entity)
        {
            _editorDal.Update(entity);
            return new SuccessResult(EditorConstants.UpdateSuccess);
        }

        public IDataResult<Editor> GetById(Guid guid)
        {
            Editor editor = _editorDal.Get(i => i.Id == guid && !i.IsDeleted);
            return editor == null ?
                new ErrorDataResult<Editor>(EditorConstants.DataNotGet) :
                new SuccessDataResult<Editor>(EditorConstants.DataGet);
        }

        public IDataResult<List<Editor>> GetByNames(string name)
        {
            List<Editor> editors = _editorDal.GetAll(n => n.Name.ToLower().Contains(name.ToLower()) && !n.IsDeleted).ToList();
            return editors == null
                ? new ErrorDataResult<List<Editor>>(EditorConstants.EditorNull)
                : new SuccessDataResult<List<Editor>>(editors, EditionConstants.DataGet);
        }

        public IDataResult<List<Editor>> GetBySurnames(string surname)
        {
            List<Editor> editors = _editorDal.GetAll(n => n.SurName.ToLower().Contains(surname.ToLower()) && !n.IsDeleted).ToList();
            return editors == null
                ? new ErrorDataResult<List<Editor>>(EditorConstants.EditorNull)
                : new SuccessDataResult<List<Editor>>(editors, EditionConstants.DataGet);
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
