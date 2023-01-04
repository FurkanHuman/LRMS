// this file was created automatically.
using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, PostgreLrmsUserDbContext>, IOtpAuthenticatorRepository
{
    public OtpAuthenticatorRepository(PostgreLrmsUserDbContext context) : base(context) { }
}
