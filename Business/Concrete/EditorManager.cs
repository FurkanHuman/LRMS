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

        public IResult Delete(Guid id)
        {
            Editor editor = _editorDal.Get(e => e.Id == id);
            if (editor == null)
                return new ErrorResult(EditionConstants.NotMatch);

            _editorDal.Delete(editor);
            return new SuccessResult(EditorConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Editor editor = _editorDal.Get(g => g.Id == id && !g.IsDeleted);
            if (editor == null)
                return new ErrorResult(EditorConstants.NotMatch);

            editor.IsDeleted = true;
            _editorDal.Update(editor);
            return new SuccessResult(EditorConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(EditorValidator), Priority = 1)]
        public IResult Update(Editor entity)
        {
            _editorDal.Update(entity);
            return new SuccessResult(EditorConstants.UpdateSuccess);
        }

        public IDataResult<Editor> GetById(Guid id)
        {
            Editor editor = _editorDal.Get(i => i.Id == id);
            return editor == null ?
                new ErrorDataResult<Editor>(EditorConstants.DataNotGet) :
                new SuccessDataResult<Editor>(EditorConstants.DataGet);
        }

        public IDataResult<List<Editor>> GetAllByIds(Guid[] ids)
        {
            List<Editor> editors = _editorDal.GetAll(n => ids.Contains(n.Id) && !n.IsDeleted).ToList();
            return editors == null
                ? new ErrorDataResult<List<Editor>>(EditorConstants.EditorNull)
                : new SuccessDataResult<List<Editor>>(editors, EditionConstants.DataGet);
        }

        public IDataResult<List<Editor>> GetAllByName(string name)
        {
            List<Editor> editors = _editorDal.GetAll(n => n.Name.ToLower().Contains(name) && !n.IsDeleted).ToList();
            return editors == null
                ? new ErrorDataResult<List<Editor>>(EditorConstants.EditorNull)
                : new SuccessDataResult<List<Editor>>(editors, EditionConstants.DataGet);
        }

        public IDataResult<List<Editor>> GetAllBySurname(string surname)
        {
            List<Editor> editors = _editorDal.GetAll(n => n.SurName.ToLower().Contains(surname) && !n.IsDeleted).ToList();
            return editors == null
                ? new ErrorDataResult<List<Editor>>(EditorConstants.EditorNull)
                : new SuccessDataResult<List<Editor>>(editors, EditionConstants.DataGet);
        }

        public IDataResult<List<Editor>> GetAllByFilter(Expression<Func<Editor, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Editor>>(_editorDal.GetAll(filter).ToList(), EditionConstants.DataGet);
        }

        public IDataResult<List<Editor>> GetAll()
        {
            return new SuccessDataResult<List<Editor>>(_editorDal.GetAll(n => !n.IsDeleted).ToList(), EditionConstants.DataGet);
        }

        public IDataResult<List<Editor>> GetAllBySecret()
        {
            return new SuccessDataResult<List<Editor>>(_editorDal.GetAll(n => n.IsDeleted).ToList(), EditionConstants.DataGet);
        }

        private IResult EditorNameOrSurnameExist(Editor entity)
        {
            bool result = _editorDal.GetAll(w => w.Name.Equals(entity.Name)
            && w.SurName.Equals(entity.SurName)).Any();
            return result
                ? new ErrorResult(EditorConstants.NameOrSurnameExists)
                : new SuccessResult(EditorConstants.DataGet);
        }
    }
}
