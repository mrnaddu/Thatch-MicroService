using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Thatch.Projects.EntityFrameworkCore;

[ConnectionStringName(ProjectsDbProperties.ConnectionStringName)]
public interface IProjectsDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}