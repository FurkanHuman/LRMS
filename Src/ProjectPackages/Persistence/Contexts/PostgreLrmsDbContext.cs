using Core.Domain.Abstract;
using Domain.Entities.Infos;
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Persistence.Contexts.BaseContext;
using System.Reflection;

namespace Persistence.Contexts;

public class PostgreLrmsDbContext : BaseLrmsContext
{
    public PostgreLrmsDbContext(DbContextOptions<PostgreLrmsDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected IConfiguration Configuration { get; set; }
}
