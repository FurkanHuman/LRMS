// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class AudioRecordRepository : EfRepositoryBase<AudioRecord, PostgreLRMSDbContext>, IAudioRecordRepository
{
    public AudioRecordRepository(PostgreLRMSDbContext context) : base(context) { }
}
