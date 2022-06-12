using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.Infos;

namespace LRMS_Test.Tests
{
    // [TestClass]
    public class CityTest
    {
        private readonly ICityService _cityService = new CityManager(new EfCityDal());

        [TestMethod]
        public void AddTest()
        {
            City city = new() { CityName = "Afyon Karahisar", CountryId = 1 };

            var testAdd = _cityService.Add(city);

            Assert.IsTrue(!testAdd.Success, "Add Test Success");
        }

        [TestMethod]
        public void DeleteTest()
        {
            int id = 3;

            var testDelete = _cityService.Delete(id);

            Assert.IsFalse(testDelete.Success, "Delete Test Succsess");

        }

        [TestMethod]
        public void ShadowDeleteTest()
        {
            int id = 9;

            var testShadowDelete = _cityService.ShadowDelete(id);

            Assert.IsFalse(!testShadowDelete.Success, "Shadow Delete Test Succsess");
        }

        [TestMethod]
        public void UpdateTest()
        {
            City city = new() { CityName = "real net human", Id = 8, CountryId = 1 };

            var testUpdate = _cityService.Update(city);

            Assert.IsTrue(!testUpdate.Success, "Update Test Success");
        }

        [TestMethod]
        public void GetById()
        {
            int id = 3;

            var testGetById = _cityService.GetById(id);

            Assert.IsTrue(testGetById.Success, "Get By Id Test Success");
        }

        [TestMethod]
        public void GetByName()
        {
            var testGetByName = _cityService.GetByNames("Ed");

            Assert.IsTrue(testGetByName.Success, " Get By Names Test Success");
        }

        [TestMethod]
        public void GetByFilterLists()
        {
            int id = 10;

            var testGetByFilterLists = _cityService.GetByFilterLists(b => b.Id == id);

            Assert.IsTrue(testGetByFilterLists.Success, "Get By Filter Lists Test Success");
        }

        [TestMethod]
        public void GetAllBySecrets()
        {
            var testGetAllBySecrets = _cityService.GetAllBySecrets();

            Assert.IsTrue(testGetAllBySecrets.Success, "Get All By Secrets Test Success");
        }

        [TestMethod]
        public void Getall()
        {
            var testGetAll = _cityService.GetAll();

            Assert.IsTrue(testGetAll.Success, "Get All Test Success");
        }
    }
}