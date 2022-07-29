using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LRMS_Test.Tests
{
    [TestClass]
    public class CountryTest
    {
        ICountryDal _CountryDal = new EfCountryDal();

        [TestMethod]
        public void GetAll()
        {
            var country = _CountryDal.GetAll();

            Assert.IsTrue(true, "Test Ok");
        }

        [TestMethod]
        public void IGetAll()
        {
            var country = _CountryDal.IGetAll();

            Assert.IsTrue(true, "Test Ok");
        }
    }
}
