// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class AudioRecordRepository : EfRepositoryBase<AudioRecord, PostgreLrmsDbContext>, IAudioRecordRepository
{
    public AudioRecordRepository(PostgreLrmsDbContext context) : base(context) { }
}
