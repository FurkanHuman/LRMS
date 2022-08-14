using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.Facade;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CounterManager : ICounterService
    {
        private readonly ICounterDal _counterDal;

        public CounterManager(ICounterDal counterDal)
        {
            _counterDal = counterDal;
        }

        [ValidationAspect(typeof(CounterValidator), Priority = 1)]
        public IResult Add(Counter counter)
        {
            counter.IsDeleted = false;
            _counterDal.Add(counter);
            return new SuccessResult(CounterConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Counter counter = _counterDal.Get(c => c.Id == id);
            if (counter == null)
                return new ErrorResult(CounterConstants.NotMatch);

            _counterDal.Delete(counter);
            return new SuccessResult(CounterConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Counter counter = _counterDal.Get(c => c.Id == id && !c.IsDeleted);
            if (counter == null)
                return new ErrorResult(CounterConstants.NotMatch);

            counter.IsDeleted = true;
            _counterDal.Update(counter);
            return new SuccessResult(CounterConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(CounterValidator), Priority = 1)]
        public IResult Update(Counter counter)
        {
            counter.IsDeleted = true;
            _counterDal.Update(counter);
            return new SuccessResult(CounterConstants.EfDeletedSuccsess);
        }

        public IDataResult<IList<Counter>> GetAll()
        {
            return new SuccessDataResult<IList<Counter>>(_counterDal.GetAll(c => !c.IsDeleted), CounterConstants.DataGet);
        }

        public IDataResult<IList<Counter>> GetAllByFilter(Expression<Func<Counter, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Counter>>(_counterDal.GetAll(filter), CounterConstants.DataGet);
        }

        public IDataResult<IList<Counter>> GetAllByIds(Guid[] ids)
        {
            IList<Counter> counters = _counterDal.GetAll(c => ids.Contains(c.Id) && !c.IsDeleted);

            return counters == null
                ? new ErrorDataResult<IList<Counter>>(CounterConstants.NotMatch)
                : new SuccessDataResult<IList<Counter>>(counters, CounterConstants.DataGet);
        }

        public IDataResult<IList<Counter>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Counter>>(_counterDal.GetAll(c => c.IsDeleted), CounterConstants.DataGet);
        }

        public IDataResult<IList<Counter>> GetAllByName(string name)
        {
            return new ErrorDataResult<IList<Counter>>(CounterConstants.Disabled);
        }

        public IDataResult<Counter> GetById(Guid id)
        {
            Counter counter = _counterDal.Get(c => c.Id == id);

            return counter == null
                ? new ErrorDataResult<Counter>(CounterConstants.NotMatch)
                : new SuccessDataResult<Counter>(counter, CounterConstants.DataGet);
        }

        public Task Count<T>(T? t) where T : MaterialBase, IEntity, new()
        {
            Task task = Task.Run(() =>
                {
                    CountPlus(t.CounterId);
                });

            return task;
        }

        public Task Count<T>(IList<T>? ts) where T : MaterialBase, IEntity, new()
        {
            Task task = Task.Run(() =>
                {
                    if (ts == null)
                        return;

                    IList<Guid> guidList = ts.Select(c => c.Id).ToList();
                    if (guidList.Count > 0)
                        CountPlus(guidList);
                });

            return task;
        }

        private void CountPlus(Guid id)
        {
            Counter counter = _counterDal.Get(c => c.Id == id);
            if (counter == null)
                return;
            counter.Count++;
            _counterDal.Update(counter);
        }

        private void CountPlus(IList<Guid> ids)
        {
            IList<Counter> counters = _counterDal.GetAll(cs => ids.Contains(cs.Id));
            foreach (Counter counter in counters)
            {
                counter.Count++;
                _counterDal.Update(counter);
            }
        }
    }
}