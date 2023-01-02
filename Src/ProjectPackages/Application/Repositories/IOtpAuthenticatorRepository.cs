// this file was created automatically.
using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;

namespace Application.Repositories;

public interface IOtpAuthenticatorRepository : IAsyncRepository<OtpAuthenticator>, IRepository<OtpAuthenticator>
{
}
