// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class AcademicJournalRepository : EfRepositoryBase<AcademicJournal, PostgreLRMSDbContext>, IAcademicJournalRepository
{
    public AcademicJournalRepository(PostgreLRMSDbContext context) : base(context) { }
}
