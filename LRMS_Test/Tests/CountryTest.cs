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
    }
}
