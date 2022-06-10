﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.Infos;

namespace LRMS_Test
{
    [TestClass]
    public class BranchTest
    {
        private readonly IBranchService _branchService = new BranchManager(new EfBranchDal());

        [TestMethod]
        public void AddTest()
        {
            Branch branch = new() { Name = "Shit loop" };

            var testAdd = _branchService.Add(branch);

            Assert.IsTrue(testAdd.Success, "Add Test Success");
        }

        [TestMethod]
        public void DeleteTest()
        {
            int id = 3;

            var testDelete = _branchService.Delete(id);

            Assert.IsTrue(testDelete.Success, "Delete Test Succsess");

        }

        [TestMethod]
        public void ShadowDeleteTest()
        {
            int id = 9;

            var testShadowDelete = _branchService.ShadowDelete(id);

            Assert.IsTrue(testShadowDelete.Success, "Shadow Delete Test Succsess");
        }

        [TestMethod]
        public void UpdateTest()
        {
            Branch branch = new() { Name = "real net human", Id = 8 };

            var testUpdate = _branchService.Update(branch);

            Assert.IsTrue(testUpdate.Success, "Update Test Success");
        }

        [TestMethod]
        public void GetById()
        {
            int id = 7;

            var testGetById = _branchService.GetById(id);

            Assert.IsTrue(testGetById.Success, "Get By Id Test Success");
        }

        [TestMethod]
        public void GetByName()
        {
            var testGetByName = _branchService.GetByNames("por");

            Assert.IsTrue(testGetByName.Success, " Get By Names Test Success");
        }

        [TestMethod]
        public void GetByFilterLists()
        {
            int id = 10;

            var testGetByFilterLists = _branchService.GetByFilterLists(b => b.Id == id);

            Assert.IsTrue(testGetByFilterLists.Success, "Get By Filter Lists Test Success");
        }

        [TestMethod]
        public void GetAllBySecrets()
        {
            var testGetAllBySecrets = _branchService.GetAllBySecrets();

            Assert.IsTrue(testGetAllBySecrets.Success, "Get All By Secrets Test Success");
        }

        [TestMethod]
        public void Getall()
        {
            var testGetAll = _branchService.GetAll();

            Assert.IsTrue(testGetAll.Success, "Get All Test Success");
        }
    }
}