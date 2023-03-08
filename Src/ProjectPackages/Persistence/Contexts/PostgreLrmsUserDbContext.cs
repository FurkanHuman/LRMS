using Core.Domain.Abstract;
using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Persistence.Contexts.BaseContext;
using System.Reflection;

namespace Persistence.Contexts;

public class PostgreLrmsUserDbContext : BaseLrmsUserContext
{
    public PostgreLrmsUserDbContext(DbContextOptions<PostgreLrmsUserDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }


    protected IConfiguration Configuration { get; set; }
}
