using Business.Abstract;
using Core.DataAccess;
using Core.Entities.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Base
{
    public class FirstPersonBaseManager<Dal>:IFirstPersonBaseService<FirstPagePersonBase>
    where Dal: class, IEntityRepository<FirstPagePersonBase>,new()
    {
        private readonly Dal _dal;

        public FirstPersonBaseManager(Dal dal)
        {
            _dal = dal;
        }

        public IResult Add(FirstPagePersonBase entity)
        {
            IResult result = BusinessRules.Run(NameAndSurnameExists(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _dal.Add(entity);
            return new SuccessResult();
        }


        public IResult Delete(FirstPagePersonBase entity)
        {
            _dal.Delete(entity);
            return new SuccessResult();
        }
        public IResult Update(FirstPagePersonBase entity)
        {
            _dal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<List<FirstPagePersonBase>> GetByFilterList(Expression<Func<FirstPagePersonBase, bool>>? filter = null)
        {
            return new SuccessDataResult<List<FirstPagePersonBase>>(_dal.GetAll(filter).ToList());
        }

        public IDataResult<FirstPagePersonBase> GetById(int id)
        {
            FirstPagePersonBase firstPagePersonBase = _dal.Get(i => i.Id == id && !i.IsDeleted);
            return firstPagePersonBase == null
                ? new ErrorDataResult<FirstPagePersonBase>()
                : new SuccessDataResult<FirstPagePersonBase>();
        }

        public IDataResult<FirstPagePersonBase> GetByName(string name)
        {
            FirstPagePersonBase firstPagePersonBase = _dal.Get(i => i.Name.ToLower().Equals(name.ToLower()) && !i.IsDeleted);
            return firstPagePersonBase == null
                ? new ErrorDataResult<FirstPagePersonBase>()
                : new SuccessDataResult<FirstPagePersonBase>();
        }

        public IDataResult<FirstPagePersonBase> GetBySurname(string surname)
        {
            FirstPagePersonBase firstPagePersonBase = _dal.Get(i => i.SurName.ToLower().Equals(surname.ToLower()) && !i.IsDeleted);
            return firstPagePersonBase == null
                ? new ErrorDataResult<FirstPagePersonBase>()
                : new SuccessDataResult<FirstPagePersonBase>();
        }

        public IDataResult<List<FirstPagePersonBase>> GetList()
        {
            return new SuccessDataResult<List<FirstPagePersonBase>>(_dal.GetAll().ToList());
        }

        private IResult NameAndSurnameExists(FirstPagePersonBase entity)
        {
            bool personBase = _dal.GetAll(e => e.Name.ToLower().Equals(entity.Name.ToLower().Equals(entity.Name.ToLower()) && e.SurName.ToLower().Equals(entity.SurName))).Any<FirstPagePersonBase>();
            return personBase ? new ErrorResult() : new SuccessResult();
        }
    }
}
