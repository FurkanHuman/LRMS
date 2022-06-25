using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.Infos;

namespace LRMS_Test.Tests
{
    // [TestClass]
    public class CategoryTest
    {
        private readonly ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());

        [TestMethod]
        public void AddTest()
        {
            Category category = new() { Name = "Astronomi" };

            var testAdd = _categoryService.Add(category);

            Assert.IsTrue(!testAdd.Success, "Add Test Success");
        }

        [TestMethod]
        public void DeleteTest()
        {
            int id = 8;

            var testDelete = _categoryService.Delete(id);

            Assert.IsTrue(!testDelete.Success, "Delete Test Succsess");
        }

        [TestMethod]
        public void ShadowDeleteTest()
        {
            int id = 10;

            var testShadowDelete = _categoryService.ShadowDelete(id);

            Assert.IsFalse(testShadowDelete.Success, "Shadow Delete Test Succsess");
        }

        [TestMethod]
        public void UpdateTest()
        {
            Category category = new() { Name = "Harita", Id = 9 };

            var testUpdate = _categoryService.Update(category);

            Assert.IsFalse(!testUpdate.Success, "Update Test Success");
        }

        [TestMethod]
        public void GetById()
        {
            int id = 7;

            var testGetById = _categoryService.GetById(id);

            Assert.IsTrue(testGetById.Success, "Get By Id Test Success");
        }

        [TestMethod]
        public void GetByIds()
        {
            int[] ids = {12};

            var testGetById = _categoryService.GetByIds(ids);

            Assert.IsTrue(testGetById.Success, "Get By Id Test Success");
        }

        [TestMethod]
        public void GetByName()
        {
            var testGetByName = _categoryService.GetByNames("Kor");

            Assert.IsTrue(testGetByName.Success, " Get By Names Test Success");
        }

        [TestMethod]
        public void GetByFilterLists()
        {
            int id = 10;

            var testGetByFilterLists = _categoryService.GetAllByFilter(b => b.Id == id);

            Assert.IsTrue(testGetByFilterLists.Success, "Get By Filter Lists Test Success");
        }

        [TestMethod]
        public void GetAllBySecrets()
        {
            var testGetAllBySecrets = _categoryService.GetAllBySecrets();

            Assert.IsTrue(testGetAllBySecrets.Success, "Get All By Secrets Test Success");
        }

        [TestMethod]
        public void Getall()
        {
            var testGetAll = _categoryService.GetAll();

            Assert.IsTrue(testGetAll.Success, "Get All Test Success");
        }
    }
}