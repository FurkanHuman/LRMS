// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class EditorRepository : EfRepositoryBase<Editor, PostgreLRMSDbContext>, IEditorRepository
{
    public EditorRepository(PostgreLRMSDbContext context) : base(context) { }
}
