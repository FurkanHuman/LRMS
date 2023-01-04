// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class MusicalNoteRepository : EfRepositoryBase<MusicalNote, PostgreLrmsDbContext>, IMusicalNoteRepository
{
    public MusicalNoteRepository(PostgreLrmsDbContext context) : base(context) { }
}
