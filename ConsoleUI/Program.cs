using Business.Concrete;
using Core.Utilities.JsonHelper.Abstract;
using Core.Utilities.JsonHelper.Concrete;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities.Concrete.Infos;
using Npgsql;
using System.Data;



BranchManager branchManager=new (new EfBranchDal());

branchManager.Add("Graphic Designer");

Console.ReadLine();