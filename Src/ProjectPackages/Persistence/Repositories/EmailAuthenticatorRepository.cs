// this file was created automatically.
using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, PostgreLrmsUserDbContext>, IEmailAuthenticatorRepository
{
    public EmailAuthenticatorRepository(PostgreLrmsUserDbContext context) : base(context) { }
}
