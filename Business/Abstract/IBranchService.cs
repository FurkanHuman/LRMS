namespace Business.Abstract
{
    public interface IBranchService : IBaseEntityService<Branch, int>, IBaseDtoService<Branch, BranchDto, BranchAddDto, BranchUpdateDto, int>
    {
    }
}
