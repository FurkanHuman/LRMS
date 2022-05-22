using Business.Concrete;
using DataAccess.Concrete;



BranchManager branchManager = new(new EfBranchDal());

branchManager.Add("Graphic Designer");

Console.ReadLine();